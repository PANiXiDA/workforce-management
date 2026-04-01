using WorkforceManagement.Core.Application.Organizations.Search;
using WorkforceManagement.Presentation.Http.Features.Organizations;

using System.Collections.Generic;
using System.Linq;

namespace WorkforceManagement.Presentation.Http.Features.Organizations.Search
{
    public static class SearchOrganizationsMapper
    {
        public static SearchOrganizationsQuery ToQuery(SearchOrganizationsRequest request)
        {
            return new SearchOrganizationsQuery(
                request.Name,
                OrganizationTypeParser.ParseOrNull(request.OrganizationType));
        }

        public static SearchOrganizationsResponse ToResponse(IReadOnlyCollection<SearchOrganizationReadModel> organizations)
        {
            return new SearchOrganizationsResponse
            {
                Items = organizations
                    .Select(
                        organization => new SearchOrganizationsItemResponse
                        {
                            Id = organization.Id,
                            Name = organization.Name,
                            OrganizationType = organization.OrganizationType
                        })
                    .ToArray()
            };
        }
    }
}
