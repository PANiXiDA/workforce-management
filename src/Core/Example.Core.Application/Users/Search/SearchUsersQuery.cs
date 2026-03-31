using MediatR;

using System.Collections.Generic;

namespace Example.Core.Application.Users.Search
{
    public sealed class SearchUsersQuery : IRequest<IReadOnlyCollection<UserReadModel>>
    {
        public SearchUsersQuery(
            string firstName,
            string lastName,
            string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
    }
}
