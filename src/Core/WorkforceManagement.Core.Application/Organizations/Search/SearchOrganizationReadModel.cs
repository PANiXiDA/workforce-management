namespace WorkforceManagement.Core.Application.Organizations.Search
{
    public sealed class SearchOrganizationReadModel
    {
        public SearchOrganizationReadModel(
            int id,
            string name,
            string organizationType)
        {
            Id = id;
            Name = name;
            OrganizationType = organizationType;
        }

        public int Id { get; }
        public string Name { get; }
        public string OrganizationType { get; }
    }
}
