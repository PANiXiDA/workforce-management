using WorkforceManagement.Core.Application.Organizations.Delete;

namespace WorkforceManagement.Presentation.Http.Features.Organizations.Delete
{
    public static class DeleteOrganizationMapper
    {
        public static DeleteOrganizationCommand ToCommand(int id)
        {
            return new DeleteOrganizationCommand(id);
        }
    }
}
