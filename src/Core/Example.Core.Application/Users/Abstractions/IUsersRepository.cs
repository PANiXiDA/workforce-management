using Example.Core.Domain.Users;

using System.Collections.Generic;

namespace Example.Core.Application.Users.Abstractions
{
    public interface IUsersRepository
    {
        void Add(User user);
        User GetById(int id);
        void Update(User user);
        IReadOnlyCollection<User> Search(string firstName, string lastName, string email);
        void Delete(User user);
    }
}
