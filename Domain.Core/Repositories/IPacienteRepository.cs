using Domain.Core.Commands.Paciente;
using Domain.Core.Entities;
using Domain.Core.Repositories.Base;
using System.Threading.Tasks;

namespace Domain.Core.Repositories
{
    public interface IPacienteRepository : IBaseRepository<Paciente>
    {
        Task<int> Cadastro(Paciente command);
        Task<Paciente> Update(UpdatePacienteCommand command);
    }
}
