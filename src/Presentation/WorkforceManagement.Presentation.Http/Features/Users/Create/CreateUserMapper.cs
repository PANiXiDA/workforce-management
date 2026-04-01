using WorkforceManagement.Core.Application.Users.Create;
using WorkforceManagement.Presentation.Http.Features.Users;

namespace WorkforceManagement.Presentation.Http.Features.Users.Create
{
    public static class CreateUserMapper
    {
        public static CreateUserCommand ToCommand(CreateUserRequest request)
        {
            return new CreateUserCommand(
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

        public static CreateUserResponse ToResponse(int id)
        {
            return new CreateUserResponse
            {
                Id = id
            };
        }
    }
}
