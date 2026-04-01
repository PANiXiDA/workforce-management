using WorkforceManagement.Core.Domain.Projects;

namespace WorkforceManagement.Core.Application.Projects.GetById
{
    internal static class GetProjectByIdReadModelMapper
    {
        public static GetProjectByIdReadModel ToReadModel(Project project)
        {
            return new GetProjectByIdReadModel(
                project.Id,
                project.Name,
                project.StartDate,
                project.EndDate,
                new GetProjectByIdSettingsReadModel(
                    project.Settings.Id,
                    project.Settings.IsTimeboxed,
                    project.Settings.IterationLengthDays));
        }
    }
}
