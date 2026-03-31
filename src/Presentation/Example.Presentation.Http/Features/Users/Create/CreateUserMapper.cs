using Example.Core.Application.Users.Create;

namespace Example.Presentation.Http.Features.Users.Create
{
    public static class CreateUserMapper
    {
        public static CreateUserCommand ToCommand(CreateUserRequest request)
        {
            return new CreateUserCommand(
                request.FirstName,
                request.LastName,
                request.Email);
        }

        public static CreateUserResponse ToResponse(int id)
        {
            return new CreateUserResponse
            {
                Id = id
            };
        }
    }
}
