using WorkforceManagement.Core.Application.Projects.Delete;

namespace WorkforceManagement.Presentation.Http.Features.Projects.Delete
{
    public static class DeleteProjectMapper
    {
        public static DeleteProjectCommand ToCommand(int id)
        {
            return new DeleteProjectCommand(id);
        }
    }
}
