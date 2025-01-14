using System.ComponentModel;

namespace Domain.Core.Enums
{
    public enum FuncionarioTypeEnum
    {
        [Description("Médico")]
        Medico = 1,
        [Description("Assistente")]
        Assistente = 2
    }
}
