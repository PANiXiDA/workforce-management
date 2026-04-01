using System;

namespace WorkforceManagement.Presentation.Http.Features.Projects.GetById
{
    public sealed class GetProjectByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public GetProjectSettingsResponse Settings { get; set; }
    }
}
