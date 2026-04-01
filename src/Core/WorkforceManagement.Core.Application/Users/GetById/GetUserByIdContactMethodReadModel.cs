namespace WorkforceManagement.Core.Application.Users.GetById
{
    public sealed class GetUserByIdContactMethodReadModel
    {
        public GetUserByIdContactMethodReadModel(
            int id,
            string type,
            string value,
            bool isPrimary)
        {
            Id = id;
            Type = type;
            Value = value;
            IsPrimary = isPrimary;
        }

        public int Id { get; }
        public string Type { get; }
        public string Value { get; }
        public bool IsPrimary { get; }
    }
}
