using WorkforceManagement.Core.Application.Users.ContactMethods.Update;
using WorkforceManagement.Presentation.Http.Features.Users;

namespace WorkforceManagement.Presentation.Http.Features.Users.ContactMethods.Update
{
    public static class UpdateContactMethodMapper
    {
        public static UpdateContactMethodCommand ToCommand(
            int userId,
            int contactMethodId,
            UpdateContactMethodRequest request)
        {
            return new UpdateContactMethodCommand(
                userId,
                contactMethodId,
                ContactMethodTypeParser.Parse(request.Type),
                request.Value,
                request.IsPrimary);
        }
    }
}
