using System.ComponentModel.DataAnnotations;

namespace WorkforceManagement.Presentation.Http.Features.Users.Search
{
    public sealed class SearchUsersFiltersRequest
    {
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        public int? OrganizationId { get; set; }

        [StringLength(50)]
        public string EmploymentType { get; set; }
    }
}
