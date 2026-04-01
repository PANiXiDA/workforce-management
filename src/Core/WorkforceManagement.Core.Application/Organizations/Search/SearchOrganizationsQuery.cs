using WorkforceManagement.Core.Domain.Organizations.Enums;

using MediatR;

using System.Collections.Generic;

namespace WorkforceManagement.Core.Application.Organizations.Search
{
    public sealed class SearchOrganizationsQuery : IRequest<IReadOnlyCollection<SearchOrganizationReadModel>>
    {
        public SearchOrganizationsQuery(
            string name,
            OrganizationType? organizationType)
        {
            Name = name;
            OrganizationType = organizationType;
        }

        public string Name { get; }
        public OrganizationType? OrganizationType { get; }
    }
}
