using WorkforceManagement.Core.Application.Users.Update;
using WorkforceManagement.Presentation.Http.Features.Users;

namespace WorkforceManagement.Presentation.Http.Features.Users.Update
{
    public static class UpdateUserDetailsMapper
    {
        public static UpdateUserCommand ToCommand(int id, UpdateUserDetailsRequest request)
        {
            return new UpdateUserCommand(
                id,
                request.FirstName,
                request.LastName,
                request.Email,
                request.OrganizationId,
                EmploymentTypeParser.Parse(request.EmploymentType),
                request.PlannedWeeklyHours,
                request.EmploymentProfile.PositionTitle,
                request.EmploymentProfile.HireDate,
                request.EmploymentProfile.ProbationEndDate);
        }
    }
}
