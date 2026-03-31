using System.Collections.Generic;

namespace Example.Presentation.Http.Features.Users.Search
{
    public sealed class SearchUsersResponse
    {
        public IReadOnlyCollection<SearchUsersItemResponse> Items { get; set; }
    }
}
