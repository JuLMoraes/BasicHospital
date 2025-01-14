using System;

namespace Domain.Core.Entities.Base
{
    public class BaseAuditEntity : BaseEntity
    {
        public DateTime Cadastro { get; set; }
        public DateTime Modificacao { get; set; }
        public bool Ativo { get; set; }
    }
}
