using Domain.Core.Entities.Base;
using Domain.Core.Enums;
using System.Collections.Generic;

namespace Domain.Core.Entities
{
    public class Funcionario : BaseEntity
    {
        public string Nome { get; set; }
        public FuncionarioTypeEnum TipoFuncionario { get; set; }
        public TipoSanguineoTypeEnum TipoSangue { get; set; }
    }
}
