using WorkforceManagement.Core.Application.Organizations.GetById;

namespace WorkforceManagement.Presentation.Http.Features.Organizations.GetById
{
    public static class GetOrganizationByIdMapper
    {
        public static GetOrganizationByIdResponse ToResponse(GetOrganizationByIdReadModel organization)
        {
            return new GetOrganizationByIdResponse
            {
                Id = organization.Id,
                Name = organization.Name,
                OrganizationType = organization.OrganizationType,
                PartnerCode = organization.PartnerCode
            };
        }
    }
}
