using EM.CoreBusiness;
using EM_UseCases.PluginInterfaces;

namespace EM.Plugins.InMemory
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> users = new()
        {
            new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
            new User { Id = 2, Name = "Bob", Email = "bob@example.com" },
            new User { Id = 3, Name = "Charlie", Email = "charlie@example.com" },
        };

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await Task.FromResult(users);
        }

        public async Task<IEnumerable<User>> SearchUsersAsync(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return users; // Повертаємо всіх користувачів, якщо пошуковий текст порожній
            }

            var filteredUsers = users.Where(user =>
                user.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                user.Email.Contains(searchText, StringComparison.OrdinalIgnoreCase)); // Фільтруємо за ім'ям або email

            return await Task.FromResult(filteredUsers);
        }

        public Task SyncUserToMainDbAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}


