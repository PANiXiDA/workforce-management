using WorkforceManagement.Core.Domain.Organizations.Enums;

using System;

namespace WorkforceManagement.Core.Domain.Organizations
{
    public sealed class Organization
    {
        private const int MaxNameLength = 200;
        private const int MaxPartnerCodeLength = 50;

        private Organization(
            int id,
            string name,
            OrganizationType organizationType,
            string partnerCode)
        {
            Id = id;
            Name = name;
            OrganizationType = organizationType;
            PartnerCode = partnerCode;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public OrganizationType OrganizationType { get; private set; }
        public string PartnerCode { get; private set; }

        public static Organization Create(
            string name,
            OrganizationType organizationType,
            string partnerCode)
        {
            var normalizedName = NormalizeName(name);
            var normalizedOrganizationType = NormalizeOrganizationType(organizationType);
            var normalizedPartnerCode = NormalizePartnerCode(partnerCode);

            EnsurePartnerCodeInvariant(normalizedOrganizationType, normalizedPartnerCode);

            return new Organization(
                0,
                normalizedName,
                normalizedOrganizationType,
                normalizedPartnerCode);
        }

        public void Update(
            string name,
            OrganizationType organizationType,
            string partnerCode)
        {
            Name = NormalizeName(name);
            OrganizationType = NormalizeOrganizationType(organizationType);
            PartnerCode = NormalizePartnerCode(partnerCode);

            EnsurePartnerCodeInvariant(OrganizationType, PartnerCode);
        }

        public void AssignId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
            }

            if (Id > 0)
            {
                throw new InvalidOperationException("Organization id has already been assigned.");
            }

            Id = id;
        }

        private static string NormalizeName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            var trimmedName = name.Trim();

            if (trimmedName.Length == 0)
            {
                throw new ArgumentException("Organization name cannot be empty.", nameof(name));
            }

            if (trimmedName.Length > MaxNameLength)
            {
                throw new ArgumentException(
                    $"Organization name cannot be longer than {MaxNameLength} characters.",
                    nameof(name));
            }

            return trimmedName;
        }

        private static OrganizationType NormalizeOrganizationType(OrganizationType organizationType)
        {
            if (!Enum.IsDefined(typeof(OrganizationType), organizationType))
            {
                throw new ArgumentOutOfRangeException(nameof(organizationType), "Organization type is invalid.");
            }

            return organizationType;
        }

        private static string NormalizePartnerCode(string partnerCode)
        {
            if (string.IsNullOrWhiteSpace(partnerCode))
            {
                return null;
            }

            var trimmedPartnerCode = partnerCode.Trim();

            if (trimmedPartnerCode.Length > MaxPartnerCodeLength)
            {
                throw new ArgumentException(
                    $"Partner code cannot be longer than {MaxPartnerCodeLength} characters.",
                    nameof(partnerCode));
            }

            return trimmedPartnerCode;
        }

        private static void EnsurePartnerCodeInvariant(
            OrganizationType organizationType,
            string partnerCode)
        {
            if (organizationType == OrganizationType.Partner && partnerCode == null)
            {
                throw new ArgumentException(
                    "Partner organizations require partner code.",
                    nameof(partnerCode));
            }

            if (organizationType == OrganizationType.Internal && partnerCode != null)
            {
                throw new ArgumentException(
                    "Partner code is not allowed for internal organizations.",
                    nameof(partnerCode));
            }
        }
    }
}
