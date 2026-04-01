using System.ComponentModel.DataAnnotations;

namespace WorkforceManagement.Presentation.Http.Features.Users.ContactMethods.Update
{
    public sealed class UpdateContactMethodRequest
    {
        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Value { get; set; }

        public bool IsPrimary { get; set; }
    }
}
