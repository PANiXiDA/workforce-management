using System.ComponentModel.DataAnnotations;

namespace WorkforceManagement.Presentation.Http.Features.Organizations.Update
{
    public sealed class UpdateOrganizationRequest
    {
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string OrganizationType { get; set; }

        [StringLength(50)]
        public string PartnerCode { get; set; }
    }
}
