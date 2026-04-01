using System;

namespace WorkforceManagement.Presentation.Http.Features.Projects.Search
{
    public sealed class SearchProjectsItemResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsTimeboxed { get; set; }
    }
}
