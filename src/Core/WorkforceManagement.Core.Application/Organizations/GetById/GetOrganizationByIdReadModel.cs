namespace WorkforceManagement.Core.Application.Organizations.GetById
{
    public sealed class GetOrganizationByIdReadModel
    {
        public GetOrganizationByIdReadModel(
            int id,
            string name,
            string organizationType,
            string partnerCode)
        {
            Id = id;
            Name = name;
            OrganizationType = organizationType;
            PartnerCode = partnerCode;
        }

        public int Id { get; }
        public string Name { get; }
        public string OrganizationType { get; }
        public string PartnerCode { get; }
    }
}
