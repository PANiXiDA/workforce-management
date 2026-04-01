using MediatR;

namespace WorkforceManagement.Core.Application.Organizations.Delete
{
    public sealed class DeleteOrganizationCommand : IRequest
    {
        public DeleteOrganizationCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
