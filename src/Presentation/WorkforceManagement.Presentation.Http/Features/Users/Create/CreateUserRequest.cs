using System;
using System.ComponentModel.DataAnnotations;

namespace WorkforceManagement.Presentation.Http.Features.Users.Create
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

        public int OrganizationId { get; set; }

        [Required]
        [StringLength(50)]
        public string EmploymentType { get; set; }

        public int PlannedWeeklyHours { get; set; }

        [Required]
        public CreateUserEmploymentProfileRequest EmploymentProfile { get; set; }
    }

    public sealed class CreateUserEmploymentProfileRequest
    {
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string PositionTitle { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime? ProbationEndDate { get; set; }
    }
}
