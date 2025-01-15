using Domain.Core.Commands.Paciente;
using Domain.Core.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Core.Handlers.Paciente
{
    public class GetPacienteCommandHandler(
        ICredenciaisRepository credenciaisRepository,
        IFuncionariosRepository funcionariosRepository,
        IPacienteRepository pacienteRepository
        )
    {
        public async Task<Entities.Paciente> Handle(GetPacienteCommand command)
        {
            var credenciais = await credenciaisRepository.GetByLogin(command.user, command.pass);
            if (credenciais == null) throw new Exception("Login incorreto");

            var funcionario = await funcionariosRepository.Get(credenciais.FuncionarioId);
            if (funcionario == null) throw new Exception("Não existe funcionario relacionado ao Login");

            var pacientes = await pacienteRepository.GetAll(x => x.Id == command.Id);
            return pacientes.FirstOrDefault() ;
        }
    }
}
