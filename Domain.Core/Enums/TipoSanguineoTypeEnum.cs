using System.ComponentModel;

namespace Domain.Core.Enums
{
    public enum TipoSanguineoTypeEnum
    {
        [Description("Tipo A+")]
        Apos = 1,
        [Description("Tipo B+")]
        Bpos = 2,
        [Description("Tipo AB+")]
        ABpos = 3,
        [Description("Tipo O+")]
        Opos = 4,
        [Description("Tipo A-")]
        Aneg = 5,
        [Description("Tipo B-")]
        Bneg = 6,
        [Description("Tipo AB-")]
        ABneg = 7,
        [Description("Tipo O-")]
        Oneg = 8,
    }
}
