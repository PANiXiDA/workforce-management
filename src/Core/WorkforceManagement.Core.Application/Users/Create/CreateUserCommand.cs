using WorkforceManagement.Core.Domain.Users.Enums;

using MediatR;

using System;

namespace WorkforceManagement.Core.Application.Users.Create
{
    public sealed class CreateUserCommand : IRequest<int>
    {
        public CreateUserCommand(
            string firstName,
            string lastName,
            string email,
            int organizationId,
            EmploymentType employmentType,
            int plannedWeeklyHours,
            string positionTitle,
            DateTime hireDate,
            DateTime? probationEndDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            OrganizationId = organizationId;
            EmploymentType = employmentType;
            PlannedWeeklyHours = plannedWeeklyHours;
            PositionTitle = positionTitle;
            HireDate = hireDate;
            ProbationEndDate = probationEndDate;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public int OrganizationId { get; }
        public EmploymentType EmploymentType { get; }
        public int PlannedWeeklyHours { get; }
        public string PositionTitle { get; }
        public DateTime HireDate { get; }
        public DateTime? ProbationEndDate { get; }
    }
}
