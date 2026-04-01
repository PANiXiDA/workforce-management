using WorkforceManagement.Core.Domain.Users.Enums;

using System;

namespace WorkforceManagement.Core.Domain.Users.Entities
{
    public sealed class ContactMethod
    {
        private const int MaxValueLength = 200;

        private ContactMethod(
            int id,
            ContactMethodType type,
            string value,
            bool isPrimary)
        {
            Id = id;
            Type = type;
            Value = value;
            IsPrimary = isPrimary;
        }

        public int Id { get; private set; }
        public ContactMethodType Type { get; private set; }
        public string Value { get; private set; }
        public bool IsPrimary { get; private set; }

        public static ContactMethod Create(
            int id,
            ContactMethodType type,
            string value,
            bool isPrimary)
        {
            return new ContactMethod(
                NormalizeId(id),
                NormalizeType(type),
                NormalizeValue(value),
                isPrimary);
        }

        public void Update(
            ContactMethodType type,
            string value,
            bool isPrimary)
        {
            Type = NormalizeType(type);
            Value = NormalizeValue(value);
            IsPrimary = isPrimary;
        }

        public void ClearPrimary()
        {
            IsPrimary = false;
        }

        internal static string NormalizeValueForComparison(string value)
        {
            return NormalizeValue(value).ToLowerInvariant();
        }

        private static int NormalizeId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Contact method id must be greater than zero.");
            }

            return id;
        }

        private static ContactMethodType NormalizeType(ContactMethodType type)
        {
            if (!Enum.IsDefined(typeof(ContactMethodType), type))
            {
                throw new ArgumentOutOfRangeException(nameof(type), "Contact method type is invalid.");
            }

            return type;
        }

        private static string NormalizeValue(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var trimmedValue = value.Trim();

            if (trimmedValue.Length == 0)
            {
                throw new ArgumentException("Contact method value cannot be empty.", nameof(value));
            }

            if (trimmedValue.Length > MaxValueLength)
            {
                throw new ArgumentException(
                    $"Contact method value cannot be longer than {MaxValueLength} characters.",
                    nameof(value));
            }

            return trimmedValue;
        }
    }
}
