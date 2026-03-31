using System;
using System.Net.Mail;

namespace Example.Core.Domain
{
    public sealed class User
    {
        private const int MaxFirstNameLength = 100;
        private const int MaxLastNameLength = 100;
        private const int MaxEmailLength = 256;

        private User(
            int id,
            string firstName,
            string lastName,
            string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }

        public static User Create(
            string firstName,
            string lastName,
            string email)
        {
            var normalizedFirstName = NormalizeName(firstName, nameof(firstName), MaxFirstNameLength);
            var normalizedLastName = NormalizeName(lastName, nameof(lastName), MaxLastNameLength);
            var normalizedEmail = NormalizeEmail(email);

            return new User(
                0,
                normalizedFirstName,
                normalizedLastName,
                normalizedEmail);
        }

        public void ChangeName(string firstName, string lastName)
        {
            FirstName = NormalizeName(firstName, nameof(firstName), MaxFirstNameLength);
            LastName = NormalizeName(lastName, nameof(lastName), MaxLastNameLength);
        }

        public void ChangeEmail(string email)
        {
            Email = NormalizeEmail(email);
        }

        public void AssignId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
            }

            if (Id > 0)
            {
                throw new InvalidOperationException("User id has already been assigned.");
            }

            Id = id;
        }

        private static string NormalizeName(string value, string paramName, int maxLength)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }

            var trimmedValue = value.Trim();

            if (trimmedValue.Length == 0)
            {
                throw new ArgumentException("Value cannot be empty.", paramName);
            }

            if (trimmedValue.Length > maxLength)
            {
                throw new ArgumentException(
                    $"Value cannot be longer than {maxLength} characters.",
                    paramName);
            }

            return trimmedValue;
        }

        private static string NormalizeEmail(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            var trimmedEmail = email.Trim();

            if (trimmedEmail.Length == 0)
            {
                throw new ArgumentException("Email cannot be empty.", nameof(email));
            }

            if (trimmedEmail.Length > MaxEmailLength)
            {
                throw new ArgumentException(
                    $"Email cannot be longer than {MaxEmailLength} characters.",
                    nameof(email));
            }

            if (!IsValidEmail(trimmedEmail))
            {
                throw new ArgumentException("Email has invalid format.", nameof(email));
            }

            return trimmedEmail.ToLowerInvariant();
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return string.Equals(mailAddress.Address, email, StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }
    }
}
