using WorkforceManagement.Core.Application.Organizations.Abstractions;
using WorkforceManagement.Core.Domain.Organizations;
using WorkforceManagement.Core.Domain.Organizations.Enums;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WorkforceManagement.Infrastructure.Memory.Organizations
{
    public sealed class OrganizationsRepository : IOrganizationsRepository
    {
        private readonly ConcurrentDictionary<int, Organization> _organizations;
        private int _currentId;

        public OrganizationsRepository()
        {
            _organizations = new ConcurrentDictionary<int, Organization>();
            _currentId = 0;
        }

        public IReadOnlyCollection<Organization> Search(string name, OrganizationType? organizationType)
        {
            var normalizedName = NormalizeFilter(name);

            return _organizations.Values
                .Where(organization => Matches(organization.Name, normalizedName))
                .Where(organization => !organizationType.HasValue || organization.OrganizationType == organizationType.Value)
                .OrderBy(organization => organization.Id)
                .ToArray();
        }

        public Organization GetById(int id)
        {
            if (!_organizations.TryGetValue(id, out var organization))
            {
                throw new KeyNotFoundException($"Organization with id {id} was not found.");
            }

            return organization;
        }

        public void Add(Organization organization)
        {
            if (organization == null)
            {
                throw new ArgumentNullException(nameof(organization));
            }

            var newId = Interlocked.Increment(ref _currentId);

            organization.AssignId(newId);

            var isAdded = _organizations.TryAdd(organization.Id, organization);

            if (!isAdded)
            {
                throw new InvalidOperationException($"Organization with id {organization.Id} already exists.");
            }
        }

        public void Update(Organization organization)
        {
            if (organization == null)
            {
                throw new ArgumentNullException(nameof(organization));
            }

            if (organization.Id <= 0)
            {
                throw new InvalidOperationException("Organization must have a valid id.");
            }

            if (!_organizations.ContainsKey(organization.Id))
            {
                throw new KeyNotFoundException($"Organization with id {organization.Id} was not found.");
            }

            _organizations[organization.Id] = organization;
        }

        public void Delete(Organization organization)
        {
            if (organization == null)
            {
                throw new ArgumentNullException(nameof(organization));
            }

            if (organization.Id <= 0)
            {
                throw new InvalidOperationException("Organization must have a valid id.");
            }

            _organizations.TryRemove(organization.Id, out _);
        }

        private static string NormalizeFilter(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            return value.Trim();
        }

        private static bool Matches(string value, string filter)
        {
            if (filter == null)
            {
                return true;
            }

            return value.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
