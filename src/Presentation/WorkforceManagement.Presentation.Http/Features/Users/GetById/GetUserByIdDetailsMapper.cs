using WorkforceManagement.Core.Application.Users.GetById;

using System.Linq;

namespace WorkforceManagement.Presentation.Http.Features.Users.GetById
{
    public static class GetUserByIdDetailsMapper
    {
        public static GetUserByIdDetailsResponse ToResponse(GetUserByIdReadModel user)
        {
            return new GetUserByIdDetailsResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                OrganizationId = user.OrganizationId,
                EmploymentType = user.EmploymentType,
                PlannedWeeklyHours = user.PlannedWeeklyHours,
                EmploymentProfile = new GetUserByIdEmploymentProfileDetailsResponse
                {
                    Id = user.EmploymentProfile.Id,
                    PositionTitle = user.EmploymentProfile.PositionTitle,
                    HireDate = user.EmploymentProfile.HireDate,
                    ProbationEndDate = user.EmploymentProfile.ProbationEndDate
                },
                ContactMethods = user.ContactMethods
                    .Select(
                        contactMethod => new GetUserByIdContactMethodDetailsResponse
                        {
                            Id = contactMethod.Id,
                            Type = contactMethod.Type,
                            Value = contactMethod.Value,
                            IsPrimary = contactMethod.IsPrimary
                        })
                    .ToArray()
            };
        }
    }
}
