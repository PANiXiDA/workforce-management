using System.Collections.Generic;

namespace WorkforceManagement.Presentation.Http.Features.Projects.Search
{
    public sealed class SearchProjectsResponse
    {
        public IReadOnlyCollection<SearchProjectsItemResponse> Items { get; set; }
    }
}
