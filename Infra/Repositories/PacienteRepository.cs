using Dapper;
using Domain.Core.Commands.Paciente;
using Domain.Core.Entities;
using Domain.Core.Repositories;
using Domain.Core.Repositories.Base;
using Infra.Repositories.Base;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class PacienteRepository : BaseRepository<PacienteEntity>, IPacienteRepository
    {
        public PacienteRepository(DbContext aSeaContext, IUnityOfWork unityOfWork) : base(aSeaContext, unityOfWork)
        {
        }

        public async Task<PacienteEntity> GetById(int id)
        {
            string query = @"SELECT * FROM Paciente WHERE Id = @id";
            var retorno = await _context.Dapper.QueryAsync<PacienteEntity>(query, new { id });
            return retorno.FirstOrDefault();
        }

        public async Task<int> Cadastro(PacienteEntity command)
        {
            string query = @"
                INSERT INTO Paciente (Nome, Nascimento, TipoSanguineo, Sexo, PlanoSaude, TelefoneCelular, Email, Logradouro, Numero, Complemento, 
                    Cidade, Estado, CEP, Cadastro, Modificacao, Ativo)
                OUTPUT Inserted.*
                VALUES (@Nome, @Nascimento, @Sangue, @Sexo, @PlanoSaude, @TelefoneCelular, @Email, @Logradouro, @Numero, @Complemento, 
                    @Cidade, @Estado, @CEP, GETDATE(), GETDATE(), 1)
            ";
            var retorno = await _context.Dapper.QueryAsync<PacienteEntity>(query, new 
            { 
                command.Nome,
                command.Nascimento,
                command.Sangue,
                command.Sexo,
                command.PlanoSaude,
                command.TelefoneCelular,
                command.Email,
                command.Logradouro,
                command.Numero,
                command.Complemento,
                command.Cidade,
                command.Estado,
                command.CEP,
            });
            return retorno.FirstOrDefault().Id;
        }

        public async Task<PacienteEntity> Update(UpdatePacienteCommand command)
        {
            string query = @"
                UPDATE Paciente SET Nome = @Nome, Nascimento = @Nascimento, TipoSanguineo = @Sangue, Sexo = @Sexo, PlanoSaude = @PlanoSaude, 
                    TelefoneCelular = @TelefoneCelular, Email = @Email, Logradouro = @Logradouro, Numero = @Numero, Complemento = @Complemento,
                    Cidade = @Cidade, Estado = @Estado, CEP = @CEP, Modificacao = GETDATE(), Ativo = @Ativo
                WHERE Id = @Id

                SELECT * FROM Paciente WHERE Id = @Id
            ";
            var retorno = await _context.Dapper.QueryAsync<PacienteEntity>(query, new
            {
                command.Id,
                command.Nome,
                command.Nascimento,
                command.Sangue,
                command.Sexo,
                command.PlanoSaude,
                command.TelefoneCelular,
                command.Email,
                command.Logradouro,
                command.Numero,
                command.Complemento,
                command.Cidade,
                command.Estado,
                command.CEP,
                command.Ativo,
            });
            return retorno.FirstOrDefault();
        }
    }
}
