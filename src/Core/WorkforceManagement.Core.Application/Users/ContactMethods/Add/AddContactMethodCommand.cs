using WorkforceManagement.Core.Domain.Users.Enums;

using MediatR;

namespace WorkforceManagement.Core.Application.Users.ContactMethods.Add
{
    public sealed class AddContactMethodCommand : IRequest<int>
    {
        public AddContactMethodCommand(
            int userId,
            ContactMethodType type,
            string value,
            bool isPrimary)
        {
            UserId = userId;
            Type = type;
            Value = value;
            IsPrimary = isPrimary;
        }

        public int UserId { get; }
        public ContactMethodType Type { get; }
        public string Value { get; }
        public bool IsPrimary { get; }
    }
}
