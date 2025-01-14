using Dapper;
using Domain.Core.Entities;
using Domain.Core.Repositories;
using Domain.Core.Repositories.Base;
using Infra.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class ConsultaRepository : BaseRepository<ConsultaEntity>, IConsultaRepository
    {
        public ConsultaRepository(DbContext aSeaContext, IUnityOfWork unityOfWork) : base(aSeaContext, unityOfWork)
        {
        }

        public async Task<ConsultaEntity> Get(int id)
        {
            string query = @"SELECT * FROM Consulta WHERE Id = @id";
            var result = await _context.Dapper.QueryAsync<ConsultaEntity>(query, new { id });
            return result.FirstOrDefault();
        }

        public async Task<List<ConsultaEntity>> GetList(int funcionarioId)
        {
            string query = @"SELECT * FROM Consulta WHERE FuncionarioId = @funcionarioId";
            var consultas = await _context.Dapper.QueryAsync<ConsultaEntity>(query, new { funcionarioId });
            return consultas.ToList();
        }
        public async Task Adicionar(ConsultaEntity entity)
        {
            string query = @"
                INSERT INTO Consulta (PacienteId, FuncionarioId, Data, Descricao, Cadastro, Modificacao, Ativo)
                VALUES (@PacienteId, @FuncionarioId, @Data, @Descricao, GETDATE(), GETDATE(), 1)
            ";
            await _context.Dapper.ExecuteAsync(query, new
            {
                entity.PacienteId,
                entity.FuncionarioId,
                entity.Data,
                entity.Descricao
            });
        }
    }
}
