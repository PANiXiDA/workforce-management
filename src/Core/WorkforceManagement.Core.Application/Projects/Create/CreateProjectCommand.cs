using MediatR;

using System;

namespace WorkforceManagement.Core.Application.Projects.Create
{
    public sealed class CreateProjectCommand : IRequest<int>
    {
        public CreateProjectCommand(
            string name,
            DateTime startDate,
            DateTime? endDate,
            bool isTimeboxed,
            int? iterationLengthDays)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            IsTimeboxed = isTimeboxed;
            IterationLengthDays = iterationLengthDays;
        }

        public string Name { get; }
        public DateTime StartDate { get; }
        public DateTime? EndDate { get; }
        public bool IsTimeboxed { get; }
        public int? IterationLengthDays { get; }
    }
}
