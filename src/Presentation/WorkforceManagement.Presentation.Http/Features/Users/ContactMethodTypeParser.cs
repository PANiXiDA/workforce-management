using WorkforceManagement.Core.Domain.Users.Enums;

using System;

namespace WorkforceManagement.Presentation.Http.Features.Users
{
    internal static class ContactMethodTypeParser
    {
        public static ContactMethodType Parse(string value)
        {
            if (!Enum.TryParse(value, true, out ContactMethodType contactMethodType)
                || !Enum.IsDefined(typeof(ContactMethodType), contactMethodType))
            {
                throw new ArgumentException("Contact method type is invalid.", nameof(value));
            }

            return contactMethodType;
        }
    }
}
