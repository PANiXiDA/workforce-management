namespace WorkforceManagement.Core.Application.Users.Search
{
    public sealed class SearchUserReadModel
    {
        public SearchUserReadModel(
            int id,
            string firstName,
            string lastName,
            string email,
            int organizationId,
            string employmentType,
            int plannedWeeklyHours)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            OrganizationId = organizationId;
            EmploymentType = employmentType;
            PlannedWeeklyHours = plannedWeeklyHours;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public int OrganizationId { get; }
        public string EmploymentType { get; }
        public int PlannedWeeklyHours { get; }
    }
}
