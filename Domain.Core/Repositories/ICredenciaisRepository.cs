using Domain.Core.Entities;
using Domain.Core.Repositories.Base;
using System.Threading.Tasks;

namespace Domain.Core.Repositories
{
    public interface ICredenciaisRepository : IBaseRepository<CredenciaisEntity>
    {
        public Task<CredenciaisEntity> GetByLogin(string user, string pass);
    }
}
