using EM.WebApp.Components.Pages.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EM.WebApp.Data
{
    public class UserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<string> GetProfilePictureAsync(string userId, string defaultPicture)
        {
            try
            {
                return await _dbContext.Users
                    .AsNoTracking()
                    .Where(u => u.Id == userId)
                    .Select(u => u.ProfilePicture)
                    .FirstOrDefaultAsync() ?? defaultPicture;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching profile picture: {ex.Message}");
                return defaultPicture;
            }
        }

        public async Task<List<UserViewModel>> GetAllUsersAsync()
        {
            try
            {
                return await _dbContext.Users
                    .AsNoTracking()
                    .Select(u => new UserViewModel
                    {
                        Id = u.Id,
                        Name = u.UserName,
                        Email = u.Email
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching users: {ex.Message}");
                return new List<UserViewModel>();
            }
        }

        public async Task DeleteUserAsync(string userId)
        {
            try
            {
                var user = await FindUserByIdAsync(userId);
                if (user != null)
                {
                    _dbContext.Users.Remove(user);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting user: {ex.Message}");
            }
        }

        private async Task<ApplicationUser?> FindUserByIdAsync(string userId)
        {
            try
            {
                return await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.Id == userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding user: {ex.Message}");
                return null;
            }
        }
    }
}
