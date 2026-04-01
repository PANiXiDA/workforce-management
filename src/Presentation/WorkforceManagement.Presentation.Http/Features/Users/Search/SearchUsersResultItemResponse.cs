namespace WorkforceManagement.Presentation.Http.Features.Users.Search
{
    public sealed class SearchUsersResultItemResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int OrganizationId { get; set; }
        public string EmploymentType { get; set; }
        public int PlannedWeeklyHours { get; set; }
    }
}
