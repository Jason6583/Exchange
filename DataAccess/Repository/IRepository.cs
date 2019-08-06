namespace DataAccess.Repository
{
    public interface IRepository<T> : IReadOnlyRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
    }
}
