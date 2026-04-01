using WorkforceManagement.Core.Application.Projects.Abstractions;

using MediatR;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WorkforceManagement.Core.Application.Projects.Search
{
    public sealed class SearchProjectsHandler : IRequestHandler<SearchProjectsQuery, IReadOnlyCollection<SearchProjectReadModel>>
    {
        private readonly IProjectsRepository _projectsRepository;

        public SearchProjectsHandler(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public Task<IReadOnlyCollection<SearchProjectReadModel>> Handle(SearchProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = _projectsRepository.Search(request.Name, request.IsTimeboxed);
            var readModels = projects
                .Select(SearchProjectReadModelMapper.ToReadModel)
                .ToArray();

            return Task.FromResult<IReadOnlyCollection<SearchProjectReadModel>>(readModels);
        }
    }
}
