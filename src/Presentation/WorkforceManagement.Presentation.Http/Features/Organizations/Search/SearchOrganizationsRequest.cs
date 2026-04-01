using System.ComponentModel.DataAnnotations;

namespace WorkforceManagement.Presentation.Http.Features.Organizations.Search
{
    public sealed class SearchOrganizationsRequest
    {
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(50)]
        public string OrganizationType { get; set; }
    }
}
