using WorkforceManagement.Core.Domain.Users.Enums;

using MediatR;

using System;

namespace WorkforceManagement.Core.Application.Users.Update
{
    public sealed class UpdateUserCommand : IRequest
    {
        public UpdateUserCommand(
            int id,
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
            Id = id;
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

        public int Id { get; }
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
