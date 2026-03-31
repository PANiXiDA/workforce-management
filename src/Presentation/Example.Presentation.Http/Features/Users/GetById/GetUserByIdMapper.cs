using Example.Core.Application.Users;

namespace Example.Presentation.Http.Features.Users.GetById
{
    public static class GetUserByIdMapper
    {
        public static GetUserByIdResponse ToResponse(UserReadModel user)
        {
            return new GetUserByIdResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }
    }
}
