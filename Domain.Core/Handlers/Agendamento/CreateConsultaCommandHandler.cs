using Domain.Core.Commands.Agendamento;
using Domain.Core.Entities;
using Domain.Core.Enums;
using Domain.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Domain.Core.Handlers.Agendamento
{
    public class CreateConsultaCommandHandler(
        ICredenciaisRepository credenciaisRepository, 
        IFuncionariosRepository funcionariosRepository,
        IPacienteRepository pacienteRepository,
        IConsultaRepository consultaRepository
        )
    {
        public async Task Handle(CreateConsultaCommand command)
        {
            var credenciais = await credenciaisRepository.GetByLogin(command.user, command.pass);
            if (credenciais == null) throw new Exception("Login incorreto");

            var funcionario = await funcionariosRepository.Get(credenciais.FuncionarioId);
            if (funcionario == null) throw new Exception("Não existe funcionario relacionado ao Login");
            if (funcionario.TipoFuncionario != FuncionarioTypeEnum.Medico) throw new Exception("Este funcionario não tem permissão para criar consulta");

            int pacienteId = command.Paciente.Id;
            if (pacienteId == 0) pacienteId = await pacienteRepository.Cadastro(command.Paciente);

            var entity = new Consulta() 
            {
                Descricao = command.Descricao,
                PacienteId = pacienteId,
                FuncionarioId = funcionario.Id,
                Data = command.Data
            };

            await consultaRepository.Adicionar(entity);
        }
    }
}
