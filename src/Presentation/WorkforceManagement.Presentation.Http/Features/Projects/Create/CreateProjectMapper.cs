using WorkforceManagement.Core.Application.Projects.Create;

namespace WorkforceManagement.Presentation.Http.Features.Projects.Create
{
    public static class CreateProjectMapper
    {
        public static CreateProjectCommand ToCommand(CreateProjectRequest request)
        {
            return new CreateProjectCommand(
                request.Name,
                request.StartDate,
                request.EndDate,
                request.Settings.IsTimeboxed,
                request.Settings.IterationLengthDays);
        }

        public static CreateProjectResponse ToResponse(int id)
        {
            return new CreateProjectResponse
            {
                Id = id
            };
        }
    }
}
