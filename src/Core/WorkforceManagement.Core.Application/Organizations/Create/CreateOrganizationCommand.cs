using WorkforceManagement.Core.Domain.Organizations.Enums;

using MediatR;

namespace WorkforceManagement.Core.Application.Organizations.Create
{
    public sealed class CreateOrganizationCommand : IRequest<int>
    {
        public CreateOrganizationCommand(
            string name,
            OrganizationType organizationType,
            string partnerCode)
        {
            Name = name;
            OrganizationType = organizationType;
            PartnerCode = partnerCode;
        }

        public string Name { get; }
        public OrganizationType OrganizationType { get; }
        public string PartnerCode { get; }
    }
}
