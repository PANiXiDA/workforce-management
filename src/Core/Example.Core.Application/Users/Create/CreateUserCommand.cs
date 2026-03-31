using MediatR;

namespace Example.Core.Application.Users.Create
{
    public sealed class CreateUserCommand : IRequest<int>
    {
        public CreateUserCommand(
            string firstName,
            string lastName,
            string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
    }
}
