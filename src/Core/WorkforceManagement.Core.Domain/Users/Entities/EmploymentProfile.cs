using System;

namespace WorkforceManagement.Core.Domain.Users.Entities
{
    public sealed class EmploymentProfile
    {
        private const int MaxPositionTitleLength = 200;

        private EmploymentProfile(
            int id,
            string positionTitle,
            DateTime hireDate,
            DateTime? probationEndDate)
        {
            Id = id;
            PositionTitle = positionTitle;
            HireDate = hireDate;
            ProbationEndDate = probationEndDate;
        }

        public int Id { get; private set; }
        public string PositionTitle { get; private set; }
        public DateTime HireDate { get; private set; }
        public DateTime? ProbationEndDate { get; private set; }

        public static EmploymentProfile Create(
            int id,
            string positionTitle,
            DateTime hireDate,
            DateTime? probationEndDate)
        {
            return new EmploymentProfile(
                NormalizeId(id),
                NormalizePositionTitle(positionTitle),
                NormalizeDate(hireDate, nameof(hireDate)),
                NormalizeProbationEndDate(hireDate, probationEndDate));
        }

        public void Update(
            string positionTitle,
            DateTime hireDate,
            DateTime? probationEndDate)
        {
            PositionTitle = NormalizePositionTitle(positionTitle);
            HireDate = NormalizeDate(hireDate, nameof(hireDate));
            ProbationEndDate = NormalizeProbationEndDate(hireDate, probationEndDate);
        }

        private static int NormalizeId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Employment profile id must be greater than zero.");
            }

            return id;
        }

        private static string NormalizePositionTitle(string positionTitle)
        {
            if (positionTitle == null)
            {
                throw new ArgumentNullException(nameof(positionTitle));
            }

            var trimmedValue = positionTitle.Trim();

            if (trimmedValue.Length == 0)
            {
                throw new ArgumentException("Position title cannot be empty.", nameof(positionTitle));
            }

            if (trimmedValue.Length > MaxPositionTitleLength)
            {
                throw new ArgumentException(
                    $"Position title cannot be longer than {MaxPositionTitleLength} characters.",
                    nameof(positionTitle));
            }

            return trimmedValue;
        }

        private static DateTime NormalizeDate(DateTime value, string paramName)
        {
            if (value == default(DateTime))
            {
                throw new ArgumentException("Date value is required.", paramName);
            }

            return value.Date;
        }

        private static DateTime? NormalizeProbationEndDate(DateTime hireDate, DateTime? probationEndDate)
        {
            if (!probationEndDate.HasValue)
            {
                return null;
            }

            var normalizedHireDate = NormalizeDate(hireDate, nameof(hireDate));
            var normalizedProbationEndDate = NormalizeDate(probationEndDate.Value, nameof(probationEndDate));

            if (normalizedProbationEndDate < normalizedHireDate)
            {
                throw new ArgumentException(
                    "Probation end date cannot be earlier than hire date.",
                    nameof(probationEndDate));
            }

            return normalizedProbationEndDate;
        }
    }
}
