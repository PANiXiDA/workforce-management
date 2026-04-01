using WorkforceManagement.Core.Application.Users.Abstractions;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace WorkforceManagement.Core.Application.Users.GetById
{
    public sealed class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdReadModel>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUserByIdHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<GetUserByIdReadModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = _usersRepository.GetById(request.Id);
            var readModel = GetUserByIdReadModelMapper.ToReadModel(user);

            return Task.FromResult(readModel);
        }
    }
}
