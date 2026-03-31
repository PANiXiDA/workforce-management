using Example.Core.Domain.Users;

namespace Example.Core.Application.Users
{
    internal static class UserReadModelMapper
    {
        public static UserReadModel ToReadModel(User user)
        {
            return new UserReadModel(
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email);
        }
    }
}
