using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSivar.DomainCommon.Entity;
using PruebaTecnicaSivar.DomainCommon.Repository;
using PruebaTecnicaSivar.Infrastructure.Context;
using PruebaTecnicaSivar.Infrastructure.Entity;
using System.Linq.Expressions;

namespace PruebaTecnicaSivar.Infrastructure.Adapter
{
    public class BaseRepositoryAdapter<T, ID, TInfra> : IBaseAsyncRepository<T, ID> where T : BaseEntity<ID> where TInfra : BaseDBEntity<ID>
    {
        protected readonly InfrastructureEFContext _context;
        protected readonly IMapper _mapper;

        public BaseRepositoryAdapter(InfrastructureEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<T> AddAsync(T entity)
        {
            TInfra infraEntity = _mapper.Map<TInfra>(entity);
            _context.Set<TInfra>().Add(infraEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<T>(infraEntity);
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var responses = await _context.Set<TInfra>().ToListAsync();
            return _mapper.Map<IReadOnlyList<T>>(responses);
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate) => await _context.Set<T>().Where(predicate).ToListAsync();

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                               string includeString = null,
                                               bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();
            if (disableTracking) query = query.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);
            if (predicate != null) query = query.Where(predicate);
            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                               List<Expression<Func<T, object>>> includes = null,
                                               bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();
            if (disableTracking) query = query.AsNoTracking();
            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));
            if (predicate != null) query = query.Where(predicate);
            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var response = await _context.Set<TInfra>().FindAsync(id);   
            return _mapper.Map<T>(response);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var tInfra = _mapper.Map<TInfra>(entity);
            var dbEntity = await _context.Set<TInfra>().FindAsync(entity.Id);
            tInfra.DateCreated = dbEntity.DateCreated;
            tInfra.UserCreated = dbEntity.UserCreated;
            _context.Entry(tInfra).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<T>(tInfra);
        }
    }
}
