using Example.Core.Application.Users.Abstractions;
using Example.Core.Domain.Users;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Example.Infrastructure.Memory.Users
{
    public sealed class UsersRepository : IUsersRepository
    {
        private readonly ConcurrentDictionary<int, User> _users;
        private int _currentId;

        public UsersRepository()
        {
            _users = new ConcurrentDictionary<int, User>();
            _currentId = 0;
        }

        public void Add(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var newId = Interlocked.Increment(ref _currentId);

            user.AssignId(newId);

            var isAdded = _users.TryAdd(user.Id, user);

            if (!isAdded)
            {
                throw new InvalidOperationException($"User with id {user.Id} already exists.");
            }
        }

        public User GetById(int id)
        {
            if (!_users.TryGetValue(id, out var user))
            {
                throw new KeyNotFoundException($"User with id {id} was not found.");
            }

            return user;
        }

        public void Update(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (user.Id <= 0)
            {
                throw new InvalidOperationException("User must have a valid id.");
            }

            if (!_users.ContainsKey(user.Id))
            {
                throw new KeyNotFoundException($"User with id {user.Id} was not found.");
            }

            _users[user.Id] = user;
        }

        public IReadOnlyCollection<User> Search(string firstName, string lastName, string email)
        {
            var normalizedFirstName = NormalizeFilter(firstName);
            var normalizedLastName = NormalizeFilter(lastName);
            var normalizedEmail = NormalizeFilter(email);

            return _users.Values
                .Where(user => Matches(user.FirstName, normalizedFirstName))
                .Where(user => Matches(user.LastName, normalizedLastName))
                .Where(user => Matches(user.Email, normalizedEmail))
                .OrderBy(user => user.Id)
                .ToArray();
        }

        public void Delete(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (user.Id <= 0)
            {
                throw new InvalidOperationException("User must have a valid id.");
            }

            _users.TryRemove(user.Id, out _);
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
