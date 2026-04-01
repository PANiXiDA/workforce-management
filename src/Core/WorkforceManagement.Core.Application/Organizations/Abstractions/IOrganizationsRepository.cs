using WorkforceManagement.Core.Domain.Organizations;
using WorkforceManagement.Core.Domain.Organizations.Enums;

using System.Collections.Generic;

namespace WorkforceManagement.Core.Application.Organizations.Abstractions
{
    public interface IOrganizationsRepository
    {
        IReadOnlyCollection<Organization> Search(string name, OrganizationType? organizationType);
        Organization GetById(int id);
        void Add(Organization organization);
        void Update(Organization organization);
        void Delete(Organization organization);
    }
}
