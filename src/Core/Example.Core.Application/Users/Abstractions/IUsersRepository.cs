using Example.Core.Domain;

namespace Example.Core.Application.Users.Abstractions
{
    public interface IUsersRepository
    {
        void Add(User user);
        User GetById(int id);
        void Update(User user);
        void Delete(User user);
    }
}
