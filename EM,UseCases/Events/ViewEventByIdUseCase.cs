using EM.CoreBusiness;
using EM_UseCases.Events.interfaces;
using EM_UseCases.PluginInterfaces;

namespace EM_UseCases.Events
{
    public class ViewEventByIdUseCase : IViewEventByIdUseCase
    {
        private readonly IEventRepository eventRepository;

        public ViewEventByIdUseCase(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public async Task<Event> ExecuteAsync(int eventId)
        {
            // Використовуємо репозиторій для отримання події за ID
            return await eventRepository.GetEventByIdAsync(eventId);
        }
    }
}
