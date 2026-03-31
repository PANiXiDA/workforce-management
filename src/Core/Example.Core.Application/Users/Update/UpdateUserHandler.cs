using Example.Core.Application.Users.Abstractions;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace Example.Core.Application.Users.Update
{
    public sealed class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUsersRepository _usersRepository;

        public UpdateUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _usersRepository.GetById(request.Id);

            user.ChangeName(request.FirstName, request.LastName);
            user.ChangeEmail(request.Email);

            _usersRepository.Update(user);

            return Task.CompletedTask;
        }
    }
}
