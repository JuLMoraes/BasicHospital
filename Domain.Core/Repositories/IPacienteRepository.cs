using Domain.Core.Commands.Paciente;
using Domain.Core.Entities;
using Domain.Core.Repositories.Base;
using System.Threading.Tasks;

namespace Domain.Core.Repositories
{
    public interface IPacienteRepository : IBaseRepository<PacienteEntity>
    {
        Task<PacienteEntity> GetById(int id);
        Task<int> Cadastro(PacienteEntity command);
        Task<PacienteEntity> Update(UpdatePacienteCommand command);
    }
}
