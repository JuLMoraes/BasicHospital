using Domain.Core.Repositories.Base;

namespace Infra.Repositories.Base
{
    public abstract class BaseRepositoryDapper<T> : BaseRepositoryEntity<T>, IBaseRepositoryDapper<T> where T : class
    {
        protected readonly IUnityOfWork _unityOfWork;

        protected BaseRepositoryDapper(DbContext aSeaContext, IUnityOfWork unityOfWork) : base(aSeaContext)
        {
            _unityOfWork = unityOfWork;
        }
    }
}
