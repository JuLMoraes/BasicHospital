using Domain.Core.Entities;
using System;

namespace Domain.Core.Results
{
    public class GetConsultaCommandResult
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public DateTime Cadastro { get; set; }
        public DateTime Modificacao { get; set; }
        public bool Ativo { get; set; }
        public PacienteEntity Paciente { get; set; }
        public FuncionarioEntity Funcionario { get; set; }
    }
}
