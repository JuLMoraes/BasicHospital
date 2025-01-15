using Domain.Core.Commands;
using Domain.Core.Enums;
using Domain.Core.Repositories;
using Domain.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Core.Handlers.Agendamento
{
    public class GetConsultasCommandHandler(
        ICredenciaisRepository credenciaisRepository,
        IFuncionariosRepository funcionariosRepository,
        IConsultaRepository consultaRepository,
        IPacienteRepository pacienteRepository
        )
    {
        public async Task<List<GetConsultaCommandResult>> Handle(BaseCredentialsCommand command)
        {
            var credenciais = await credenciaisRepository.GetByLogin(command.user, command.pass);
            if (credenciais == null) throw new Exception("Login incorreto");

            var funcionario = await funcionariosRepository.Get(credenciais.FuncionarioId);
            if (funcionario == null) throw new Exception("Não existe funcionario relacionado ao Login");
            if (funcionario.TipoFuncionario != FuncionarioTypeEnum.Medico) throw new Exception("Este funcionario não tem permissão para consultar agendamentos");

            var retorno = new List<GetConsultaCommandResult>();
            var consultas = await consultaRepository.GetList(funcionario.Id);
            foreach ( var consulta in consultas)
            {
                var objRetorno = new GetConsultaCommandResult()
                {
                    Id = consulta.Id,
                    Data = consulta.Data,
                    Descricao = consulta.Descricao,
                    Paciente = pacienteRepository.GetAll(x => x.Id == consulta.PacienteId).Result.FirstOrDefault(),
                    Funcionario = funcionario,
                    Cadastro = consulta.Cadastro,
                };
                retorno.Add(objRetorno);
            }
            return retorno;
        }
    }
}
