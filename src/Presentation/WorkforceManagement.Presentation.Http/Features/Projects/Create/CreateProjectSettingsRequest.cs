namespace WorkforceManagement.Presentation.Http.Features.Projects.Create
{
    public sealed class CreateProjectSettingsRequest
    {
        public bool IsTimeboxed { get; set; }

        public int? IterationLengthDays { get; set; }
    }
}
