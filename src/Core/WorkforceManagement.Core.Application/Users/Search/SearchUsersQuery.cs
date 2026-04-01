using WorkforceManagement.Core.Domain.Users.Enums;

using MediatR;

using System.Collections.Generic;

namespace WorkforceManagement.Core.Application.Users.Search
{
    public sealed class SearchUsersQuery : IRequest<IReadOnlyCollection<SearchUserReadModel>>
    {
        public SearchUsersQuery(
            string firstName,
            string lastName,
            string email,
            int? organizationId,
            EmploymentType? employmentType)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            OrganizationId = organizationId;
            EmploymentType = employmentType;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public int? OrganizationId { get; }
        public EmploymentType? EmploymentType { get; }
    }
}
