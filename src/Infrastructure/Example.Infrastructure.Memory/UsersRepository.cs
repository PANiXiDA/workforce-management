using Example.Core.Application.Users.Abstractions;
using Example.Core.Domain;

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Example.Infrastructure.Memory
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
                throw new System.ArgumentNullException(nameof(user));
            }

            var newId = Interlocked.Increment(ref _currentId);

            user.AssignId(newId);

            var isAdded = _users.TryAdd(user.Id, user);

            if (!isAdded)
            {
                throw new System.InvalidOperationException($"User with id {user.Id} already exists.");
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
                throw new System.ArgumentNullException(nameof(user));
            }

            if (user.Id <= 0)
            {
                throw new System.InvalidOperationException("User must have a valid id.");
            }

            if (!_users.ContainsKey(user.Id))
            {
                throw new KeyNotFoundException($"User with id {user.Id} was not found.");
            }

            _users[user.Id] = user;
        }

        public void Delete(User user)
        {
            if (user == null)
            {
                throw new System.ArgumentNullException(nameof(user));
            }

            if (user.Id <= 0)
            {
                throw new System.InvalidOperationException("User must have a valid id.");
            }

            _users.TryRemove(user.Id, out _);
        }
    }
}
