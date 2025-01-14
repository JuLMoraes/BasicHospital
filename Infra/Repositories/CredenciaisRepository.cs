using Dapper;
using Domain.Core.Entities;
using Domain.Core.Repositories;
using Domain.Core.Repositories.Base;
using Infra.Repositories.Base;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class CredenciaisRepository : BaseRepository<CredenciaisEntity>, ICredenciaisRepository   
    {
        public CredenciaisRepository(DbContext aSeaContext, IUnityOfWork unityOfWork) : base(aSeaContext, unityOfWork)
        {
        }

        public async Task<CredenciaisEntity> GetByLogin(string user, string pass)
        {
            string query = @"SELECT * FROM Credenciais WHERE Login = @user AND Senha = @pass AND Ativo = 1";
            var retorno = await _context.Dapper.QueryAsync<CredenciaisEntity>(query, new { user, pass });
            return retorno.FirstOrDefault();
        }
    }
}
