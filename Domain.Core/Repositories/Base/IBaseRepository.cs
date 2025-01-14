namespace Domain.Core.Repositories.Base
{
    public interface IBaseRepository<T> : IBaseRepositoryEntity<T> where T : class
    {
    }
}
