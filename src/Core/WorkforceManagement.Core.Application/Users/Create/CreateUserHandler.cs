using WorkforceManagement.Core.Application.Users.Abstractions;
using WorkforceManagement.Core.Domain.Users;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace WorkforceManagement.Core.Application.Users.Create
{
    public sealed class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMediator _mediator;

        public CreateUserHandler(
            IUsersRepository usersRepository,
            IMediator mediator)
        {
            _usersRepository = usersRepository;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await OrganizationReferenceValidation.EnsureExists(
                _mediator,
                request.OrganizationId,
                cancellationToken);

            var user = User.Create(
                request.FirstName,
                request.LastName,
                request.Email,
                request.OrganizationId,
                request.EmploymentType,
                request.PlannedWeeklyHours,
                request.PositionTitle,
                request.HireDate,
                request.ProbationEndDate);

            _usersRepository.Add(user);

            return user.Id;
        }
    }
}
