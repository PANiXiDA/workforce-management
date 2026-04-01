using WorkforceManagement.Core.Application.Projects.Search;

using System.Collections.Generic;
using System.Linq;

namespace WorkforceManagement.Presentation.Http.Features.Projects.Search
{
    public static class SearchProjectsMapper
    {
        public static SearchProjectsQuery ToQuery(SearchProjectsRequest request)
        {
            return new SearchProjectsQuery(request.Name, request.IsTimeboxed);
        }

        public static SearchProjectsResponse ToResponse(IReadOnlyCollection<SearchProjectReadModel> projects)
        {
            return new SearchProjectsResponse
            {
                Items = projects
                    .Select(
                        project => new SearchProjectsItemResponse
                        {
                            Id = project.Id,
                            Name = project.Name,
                            StartDate = project.StartDate,
                            EndDate = project.EndDate,
                            IsTimeboxed = project.IsTimeboxed
                        })
                    .ToArray()
            };
        }
    }
}
