using EM.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases.PluginInterfaces
{
    public interface IUserEventRepository
    {
        Task RemoveUserFromEventAsync(UserEvent userEvent);
        Task AddUserToEventAsync(UserEvent userEvent);
        Task<List<Event>> GetEventsByUserIdAsync(string userId);
        Task<List<UserEvent>> GetUsersByEventIdAsync(int eventId); // Повертає список моделей UserEvent
        Task DeleteUserEventsByUserIdAsync(string userId);
    }
}
