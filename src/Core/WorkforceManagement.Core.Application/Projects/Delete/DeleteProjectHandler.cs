using WorkforceManagement.Core.Application.Projects.Abstractions;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace WorkforceManagement.Core.Application.Projects.Delete
{
    public sealed class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IProjectsRepository _projectsRepository;

        public DeleteProjectHandler(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _projectsRepository.GetById(request.Id);

            _projectsRepository.Delete(project);

            return Task.CompletedTask;
        }
    }
}
