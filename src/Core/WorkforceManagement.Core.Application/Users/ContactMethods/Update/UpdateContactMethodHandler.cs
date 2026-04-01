using WorkforceManagement.Core.Application.Users.Abstractions;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace WorkforceManagement.Core.Application.Users.ContactMethods.Update
{
    public sealed class UpdateContactMethodHandler : IRequestHandler<UpdateContactMethodCommand>
    {
        private readonly IUsersRepository _usersRepository;

        public UpdateContactMethodHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task Handle(UpdateContactMethodCommand request, CancellationToken cancellationToken)
        {
            var user = _usersRepository.GetById(request.UserId);

            user.UpdateContactMethod(
                request.ContactMethodId,
                request.Type,
                request.Value,
                request.IsPrimary);

            _usersRepository.Update(user);

            return Task.CompletedTask;
        }
    }
}
