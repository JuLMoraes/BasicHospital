using Domain.Core.Entities;
using Domain.Core.Repositories.Base;
using Domain.Core.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Core.Repositories
{
    public interface IConsultaRepository : IBaseRepository<Consulta>
    {
        Task<Consulta> Get(int id);
        Task<List<Consulta>> GetList(int funcionarioId);
        Task Adicionar(Consulta entity);
    }
}
