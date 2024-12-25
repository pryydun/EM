using EM.CoreBusiness;
using EM_UseCases.Events.interfaces;
using EM_UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases.Events
{
    public class EventUseCase : IEventUseCase
    {
        private readonly IUserEventRepository _userEventRepository;

        public EventUseCase(IUserEventRepository userEventRepository)
        {
            _userEventRepository = userEventRepository;
        }

        public async Task RegisterUserToEventAsync(int userId, int eventId)
        {
            var userEvent = new UserEvents
            {
                UserId = userId,
                EventId = eventId
            };

            await _userEventRepository.AddUserToEventAsync(userEvent);
        }

        public async Task<IEnumerable<User>> GetRegisteredUsersAsync(int eventId)
        {
            return await _userEventRepository.GetUsersByEventIdAsync(eventId);
        }
    }
}
