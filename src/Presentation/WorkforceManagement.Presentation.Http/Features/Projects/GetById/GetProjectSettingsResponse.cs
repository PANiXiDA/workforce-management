namespace WorkforceManagement.Presentation.Http.Features.Projects.GetById
{
    public sealed class GetProjectSettingsResponse
    {
        public int Id { get; set; }
        public bool IsTimeboxed { get; set; }
        public int? IterationLengthDays { get; set; }
    }
}
