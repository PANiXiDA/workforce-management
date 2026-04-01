using MediatR;

namespace WorkforceManagement.Core.Application.Users.Delete
{
    public sealed class DeleteUserCommand : IRequest
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
