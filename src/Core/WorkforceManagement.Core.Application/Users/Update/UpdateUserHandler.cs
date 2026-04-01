using WorkforceManagement.Core.Application.Users.Abstractions;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace WorkforceManagement.Core.Application.Users.Update
{
    public sealed class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMediator _mediator;

        public UpdateUserHandler(
            IUsersRepository usersRepository,
            IMediator mediator)
        {
            _usersRepository = usersRepository;
            _mediator = mediator;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await OrganizationReferenceValidation.EnsureExists(
                _mediator,
                request.OrganizationId,
                cancellationToken);

            var user = _usersRepository.GetById(request.Id);

            user.Update(
                request.FirstName,
                request.LastName,
                request.Email,
                request.OrganizationId,
                request.EmploymentType,
                request.PlannedWeeklyHours,
                request.PositionTitle,
                request.HireDate,
                request.ProbationEndDate);

            _usersRepository.Update(user);

            await Task.CompletedTask;
        }
    }
}
