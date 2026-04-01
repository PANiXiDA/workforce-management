using WorkforceManagement.Core.Application.Users.Abstractions;

using MediatR;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WorkforceManagement.Core.Application.Users.Search
{
    public sealed class SearchUsersHandler : IRequestHandler<SearchUsersQuery, IReadOnlyCollection<SearchUserReadModel>>
    {
        private readonly IUsersRepository _usersRepository;

        public SearchUsersHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<IReadOnlyCollection<SearchUserReadModel>> Handle(SearchUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _usersRepository.Search(
                request.FirstName,
                request.LastName,
                request.Email,
                request.OrganizationId,
                request.EmploymentType);

            var readModels = users
                .Select(SearchUserReadModelMapper.ToReadModel)
                .ToArray();

            return Task.FromResult<IReadOnlyCollection<SearchUserReadModel>>(readModels);
        }
    }
}
