using Example.Core.Application.Users.Abstractions;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace Example.Core.Application.Users.GetById
{
    public sealed class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserReadModel>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUserByIdHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<UserReadModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = _usersRepository.GetById(request.Id);
            var readModel = UserReadModelMapper.ToReadModel(user);

            return Task.FromResult(readModel);
        }
    }
}
