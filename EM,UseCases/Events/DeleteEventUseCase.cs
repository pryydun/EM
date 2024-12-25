using EM_UseCases.Events.interfaces;
using EM_UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases.Events
{
    public class DeleteEventUseCase : IDeleteEventUseCase
    {
        private readonly IEventRepository eventRepository;

        public DeleteEventUseCase(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public async Task ExecuteAsync(int eventId)
        {
            await eventRepository.DeleteEventByIdAsync(eventId);
        }
    }
}
