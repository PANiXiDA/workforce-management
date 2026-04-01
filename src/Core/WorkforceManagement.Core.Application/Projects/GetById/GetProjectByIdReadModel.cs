using System;

namespace WorkforceManagement.Core.Application.Projects.GetById
{
    public sealed class GetProjectByIdReadModel
    {
        public GetProjectByIdReadModel(
            int id,
            string name,
            DateTime startDate,
            DateTime? endDate,
            GetProjectByIdSettingsReadModel settings)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Settings = settings;
        }

        public int Id { get; }
        public string Name { get; }
        public DateTime StartDate { get; }
        public DateTime? EndDate { get; }
        public GetProjectByIdSettingsReadModel Settings { get; }
    }
}
