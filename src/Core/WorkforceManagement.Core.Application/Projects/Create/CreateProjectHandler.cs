using WorkforceManagement.Core.Application.Projects.Abstractions;
using WorkforceManagement.Core.Domain.Projects;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace WorkforceManagement.Core.Application.Projects.Create
{
    public sealed class CreateProjectHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectsRepository _projectsRepository;

        public CreateProjectHandler(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = Project.Create(
                request.Name,
                request.StartDate,
                request.EndDate,
                request.IsTimeboxed,
                request.IterationLengthDays);

            _projectsRepository.Add(project);

            return Task.FromResult(project.Id);
        }
    }
}
