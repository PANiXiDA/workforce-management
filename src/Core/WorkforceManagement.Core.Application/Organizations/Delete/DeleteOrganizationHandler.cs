using WorkforceManagement.Core.Application.Organizations.Abstractions;
using WorkforceManagement.Core.Application.Users.Search;

using MediatR;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WorkforceManagement.Core.Application.Organizations.Delete
{
    public sealed class DeleteOrganizationHandler : IRequestHandler<DeleteOrganizationCommand>
    {
        private readonly IOrganizationsRepository _organizationsRepository;
        private readonly IMediator _mediator;

        public DeleteOrganizationHandler(
            IOrganizationsRepository organizationsRepository,
            IMediator mediator)
        {
            _organizationsRepository = organizationsRepository;
            _mediator = mediator;
        }

        public async Task Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organization = _organizationsRepository.GetById(request.Id);
            var relatedUsers = await _mediator.Send(
                new SearchUsersQuery(null, null, null, request.Id, null),
                cancellationToken);

            if (relatedUsers.Any())
            {
                throw new InvalidOperationException(
                    $"Organization with id {request.Id} cannot be deleted because it is referenced by users.");
            }

            _organizationsRepository.Delete(organization);

            await Task.CompletedTask;
        }
    }
}
