using Domain.Core.Commands.Paciente;
using Domain.Core.Entities;
using Domain.Core.Enums;
using Domain.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Domain.Core.Handlers.Paciente
{
    public class CreatePacienteCommandHandler(
        ICredenciaisRepository credenciaisRepository,
        IFuncionariosRepository funcionariosRepository,
        IPacienteRepository pacienteRepository
        )
    {
        public async Task Handle(CreatePacienteCommand command)
        {
            var credenciais = await credenciaisRepository.GetByLogin(command.user, command.pass);
            if (credenciais == null) throw new Exception("Login incorreto");

            var funcionario = await funcionariosRepository.Get(credenciais.FuncionarioId);
            if (funcionario == null) throw new Exception("Não existe funcionario relacionado ao Login");

            var entity = new PacienteEntity()
            {
                Nome = command.Nome,
                Nascimento = command.Nascimento,
                Sangue = command.Sangue,
                Sexo = command.Sexo,
                PlanoSaude = command.PlanoSaude,
                TelefoneCelular = command.TelefoneCelular,
                Email = command.Email,
                Logradouro = command.Logradouro,
                Numero = command.Numero,
                Complemento = command.Complemento,
                Cidade = command.Cidade,
                Estado = command.Estado,
                CEP = command.CEP
            };
            await pacienteRepository.Cadastro(entity);
        }
    }
}
