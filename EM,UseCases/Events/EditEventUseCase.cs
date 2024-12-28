using EM.CoreBusiness;
using EM_UseCases.Events.interfaces;
using EM_UseCases.PluginInterfaces;

namespace EM_UseCases.Events
{
    public class EditEventUseCase : IEditEventUseCase
    {
        private readonly IEventRepository _eventRepository;

        public EditEventUseCase(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task ExecuteAsync(Event updatedEvent)
        {
            await _eventRepository.UpdateEventAsync(updatedEvent);
        }
    }

}
