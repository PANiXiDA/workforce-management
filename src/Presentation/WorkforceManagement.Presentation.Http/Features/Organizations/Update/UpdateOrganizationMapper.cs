using WorkforceManagement.Core.Application.Organizations.Update;
using WorkforceManagement.Presentation.Http.Features.Organizations;

namespace WorkforceManagement.Presentation.Http.Features.Organizations.Update
{
    public static class UpdateOrganizationMapper
    {
        public static UpdateOrganizationCommand ToCommand(int id, UpdateOrganizationRequest request)
        {
            return new UpdateOrganizationCommand(
                id,
                request.Name,
                OrganizationTypeParser.Parse(request.OrganizationType),
                request.PartnerCode);
        }
    }
}
