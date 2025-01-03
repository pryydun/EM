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
    public class GetUpcomingEventsUseCase : IGetUpcomingEventsUseCase
    {
        private readonly IEventRepository _eventRepository;

        public GetUpcomingEventsUseCase(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }


        public async Task<IEnumerable<Event>> ExecuteAsync()
        {
            var events = await _eventRepository.GetAllAsync();
            return events
                .Where(e => e.StartDate > DateTime.Now)
                .OrderBy(e => e.StartDate)
                .Select(e => new Event
                {
                    Id = e.Id,
                    Title = e.Title,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Location = e.Location,
                    ImagePath = e.ImagePath
                });
        }
    }
}
