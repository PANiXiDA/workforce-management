using WorkforceManagement.Core.Application.Users.Abstractions;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace WorkforceManagement.Core.Application.Users.ContactMethods.Delete
{
    public sealed class DeleteContactMethodHandler : IRequestHandler<DeleteContactMethodCommand>
    {
        private readonly IUsersRepository _usersRepository;

        public DeleteContactMethodHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task Handle(DeleteContactMethodCommand request, CancellationToken cancellationToken)
        {
            var user = _usersRepository.GetById(request.UserId);

            user.RemoveContactMethod(request.ContactMethodId);

            _usersRepository.Update(user);

            return Task.CompletedTask;
        }
    }
}
