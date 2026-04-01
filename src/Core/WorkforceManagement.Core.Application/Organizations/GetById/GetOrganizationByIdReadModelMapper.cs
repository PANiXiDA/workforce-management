using WorkforceManagement.Core.Domain.Organizations;

namespace WorkforceManagement.Core.Application.Organizations.GetById
{
    internal static class GetOrganizationByIdReadModelMapper
    {
        public static GetOrganizationByIdReadModel ToReadModel(Organization organization)
        {
            return new GetOrganizationByIdReadModel(
                organization.Id,
                organization.Name,
                organization.OrganizationType.ToString(),
                organization.PartnerCode);
        }
    }
}
