using WorkforceManagement.Core.Domain.Organizations.Enums;

using MediatR;

namespace WorkforceManagement.Core.Application.Organizations.Update
{
    public sealed class UpdateOrganizationCommand : IRequest
    {
        public UpdateOrganizationCommand(
            int id,
            string name,
            OrganizationType organizationType,
            string partnerCode)
        {
            Id = id;
            Name = name;
            OrganizationType = organizationType;
            PartnerCode = partnerCode;
        }

        public int Id { get; }
        public string Name { get; }
        public OrganizationType OrganizationType { get; }
        public string PartnerCode { get; }
    }
}
