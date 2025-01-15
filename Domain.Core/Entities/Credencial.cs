using Domain.Core.Entities.Base;

namespace Domain.Core.Entities
{
    public class Credencial : BaseEntity
    {
        public int FuncionarioId { get; set; }
        public int GrupoAcesso { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
