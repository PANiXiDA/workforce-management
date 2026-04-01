using WorkforceManagement.Core.Application.Organizations.Abstractions;
using WorkforceManagement.Core.Domain.Organizations;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace WorkforceManagement.Core.Application.Organizations.Create
{
    public sealed class CreateOrganizationHandler : IRequestHandler<CreateOrganizationCommand, int>
    {
        private readonly IOrganizationsRepository _organizationsRepository;

        public CreateOrganizationHandler(IOrganizationsRepository organizationsRepository)
        {
            _organizationsRepository = organizationsRepository;
        }

        public Task<int> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organization = Organization.Create(
                request.Name,
                request.OrganizationType,
                request.PartnerCode);

            _organizationsRepository.Add(organization);

            return Task.FromResult(organization.Id);
        }
    }
}
