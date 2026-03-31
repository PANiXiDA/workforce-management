using Example.Core.Application.Users.Abstractions;

using MediatR;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Example.Core.Application.Users.Search
{
    public sealed class SearchUsersHandler : IRequestHandler<SearchUsersQuery, IReadOnlyCollection<UserReadModel>>
    {
        private readonly IUsersRepository _usersRepository;

        public SearchUsersHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<IReadOnlyCollection<UserReadModel>> Handle(SearchUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _usersRepository.Search(
                request.FirstName,
                request.LastName,
                request.Email);

            var readModels = users
                .Select(UserReadModelMapper.ToReadModel)
                .ToArray();

            return Task.FromResult<IReadOnlyCollection<UserReadModel>>(readModels);
        }
    }
}
