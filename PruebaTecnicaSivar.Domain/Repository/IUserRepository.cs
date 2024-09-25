using PruebaTecnicaSivar.Domain.Entity;
using PruebaTecnicaSivar.DomainCommon.Repository;

namespace PruebaTecnicaSivar.Domain.Repository
{
    public interface IUserRepository : IBaseAsyncRepository<User, Guid>
    { 
        Task<List<User>> GetAllUsers();
        Task<User> GetRoleByUserId(Guid id);
        Task<List<Company>> GetCompaniesByUserId(Guid id);
    }
}
