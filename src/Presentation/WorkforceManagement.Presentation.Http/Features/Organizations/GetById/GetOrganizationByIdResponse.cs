namespace WorkforceManagement.Presentation.Http.Features.Organizations.GetById
{
    public sealed class GetOrganizationByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OrganizationType { get; set; }
        public string PartnerCode { get; set; }
    }
}
