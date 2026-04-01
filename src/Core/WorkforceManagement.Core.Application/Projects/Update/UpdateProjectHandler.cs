using WorkforceManagement.Core.Application.Projects.Abstractions;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace WorkforceManagement.Core.Application.Projects.Update
{
    public sealed class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IProjectsRepository _projectsRepository;

        public UpdateProjectHandler(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _projectsRepository.GetById(request.Id);

            project.Update(
                request.Name,
                request.StartDate,
                request.EndDate,
                request.IsTimeboxed,
                request.IterationLengthDays);

            _projectsRepository.Update(project);

            return Task.CompletedTask;
        }
    }
}
