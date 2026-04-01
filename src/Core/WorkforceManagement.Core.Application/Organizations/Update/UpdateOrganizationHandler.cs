using WorkforceManagement.Core.Application.Organizations.Abstractions;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace WorkforceManagement.Core.Application.Organizations.Update
{
    public sealed class UpdateOrganizationHandler : IRequestHandler<UpdateOrganizationCommand>
    {
        private readonly IOrganizationsRepository _organizationsRepository;

        public UpdateOrganizationHandler(IOrganizationsRepository organizationsRepository)
        {
            _organizationsRepository = organizationsRepository;
        }

        public Task Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organization = _organizationsRepository.GetById(request.Id);

            organization.Update(
                request.Name,
                request.OrganizationType,
                request.PartnerCode);

            _organizationsRepository.Update(organization);

            return Task.CompletedTask;
        }
    }
}
