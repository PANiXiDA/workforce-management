using WorkforceManagement.Core.Application.Users.Search;
using WorkforceManagement.Presentation.Http.Features.Users;

using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkforceManagement.Presentation.Http.Features.Users.Search
{
    public static class SearchUsersResultMapper
    {
        public static SearchUsersQuery ToQuery(SearchUsersFiltersRequest request)
        {
            if (request.OrganizationId.HasValue && request.OrganizationId.Value <= 0)
            {
                throw new ArgumentException("OrganizationId must be greater than zero.", nameof(request.OrganizationId));
            }

            return new SearchUsersQuery(
                request.FirstName,
                request.LastName,
                request.Email,
                request.OrganizationId,
                EmploymentTypeParser.ParseOrNull(request.EmploymentType));
        }

        public static SearchUsersResultResponse ToResponse(IReadOnlyCollection<SearchUserReadModel> users)
        {
            return new SearchUsersResultResponse
            {
                Items = users
                    .Select(
                        user => new SearchUsersResultItemResponse
                        {
                            Id = user.Id,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Email = user.Email,
                            OrganizationId = user.OrganizationId,
                            EmploymentType = user.EmploymentType,
                            PlannedWeeklyHours = user.PlannedWeeklyHours
                        })
                    .ToArray()
            };
        }
    }
}
