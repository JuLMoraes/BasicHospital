using Domain.Core.Commands.Agendamento;
using Domain.Core.Enums;
using Domain.Core.Repositories;
using Domain.Core.Results;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Core.Handlers.Agendamento
{
    public class GetConsultaCommandHandler(
        ICredenciaisRepository credenciaisRepository,
        IFuncionariosRepository funcionariosRepository,
        IConsultaRepository consultaRepository,
        IPacienteRepository pacienteRepository
        )
    {
        public async Task<GetConsultaCommandResult> Handle(GetConsultaCommand command)
        {
            var credenciais = await credenciaisRepository.GetByLogin(command.user, command.pass);
            if (credenciais == null) throw new Exception("Login incorreto");

            var funcionario = await funcionariosRepository.Get(credenciais.FuncionarioId);
            if (funcionario == null) throw new Exception("Não existe funcionario relacionado ao Login");
            if (funcionario.TipoFuncionario != FuncionarioTypeEnum.Medico) throw new Exception("Este funcionario não tem permissão para consultar agendamentos");

            var consulta = consultaRepository.GetAll(x => x.Id == command.Id).Result.FirstOrDefault();
            if (consulta.FuncionarioId != funcionario.Id) throw new Exception("Este usuário não tem permissão para vizualizar essa consulta");
            var objRetorno = new GetConsultaCommandResult()
            {
                Id = consulta.Id,
                Data = consulta.Data,
                Descricao = consulta.Descricao,
                Paciente = pacienteRepository.GetAll(x => x.Id == consulta.PacienteId).Result.FirstOrDefault(),
                Funcionario = funcionario,
                Cadastro = consulta.Cadastro,
                Modificacao = consulta.Modificacao,
                Ativo = consulta.Ativo,
            };
            return objRetorno;
        }
    }
}
