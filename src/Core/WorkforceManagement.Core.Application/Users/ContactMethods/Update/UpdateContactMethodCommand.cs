using WorkforceManagement.Core.Domain.Users.Enums;

using MediatR;

namespace WorkforceManagement.Core.Application.Users.ContactMethods.Update
{
    public sealed class UpdateContactMethodCommand : IRequest
    {
        public UpdateContactMethodCommand(
            int userId,
            int contactMethodId,
            ContactMethodType type,
            string value,
            bool isPrimary)
        {
            UserId = userId;
            ContactMethodId = contactMethodId;
            Type = type;
            Value = value;
            IsPrimary = isPrimary;
        }

        public int UserId { get; }
        public int ContactMethodId { get; }
        public ContactMethodType Type { get; }
        public string Value { get; }
        public bool IsPrimary { get; }
    }
}
