using WorkforceManagement.Core.Domain.Users.Entities;
using WorkforceManagement.Core.Domain.Users.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace WorkforceManagement.Core.Domain.Users
{
    public sealed class User
    {
        private const int MaxFirstNameLength = 100;
        private const int MaxLastNameLength = 100;
        private const int MaxEmailLength = 256;

        private readonly List<ContactMethod> _contactMethods;
        private int _currentContactMethodId;

        private User(
            int id,
            string firstName,
            string lastName,
            string email,
            int organizationId,
            EmploymentType employmentType,
            int plannedWeeklyHours,
            EmploymentProfile employmentProfile)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            OrganizationId = organizationId;
            EmploymentType = employmentType;
            PlannedWeeklyHours = plannedWeeklyHours;
            EmploymentProfile = employmentProfile;
            _contactMethods = new List<ContactMethod>();
            _currentContactMethodId = 0;
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public int OrganizationId { get; private set; }
        public EmploymentType EmploymentType { get; private set; }
        public int PlannedWeeklyHours { get; private set; }
        public EmploymentProfile EmploymentProfile { get; private set; }
        public IReadOnlyCollection<ContactMethod> ContactMethods
        {
            get { return _contactMethods.AsReadOnly(); }
        }

        public static User Create(
            string firstName,
            string lastName,
            string email,
            int organizationId,
            EmploymentType employmentType,
            int plannedWeeklyHours,
            string positionTitle,
            DateTime hireDate,
            DateTime? probationEndDate)
        {
            var user = new User(
                0,
                NormalizeName(firstName, nameof(firstName), MaxFirstNameLength),
                NormalizeName(lastName, nameof(lastName), MaxLastNameLength),
                NormalizeEmail(email),
                NormalizeOrganizationId(organizationId),
                NormalizeEmploymentType(employmentType),
                NormalizePlannedWeeklyHours(plannedWeeklyHours),
                EmploymentProfile.Create(positionTitle, hireDate, probationEndDate));

            user.EnsureEmploymentInvariant();

            return user;
        }

        public void Update(
            string firstName,
            string lastName,
            string email,
            int organizationId,
            EmploymentType employmentType,
            int plannedWeeklyHours,
            string positionTitle,
            DateTime hireDate,
            DateTime? probationEndDate)
        {
            FirstName = NormalizeName(firstName, nameof(firstName), MaxFirstNameLength);
            LastName = NormalizeName(lastName, nameof(lastName), MaxLastNameLength);
            Email = NormalizeEmail(email);
            OrganizationId = NormalizeOrganizationId(organizationId);
            EmploymentType = NormalizeEmploymentType(employmentType);
            PlannedWeeklyHours = NormalizePlannedWeeklyHours(plannedWeeklyHours);
            EmploymentProfile.Update(positionTitle, hireDate, probationEndDate);

            EnsureEmploymentInvariant();
        }

        public int AddContactMethod(
            ContactMethodType type,
            string value,
            bool isPrimary)
        {
            EnsureContactMethodUniqueness(type, value, null);

            if (isPrimary)
            {
                ClearPrimaryContactMethods(null);
            }

            var newContactMethodId = ++_currentContactMethodId;
            var contactMethod = ContactMethod.Create(newContactMethodId, type, value, isPrimary);

            _contactMethods.Add(contactMethod);

            return newContactMethodId;
        }

        public void UpdateContactMethod(
            int contactMethodId,
            ContactMethodType type,
            string value,
            bool isPrimary)
        {
            var contactMethod = GetContactMethod(contactMethodId);

            EnsureContactMethodUniqueness(type, value, contactMethodId);

            if (isPrimary)
            {
                ClearPrimaryContactMethods(contactMethodId);
            }

            contactMethod.Update(type, value, isPrimary);
        }

        public void RemoveContactMethod(int contactMethodId)
        {
            var contactMethod = GetContactMethod(contactMethodId);

            _contactMethods.Remove(contactMethod);
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
            EmploymentProfile.AssignId(id);
        }

        private void EnsureEmploymentInvariant()
        {
            switch (EmploymentType)
            {
                case EmploymentType.FullTime:
                    if (PlannedWeeklyHours != 40)
                    {
                        throw new ArgumentException(
                            "FullTime employment requires planned weekly hours to be exactly 40.",
                            nameof(PlannedWeeklyHours));
                    }

                    break;
                case EmploymentType.PartTime:
                    if (PlannedWeeklyHours <= 0 || PlannedWeeklyHours >= 40)
                    {
                        throw new ArgumentException(
                            "PartTime employment requires planned weekly hours to be between 1 and 39.",
                            nameof(PlannedWeeklyHours));
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(EmploymentType), "Employment type is invalid.");
            }
        }

        private ContactMethod GetContactMethod(int contactMethodId)
        {
            if (contactMethodId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(contactMethodId), "Contact method id must be greater than zero.");
            }

            var contactMethod = _contactMethods.SingleOrDefault(item => item.Id == contactMethodId);

            if (contactMethod == null)
            {
                throw new KeyNotFoundException($"Contact method with id {contactMethodId} was not found.");
            }

            return contactMethod;
        }

        private void EnsureContactMethodUniqueness(
            ContactMethodType type,
            string value,
            int? ignoredContactMethodId)
        {
            var normalizedType = ContactMethod.Create(1, type, value, false).Type;
            var normalizedValue = ContactMethod.NormalizeValueForComparison(value);
            var hasDuplicate = _contactMethods.Any(
                item => item.Id != ignoredContactMethodId
                    && item.Type == normalizedType
                    && ContactMethod.NormalizeValueForComparison(item.Value) == normalizedValue);

            if (hasDuplicate)
            {
                throw new ArgumentException("Contact method with the same type and value already exists.", nameof(value));
            }
        }

        private void ClearPrimaryContactMethods(int? ignoredContactMethodId)
        {
            foreach (var contactMethod in _contactMethods.Where(item => item.Id != ignoredContactMethodId && item.IsPrimary))
            {
                contactMethod.ClearPrimary();
            }
        }

        private static int NormalizeOrganizationId(int organizationId)
        {
            if (organizationId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(organizationId), "Organization id must be greater than zero.");
            }

            return organizationId;
        }

        private static EmploymentType NormalizeEmploymentType(EmploymentType employmentType)
        {
            if (!Enum.IsDefined(typeof(EmploymentType), employmentType))
            {
                throw new ArgumentOutOfRangeException(nameof(employmentType), "Employment type is invalid.");
            }

            return employmentType;
        }

        private static int NormalizePlannedWeeklyHours(int plannedWeeklyHours)
        {
            if (plannedWeeklyHours <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(plannedWeeklyHours),
                    "Planned weekly hours must be greater than zero.");
            }

            return plannedWeeklyHours;
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
