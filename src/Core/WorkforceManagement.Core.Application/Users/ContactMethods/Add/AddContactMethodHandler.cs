using WorkforceManagement.Core.Application.Users.Abstractions;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace WorkforceManagement.Core.Application.Users.ContactMethods.Add
{
    public sealed class AddContactMethodHandler : IRequestHandler<AddContactMethodCommand, int>
    {
        private readonly IUsersRepository _usersRepository;

        public AddContactMethodHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<int> Handle(AddContactMethodCommand request, CancellationToken cancellationToken)
        {
            var user = _usersRepository.GetById(request.UserId);
            var contactMethodId = user.AddContactMethod(
                request.Type,
                request.Value,
                request.IsPrimary);

            _usersRepository.Update(user);

            return Task.FromResult(contactMethodId);
        }
    }
}
