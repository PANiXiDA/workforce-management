using System.ComponentModel.DataAnnotations;

namespace Example.Presentation.Http.Features.Users.Search
{
    public sealed class SearchUsersRequest
    {
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(256)]
        public string Email { get; set; }
    }
}
