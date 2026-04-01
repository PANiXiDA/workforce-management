using MediatR;

using System;

namespace WorkforceManagement.Core.Application.Projects.Update
{
    public sealed class UpdateProjectCommand : IRequest
    {
        public UpdateProjectCommand(
            int id,
            string name,
            DateTime startDate,
            DateTime? endDate,
            bool isTimeboxed,
            int? iterationLengthDays)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            IsTimeboxed = isTimeboxed;
            IterationLengthDays = iterationLengthDays;
        }

        public int Id { get; }
        public string Name { get; }
        public DateTime StartDate { get; }
        public DateTime? EndDate { get; }
        public bool IsTimeboxed { get; }
        public int? IterationLengthDays { get; }
    }
}
