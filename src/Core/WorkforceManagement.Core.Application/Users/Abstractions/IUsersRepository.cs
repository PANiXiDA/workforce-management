using WorkforceManagement.Core.Domain.Users;
using WorkforceManagement.Core.Domain.Users.Enums;

using System.Collections.Generic;

namespace WorkforceManagement.Core.Application.Users.Abstractions
{
    public interface IUsersRepository
    {
        IReadOnlyCollection<User> Search(
            string firstName,
            string lastName,
            string email,
            int? organizationId,
            EmploymentType? employmentType);

        User GetById(int id);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
