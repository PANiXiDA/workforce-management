using WorkforceManagement.Core.Application.Users.Delete;

namespace WorkforceManagement.Presentation.Http.Features.Users.Delete
{
    public static class DeleteUserMapper
    {
        public static DeleteUserCommand ToCommand(int id)
        {
            return new DeleteUserCommand(id);
        }
    }
}
