using WorkforceManagement.Core.Application.Organizations.Abstractions;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace WorkforceManagement.Core.Application.Organizations.GetById
{
    public sealed class GetOrganizationByIdHandler : IRequestHandler<GetOrganizationByIdQuery, GetOrganizationByIdReadModel>
    {
        private readonly IOrganizationsRepository _organizationsRepository;

        public GetOrganizationByIdHandler(IOrganizationsRepository organizationsRepository)
        {
            _organizationsRepository = organizationsRepository;
        }

        public Task<GetOrganizationByIdReadModel> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            var organization = _organizationsRepository.GetById(request.Id);
            var readModel = GetOrganizationByIdReadModelMapper.ToReadModel(organization);

            return Task.FromResult(readModel);
        }
    }
}
