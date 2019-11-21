using Entity;

namespace DataAccess.Repository
{
    public interface IUserCredentialReadOnlyRepository : IReadOnlyRepository<UserCredentials>
    {
        UserCredentials GetByEmailOrPhone(string emailOrPhone);
    }
}
