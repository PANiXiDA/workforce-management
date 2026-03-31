using Example.Core.Application.Users.Abstractions;
using Example.Core.Domain;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace Example.Core.Application.Users.Create
{
    public sealed class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUsersRepository _userRepository;

        public CreateUserHandler(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.Create(
                request.FirstName,
                request.LastName,
                request.Email);

             _userRepository.Add(user);

            return Task.FromResult(user.Id);
        }
    }
}
