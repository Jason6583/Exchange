namespace DataAccess.Repository
{
    public interface IReadOnlyRepository<T>
    {
        T Find(params object[] keys);
    }
}
