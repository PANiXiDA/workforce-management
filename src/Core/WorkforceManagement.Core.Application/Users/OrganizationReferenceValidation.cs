using WorkforceManagement.Core.Application.Organizations.GetById;

using MediatR;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WorkforceManagement.Core.Application.Users
{
    internal static class OrganizationReferenceValidation
    {
        public static async Task EnsureExists(
            IMediator mediator,
            int organizationId,
            CancellationToken cancellationToken)
        {
            try
            {
                await mediator.Send(new GetOrganizationByIdQuery(organizationId), cancellationToken);
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException(
                    $"Organization with id {organizationId} was not found.",
                    nameof(organizationId));
            }
        }
    }
}
