using Example.Core.Application.Users;
using Example.Core.Application.Users.Search;

using System.Collections.Generic;
using System.Linq;

namespace Example.Presentation.Http.Features.Users.Search
{
    public static class SearchUsersMapper
    {
        public static SearchUsersQuery ToQuery(SearchUsersRequest request)
        {
            return new SearchUsersQuery(
                request.FirstName,
                request.LastName,
                request.Email);
        }

        public static SearchUsersResponse ToResponse(IReadOnlyCollection<UserReadModel> users)
        {
            return new SearchUsersResponse
            {
                Items = users
                    .Select(user => new SearchUsersItemResponse
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email
                    })
                    .ToArray()
            };
        }
    }
}
