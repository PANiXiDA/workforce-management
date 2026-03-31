using MediatR;

namespace Example.Core.Application.Users.Update
{
    public sealed class UpdateUserCommand : IRequest
    {
        public UpdateUserCommand(
            int id,
            string firstName,
            string lastName,
            string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
    }
}
