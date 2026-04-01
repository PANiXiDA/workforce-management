namespace WorkforceManagement.Presentation.Http.Features.Projects.Update
{
    public sealed class UpdateProjectSettingsRequest
    {
        public bool IsTimeboxed { get; set; }

        public int? IterationLengthDays { get; set; }
    }
}
