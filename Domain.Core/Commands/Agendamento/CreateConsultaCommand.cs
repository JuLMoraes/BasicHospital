using Domain.Core.Entities;
using System;

namespace Domain.Core.Commands.Agendamento
{
    public class CreateConsultaCommand : BaseCredentialsCommand
    {
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public PacienteEntity Paciente { get; set; }
    }
}
