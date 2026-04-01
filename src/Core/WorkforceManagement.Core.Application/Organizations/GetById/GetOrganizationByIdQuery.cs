using MediatR;

namespace WorkforceManagement.Core.Application.Organizations.GetById
{
    public sealed class GetOrganizationByIdQuery : IRequest<GetOrganizationByIdReadModel>
    {
        public GetOrganizationByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
