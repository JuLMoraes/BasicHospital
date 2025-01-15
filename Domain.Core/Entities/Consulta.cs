using Domain.Core.Entities.Base;
using System;

namespace Domain.Core.Entities
{
    public class Consulta : BaseAuditEntity
    {
        public int PacienteId { get; set; }
        public int FuncionarioId { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
    }
}
