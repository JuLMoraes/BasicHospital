using Domain.Core.Entities;
using Domain.Core.Repositories.Base;
using Domain.Core.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Core.Repositories
{
    public interface IConsultaRepository : IBaseRepository<ConsultaEntity>
    {
        Task<ConsultaEntity> Get(int id);
        Task<List<ConsultaEntity>> GetList(int funcionarioId);
        Task Adicionar(ConsultaEntity entity);
    }
}
