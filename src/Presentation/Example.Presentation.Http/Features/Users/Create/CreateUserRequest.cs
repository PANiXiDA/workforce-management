using System.ComponentModel.DataAnnotations;

namespace Example.Presentation.Http.Features.Users.Create
{
    public sealed class CreateUserRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }
    }
}
