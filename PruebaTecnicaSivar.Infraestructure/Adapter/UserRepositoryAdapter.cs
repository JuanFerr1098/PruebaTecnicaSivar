using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSivar.Domain.Entity;
using PruebaTecnicaSivar.Domain.Repository;
using PruebaTecnicaSivar.Infrastructure.Context;
using PruebaTecnicaSivar.Infrastructure.Entity;

namespace PruebaTecnicaSivar.Infrastructure.Adapter
{
    public class UserRepositoryAdapter : BaseRepositoryAdapter<User, Guid, UserEntity>, IUserRepository
    {
        public UserRepositoryAdapter(InfrastructureEFContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<User>> GetAllUsers()
        {
            var response = await _context.Users.Include(r => r.Role).Include(c => c.Companies).ToListAsync();
            return _mapper.Map<List<User>>(response);
        }

        public async Task<List<Company>> GetCompaniesByUserId(Guid id)
        {
            var response = await _context.Companies.Include(c => c.User).Where(x => x.UserId.Equals(id)).ToListAsync();
            return _mapper.Map<List<Company>>(response);
        }

        public async Task<User> GetRoleByUserId(Guid id)
        {
            var response = await _context.Users.Include(r => r.Role).FirstOrDefaultAsync(u => u.Id.Equals(id));
            return _mapper.Map<User>(response);
        }
    }
}
