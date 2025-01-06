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
    public class GetEventsByOrganizer: IGetEventsByOrganizer
    {
        private readonly IEventRepository _eventRepository;

        public GetEventsByOrganizer(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<Event>> ExecuteAsync(string organizerId)
        {
             

            return await _eventRepository.GetEventsByOrganizerAsync(organizerId);
        }
    }

}
