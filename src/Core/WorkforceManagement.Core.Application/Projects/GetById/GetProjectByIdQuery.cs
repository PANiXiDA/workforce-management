using MediatR;

namespace WorkforceManagement.Core.Application.Projects.GetById
{
    public sealed class GetProjectByIdQuery : IRequest<GetProjectByIdReadModel>
    {
        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
