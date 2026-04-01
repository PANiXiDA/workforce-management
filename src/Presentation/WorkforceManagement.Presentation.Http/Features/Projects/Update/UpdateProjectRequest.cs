using System;
using System.ComponentModel.DataAnnotations;

namespace WorkforceManagement.Presentation.Http.Features.Projects.Update
{
    public sealed class UpdateProjectRequest
    {
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public UpdateProjectSettingsRequest Settings { get; set; }
    }
}
