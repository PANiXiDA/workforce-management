using MediatR;

namespace Example.Core.Application.Users.GetById
{
    public sealed class GetUserByIdQuery : IRequest<UserReadModel>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
