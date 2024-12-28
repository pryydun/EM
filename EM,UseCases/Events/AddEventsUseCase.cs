using EM.CoreBusiness;
using EM_UseCases.Events.interfaces;
using EM_UseCases.PluginInterfaces;

namespace EM_UseCases.Events
{
    public class AddEventsUseCase : IAddEventsUseCase
    {
        private readonly IEventRepository eventRepository;

        public AddEventsUseCase(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public async Task ExecuteAsync(Event newEvent)
        {
            await eventRepository.AddEventsAsync(newEvent);
        }
    }
}
