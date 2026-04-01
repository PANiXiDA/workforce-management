using WorkforceManagement.Core.Application.Projects.Abstractions;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace WorkforceManagement.Core.Application.Projects.GetById
{
    public sealed class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, GetProjectByIdReadModel>
    {
        private readonly IProjectsRepository _projectsRepository;

        public GetProjectByIdHandler(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public Task<GetProjectByIdReadModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = _projectsRepository.GetById(request.Id);
            var readModel = GetProjectByIdReadModelMapper.ToReadModel(project);

            return Task.FromResult(readModel);
        }
    }
}
