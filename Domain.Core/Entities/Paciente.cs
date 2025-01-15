using Domain.Core.Enums;
using System;
using Domain.Core.Entities.Base;

namespace Domain.Core.Entities
{
    public class Paciente : BaseAuditEntity
    {
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public TipoSanguineoTypeEnum? TipoSanguineo { get; set; }
        public int Sexo { get; set; }
        public string PlanoSaude { get; set; }
        public string TelefoneCelular { get; set; }
        public string Email { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
    }
}
