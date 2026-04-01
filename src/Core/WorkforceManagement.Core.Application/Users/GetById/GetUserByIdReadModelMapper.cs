using WorkforceManagement.Core.Domain.Users;

using System.Linq;

namespace WorkforceManagement.Core.Application.Users.GetById
{
    internal static class GetUserByIdReadModelMapper
    {
        public static GetUserByIdReadModel ToReadModel(User user)
        {
            return new GetUserByIdReadModel(
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.OrganizationId,
                user.EmploymentType.ToString(),
                user.PlannedWeeklyHours,
                new GetUserByIdEmploymentProfileReadModel(
                    user.EmploymentProfile.Id,
                    user.EmploymentProfile.PositionTitle,
                    user.EmploymentProfile.HireDate,
                    user.EmploymentProfile.ProbationEndDate),
                user.ContactMethods
                    .Select(
                        contactMethod => new GetUserByIdContactMethodReadModel(
                            contactMethod.Id,
                            contactMethod.Type.ToString(),
                            contactMethod.Value,
                            contactMethod.IsPrimary))
                    .ToArray());
        }
    }
}
