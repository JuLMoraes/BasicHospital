using Dapper;
using Domain.Core.Entities;
using Domain.Core.Repositories;
using Domain.Core.Repositories.Base;
using Infra.Repositories.Base;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class CredencialRepository : BaseRepository<Credencial>, ICredenciaisRepository   
    {
        public CredencialRepository(DbContext aSeaContext, IUnityOfWork unityOfWork) : base(aSeaContext, unityOfWork)
        {
        }

        public async Task<Credencial> GetByLogin(string user, string pass)
        {
            string query = @"SELECT * FROM Credencial WHERE Login = @user AND Senha = @pass AND Ativo = 1";
            var retorno = await _context.Dapper.QueryAsync<Credencial>(query, new { user, pass });
            return retorno.FirstOrDefault();
        }
    }
}
