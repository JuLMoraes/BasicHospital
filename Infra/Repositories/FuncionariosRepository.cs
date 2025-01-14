using Dapper;
using Domain.Core.Entities;
using Domain.Core.Repositories;
using Domain.Core.Repositories.Base;
using Infra.Repositories.Base;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class FuncionariosRepository : BaseRepository<FuncionarioEntity>, IFuncionariosRepository
    {
        public FuncionariosRepository(DbContext aSeaContext, IUnityOfWork unityOfWork) : base(aSeaContext, unityOfWork)
        {
        }

        public async Task<FuncionarioEntity> Get(int id)
        {
            string query = @"SELECT * FROM Funcionario WHERE Id = @id AND Ativo = 1";
            var retorno = await _context.Dapper.QueryAsync<FuncionarioEntity>(query, new { id });
            return retorno.FirstOrDefault();
        }
    }
}
