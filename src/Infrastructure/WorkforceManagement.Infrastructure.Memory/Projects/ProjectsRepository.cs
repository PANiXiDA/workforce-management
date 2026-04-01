using WorkforceManagement.Core.Application.Projects.Abstractions;
using WorkforceManagement.Core.Domain.Projects;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WorkforceManagement.Infrastructure.Memory.Projects
{
    public sealed class ProjectsRepository : IProjectsRepository
    {
        private readonly ConcurrentDictionary<int, Project> _projects;
        private int _currentId;

        public ProjectsRepository()
        {
            _projects = new ConcurrentDictionary<int, Project>();
            _currentId = 0;
        }

        public IReadOnlyCollection<Project> Search(string name, bool? isTimeboxed)
        {
            var normalizedName = NormalizeFilter(name);

            return _projects.Values
                .Where(project => Matches(project.Name, normalizedName))
                .Where(project => !isTimeboxed.HasValue || project.Settings.IsTimeboxed == isTimeboxed.Value)
                .OrderBy(project => project.Id)
                .ToArray();
        }

        public Project GetById(int id)
        {
            if (!_projects.TryGetValue(id, out var project))
            {
                throw new KeyNotFoundException($"Project with id {id} was not found.");
            }

            return project;
        }

        public void Add(Project project)
        {
            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            var newId = Interlocked.Increment(ref _currentId);

            project.AssignId(newId);

            var isAdded = _projects.TryAdd(project.Id, project);

            if (!isAdded)
            {
                throw new InvalidOperationException($"Project with id {project.Id} already exists.");
            }
        }

        public void Update(Project project)
        {
            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            if (project.Id <= 0)
            {
                throw new InvalidOperationException("Project must have a valid id.");
            }

            if (!_projects.ContainsKey(project.Id))
            {
                throw new KeyNotFoundException($"Project with id {project.Id} was not found.");
            }

            _projects[project.Id] = project;
        }

        public void Delete(Project project)
        {
            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            if (project.Id <= 0)
            {
                throw new InvalidOperationException("Project must have a valid id.");
            }

            _projects.TryRemove(project.Id, out _);
        }

        private static string NormalizeFilter(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            return value.Trim();
        }

        private static bool Matches(string value, string filter)
        {
            if (filter == null)
            {
                return true;
            }

            return value.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
