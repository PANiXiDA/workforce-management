using MediatR;

namespace Example.Core.Application.Users.Delete
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
