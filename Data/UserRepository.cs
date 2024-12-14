using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistrationMPApp
{
    public class UserRepository
    {
        private readonly Dictionary<string, User> _users;

        public UserRepository()
        {
            // Dummy adatok
            _users = new Dictionary<string, User>
            {
                { "user1@example.com", new User { UserName = "user1", Email = "user1@example.com", Password = "password1", FirstName = "John", LastName = "Doe" } },
                { "user2@example.com", new User { UserName = "user2", Email = "user2@example.com", Password = "password2", FirstName = "Jane", LastName = "Smith" } }
            };
        }

        public Task<User?> GetUserByEmailAsync(string email)
        {
            _users.TryGetValue(email, out var user);
            return Task.FromResult(user);
        }

        public Task<bool> RegisterUserAsync(User user)
        {
            if (_users.ContainsKey(user.Email))
                return Task.FromResult(false); // Már létező felhasználó

            _users.Add(user.Email, user);
            return Task.FromResult(true);
        }
    }
}
