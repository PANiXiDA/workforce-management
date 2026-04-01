using System;

namespace WorkforceManagement.Core.Application.Projects.Search
{
    public sealed class SearchProjectReadModel
    {
        public SearchProjectReadModel(
            int id,
            string name,
            DateTime startDate,
            DateTime? endDate,
            bool isTimeboxed)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            IsTimeboxed = isTimeboxed;
        }

        public int Id { get; }
        public string Name { get; }
        public DateTime StartDate { get; }
        public DateTime? EndDate { get; }
        public bool IsTimeboxed { get; }
    }
}
