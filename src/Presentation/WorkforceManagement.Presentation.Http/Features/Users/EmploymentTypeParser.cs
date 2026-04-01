using WorkforceManagement.Core.Domain.Users.Enums;

using System;

namespace WorkforceManagement.Presentation.Http.Features.Users
{
    internal static class EmploymentTypeParser
    {
        public static EmploymentType Parse(string value)
        {
            if (!Enum.TryParse(value, true, out EmploymentType employmentType)
                || !Enum.IsDefined(typeof(EmploymentType), employmentType))
            {
                throw new ArgumentException("EmploymentType is invalid.", nameof(value));
            }

            return employmentType;
        }

        public static EmploymentType? ParseOrNull(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            return Parse(value);
        }
    }
}
