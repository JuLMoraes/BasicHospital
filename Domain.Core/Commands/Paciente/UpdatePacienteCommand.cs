namespace Domain.Core.Commands.Paciente
{
    public class UpdatePacienteCommand : CreatePacienteCommand
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
    }
}
