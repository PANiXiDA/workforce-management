using WorkforceManagement.Core.Domain.Projects;

using System.Collections.Generic;

namespace WorkforceManagement.Core.Application.Projects.Abstractions
{
    public interface IProjectsRepository
    {
        IReadOnlyCollection<Project> Search(string name, bool? isTimeboxed);
        Project GetById(int id);
        void Add(Project project);
        void Update(Project project);
        void Delete(Project project);
    }
}
