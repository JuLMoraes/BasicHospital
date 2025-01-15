using Domain.Core.Entities;
using Domain.Core.Repositories.Base;
using System.Threading.Tasks;

namespace Domain.Core.Repositories
{
    public interface ICredenciaisRepository : IBaseRepository<Credencial>
    {
        public Task<Credencial> GetByLogin(string user, string pass);
    }
}
