using Entity;

namespace DataAccess.Repository
{
    public interface IUserCredentialRepository : IRepository<UserCredentials> , IUserCredentialReadOnlyRepository
    {
    }
}
