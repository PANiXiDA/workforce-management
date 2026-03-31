using Example.Core.Application.Users.Delete;

namespace Example.Presentation.Http.Features.Users.Delete
{
    public static class DeleteUserMapper
    {
        public static DeleteUserCommand ToCommand(int id)
        {
            return new DeleteUserCommand(id);
        }
    }
}
