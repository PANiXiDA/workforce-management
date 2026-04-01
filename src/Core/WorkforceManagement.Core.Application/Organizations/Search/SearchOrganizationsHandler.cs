using WorkforceManagement.Core.Application.Organizations.Abstractions;

using MediatR;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WorkforceManagement.Core.Application.Organizations.Search
{
    public sealed class SearchOrganizationsHandler : IRequestHandler<SearchOrganizationsQuery, IReadOnlyCollection<SearchOrganizationReadModel>>
    {
        private readonly IOrganizationsRepository _organizationsRepository;

        public SearchOrganizationsHandler(IOrganizationsRepository organizationsRepository)
        {
            _organizationsRepository = organizationsRepository;
        }

        public Task<IReadOnlyCollection<SearchOrganizationReadModel>> Handle(SearchOrganizationsQuery request, CancellationToken cancellationToken)
        {
            var organizations = _organizationsRepository.Search(
                request.Name,
                request.OrganizationType);

            var readModels = organizations
                .Select(SearchOrganizationReadModelMapper.ToReadModel)
                .ToArray();

            return Task.FromResult<IReadOnlyCollection<SearchOrganizationReadModel>>(readModels);
        }
    }
}
