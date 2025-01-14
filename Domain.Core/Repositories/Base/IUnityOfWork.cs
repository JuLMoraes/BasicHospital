using System.Data;

namespace Domain.Core.Repositories.Base
{
    public interface IUnityOfWork
    {
        IDbTransaction GetTransaction();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
