using WorkforceManagement.Core.Domain.Projects.Entities;

using System;

namespace WorkforceManagement.Core.Domain.Projects
{
    public sealed class Project
    {
        private const int MaxNameLength = 200;

        private Project(
            int id,
            string name,
            DateTime startDate,
            DateTime? endDate,
            ProjectSettings settings)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Settings = settings;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public ProjectSettings Settings { get; private set; }

        public static Project Create(
            string name,
            DateTime startDate,
            DateTime? endDate,
            bool isTimeboxed,
            int? iterationLengthDays)
        {
            var normalizedName = NormalizeName(name);
            var normalizedStartDate = NormalizeRequiredDate(startDate, nameof(startDate));
            var normalizedEndDate = NormalizeOptionalDate(endDate, nameof(endDate));

            EnsureDateInvariant(normalizedStartDate, normalizedEndDate);

            return new Project(
                0,
                normalizedName,
                normalizedStartDate,
                normalizedEndDate,
                ProjectSettings.Create(isTimeboxed, iterationLengthDays));
        }

        public void Update(
            string name,
            DateTime startDate,
            DateTime? endDate,
            bool isTimeboxed,
            int? iterationLengthDays)
        {
            Name = NormalizeName(name);
            StartDate = NormalizeRequiredDate(startDate, nameof(startDate));
            EndDate = NormalizeOptionalDate(endDate, nameof(endDate));

            EnsureDateInvariant(StartDate, EndDate);

            Settings.Update(isTimeboxed, iterationLengthDays);
        }

        public void AssignId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
            }

            if (Id > 0)
            {
                throw new InvalidOperationException("Project id has already been assigned.");
            }

            Id = id;
            Settings.AssignId(id);
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
                throw new ArgumentException("Project name cannot be empty.", nameof(name));
            }

            if (trimmedName.Length > MaxNameLength)
            {
                throw new ArgumentException(
                    $"Project name cannot be longer than {MaxNameLength} characters.",
                    nameof(name));
            }

            return trimmedName;
        }

        private static DateTime NormalizeRequiredDate(DateTime value, string paramName)
        {
            if (value == default(DateTime))
            {
                throw new ArgumentException("Date value is required.", paramName);
            }

            return value.Date;
        }

        private static DateTime? NormalizeOptionalDate(DateTime? value, string paramName)
        {
            if (!value.HasValue)
            {
                return null;
            }

            return NormalizeRequiredDate(value.Value, paramName);
        }

        private static void EnsureDateInvariant(DateTime startDate, DateTime? endDate)
        {
            if (endDate.HasValue && endDate.Value < startDate)
            {
                throw new ArgumentException("End date cannot be earlier than start date.", nameof(endDate));
            }
        }
    }
}
