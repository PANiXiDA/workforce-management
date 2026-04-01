using WorkforceManagement.Core.Application.Users.Abstractions;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace WorkforceManagement.Core.Application.Users.Delete
{
    public sealed class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUsersRepository _usersRepository;

        public DeleteUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _usersRepository.GetById(request.Id);

            _usersRepository.Delete(user);

            return Task.CompletedTask;
        }
    }
}
