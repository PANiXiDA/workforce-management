using WorkforceManagement.Core.Domain.Projects;

namespace WorkforceManagement.Core.Application.Projects.Search
{
    internal static class SearchProjectReadModelMapper
    {
        public static SearchProjectReadModel ToReadModel(Project project)
        {
            return new SearchProjectReadModel(
                project.Id,
                project.Name,
                project.StartDate,
                project.EndDate,
                project.Settings.IsTimeboxed);
        }
    }
}
