using WorkforceManagement.Core.Domain.Organizations.Enums;

using System;

namespace WorkforceManagement.Presentation.Http.Features.Organizations
{
    internal static class OrganizationTypeParser
    {
        public static OrganizationType Parse(string value)
        {
            if (!Enum.TryParse(value, true, out OrganizationType organizationType)
                || !Enum.IsDefined(typeof(OrganizationType), organizationType))
            {
                throw new ArgumentException("OrganizationType is invalid.", nameof(value));
            }

            return organizationType;
        }

        public static OrganizationType? ParseOrNull(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            return Parse(value);
        }
    }
}
