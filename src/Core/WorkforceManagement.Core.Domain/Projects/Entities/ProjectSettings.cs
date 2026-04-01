using System;

namespace WorkforceManagement.Core.Domain.Projects.Entities
{
    public sealed class ProjectSettings
    {
        private ProjectSettings(
            int id,
            bool isTimeboxed,
            int? iterationLengthDays)
        {
            Id = id;
            IsTimeboxed = isTimeboxed;
            IterationLengthDays = iterationLengthDays;
        }

        public int Id { get; private set; }
        public bool IsTimeboxed { get; private set; }
        public int? IterationLengthDays { get; private set; }

        public static ProjectSettings Create(
            int id,
            bool isTimeboxed,
            int? iterationLengthDays)
        {
            return new ProjectSettings(
                NormalizeId(id),
                isTimeboxed,
                NormalizeIterationLengthDays(isTimeboxed, iterationLengthDays));
        }

        public void Update(
            bool isTimeboxed,
            int? iterationLengthDays)
        {
            IsTimeboxed = isTimeboxed;
            IterationLengthDays = NormalizeIterationLengthDays(isTimeboxed, iterationLengthDays);
        }

        private static int NormalizeId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Project settings id must be greater than zero.");
            }

            return id;
        }

        private static int? NormalizeIterationLengthDays(bool isTimeboxed, int? iterationLengthDays)
        {
            if (isTimeboxed)
            {
                if (!iterationLengthDays.HasValue)
                {
                    throw new ArgumentException(
                        "Iteration length is required for timeboxed projects.",
                        nameof(iterationLengthDays));
                }

                if (iterationLengthDays.Value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(iterationLengthDays),
                        "Iteration length must be greater than zero.");
                }

                return iterationLengthDays.Value;
            }

            if (iterationLengthDays.HasValue)
            {
                throw new ArgumentException(
                    "Iteration length is not allowed when project is not timeboxed.",
                    nameof(iterationLengthDays));
            }

            return null;
        }
    }
}
