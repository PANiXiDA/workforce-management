using System.Collections.Generic;

namespace WorkforceManagement.Presentation.Http.Features.Organizations.Search
{
    public sealed class SearchOrganizationsResponse
    {
        public IReadOnlyCollection<SearchOrganizationsItemResponse> Items { get; set; }
    }
}
