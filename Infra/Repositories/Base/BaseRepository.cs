using Domain.Core.Repositories.Base;

namespace Infra.Repositories.Base
{
    public abstract class BaseRepository<T> : BaseRepositoryDapper<T>, IBaseRepository<T> where T : class
    {
        protected BaseRepository(DbContext aSeaContext, IUnityOfWork unityOfWork) : base(aSeaContext, unityOfWork) 
        {
        }

        public void BeginTransaction() => _unityOfWork.BeginTransaction();
        public void Commit() => _unityOfWork.Commit();
        public void RollBack() => _unityOfWork.Rollback();
    }
}
