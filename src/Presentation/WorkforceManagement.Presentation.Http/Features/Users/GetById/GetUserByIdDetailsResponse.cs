using System;
using System.Collections.Generic;

namespace WorkforceManagement.Presentation.Http.Features.Users.GetById
{
    public sealed class GetUserByIdDetailsResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int OrganizationId { get; set; }
        public string EmploymentType { get; set; }
        public int PlannedWeeklyHours { get; set; }
        public GetUserByIdEmploymentProfileDetailsResponse EmploymentProfile { get; set; }
        public IReadOnlyCollection<GetUserByIdContactMethodDetailsResponse> ContactMethods { get; set; }
    }

    public sealed class GetUserByIdEmploymentProfileDetailsResponse
    {
        public int Id { get; set; }
        public string PositionTitle { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? ProbationEndDate { get; set; }
    }

    public sealed class GetUserByIdContactMethodDetailsResponse
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool IsPrimary { get; set; }
    }
}
