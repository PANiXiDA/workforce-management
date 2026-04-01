using System.Collections.Generic;

namespace WorkforceManagement.Core.Application.Users.GetById
{
    public sealed class GetUserByIdReadModel
    {
        public GetUserByIdReadModel(
            int id,
            string firstName,
            string lastName,
            string email,
            int organizationId,
            string employmentType,
            int plannedWeeklyHours,
            GetUserByIdEmploymentProfileReadModel employmentProfile,
            IReadOnlyCollection<GetUserByIdContactMethodReadModel> contactMethods)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            OrganizationId = organizationId;
            EmploymentType = employmentType;
            PlannedWeeklyHours = plannedWeeklyHours;
            EmploymentProfile = employmentProfile;
            ContactMethods = contactMethods;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public int OrganizationId { get; }
        public string EmploymentType { get; }
        public int PlannedWeeklyHours { get; }
        public GetUserByIdEmploymentProfileReadModel EmploymentProfile { get; }
        public IReadOnlyCollection<GetUserByIdContactMethodReadModel> ContactMethods { get; }
    }
}
