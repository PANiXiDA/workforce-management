namespace WorkforceManagement.Core.Application.Projects.GetById
{
    public sealed class GetProjectByIdSettingsReadModel
    {
        public GetProjectByIdSettingsReadModel(
            int id,
            bool isTimeboxed,
            int? iterationLengthDays)
        {
            Id = id;
            IsTimeboxed = isTimeboxed;
            IterationLengthDays = iterationLengthDays;
        }

        public int Id { get; }
        public bool IsTimeboxed { get; }
        public int? IterationLengthDays { get; }
    }
}
