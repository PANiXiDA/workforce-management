using Example.Core.Application.Users.Update;

namespace Example.Presentation.Http.Features.Users.Update
{
    public static class UpdateUserMapper
    {
        public static UpdateUserCommand ToCommand(int id, UpdateUserRequest request)
        {
            return new UpdateUserCommand(
                id,
                request.FirstName,
                request.LastName,
                request.Email);
        }
    }
}
