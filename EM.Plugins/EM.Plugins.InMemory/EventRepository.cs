using EM.CoreBusiness;
using EM_UseCases.PluginInterfaces;

namespace EM.Plugins.InMemory
{
    public class EventRepository : IEventRepository
    {
        private readonly List<Event> _events;

        public EventRepository()
        {
            _events = new List<Event>
            {
                new Event
                {
                    Id = 1,
                    Title = "Tech Conference",
                    Description = "A conference for tech enthusiasts to discuss innovations and trends.",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1),
                    Location = "Kyiv Tech Hub"
                },
                new Event
                {
                    Id = 2,
                    Title = "Music Festival",
                    Description = "An open-air festival featuring popular artists and bands.",
                    StartDate = DateTime.Now.AddMonths(1),
                    EndDate = DateTime.Now.AddMonths(1).AddDays(2),
                    Location = "Lviv Open Stage"
                },
                new Event
                {
                    Id = 3,
                    Title = "Startup Meetup",
                    Description = "A networking event for startup founders and investors.",
                    StartDate = DateTime.Now.AddDays(10),
                    EndDate = DateTime.Now.AddDays(11),
                    Location = "Odesa Innovation Center"
                }
            };
        
    }

        public async Task AddEventsAsync(Event newEvent)
        {
            if (_events.Any(e => e.Title.Equals(newEvent.Title, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }

            // Assign a unique ID to the new event
            var maxId = _events.Max(e => e.Id);
            newEvent.Id = maxId + 1;

            // Add the event to the list
            _events.Add(newEvent);

            await Task.CompletedTask;
        }

        public async Task DeleteEventByIdAsync(int eventId)
        {
            var eventToDelete = _events.FirstOrDefault(e => e.Id == eventId);
            if (eventToDelete != null)
            {
                _events.Remove(eventToDelete);
            }
            await Task.CompletedTask;
        }

        public Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return Task.FromResult(_events.AsEnumerable());
        }

        public Task<Event> GetEventByIdAsync(int eventId)
        {
            var eventToReturn = _events.FirstOrDefault(x => x.Id == eventId);
            if (eventToReturn == null)
            {
                throw new InvalidOperationException($"Event with ID {eventId} not found.");
            }

            return Task.FromResult(eventToReturn);
        }



        public Task<IEnumerable<Event>> GetEventsByNameAsync(string name)
        {
            var result = _events.Where(e => e.Title.Contains(name, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(result.AsEnumerable());
        }
        public async Task UpdateEventAsync(Event updatedEvent)
        {

            if (_events.Any(x => x.Id != updatedEvent.Id && x.Title.Equals(updatedEvent.Title, StringComparison.OrdinalIgnoreCase)))
            { await Task.CompletedTask; }
            var existingEvent = _events.FirstOrDefault(e => e.Id == updatedEvent.Id);
            if (existingEvent != null)
            {
                existingEvent.Id = updatedEvent.Id;
                existingEvent.Title = updatedEvent.Title;
                existingEvent.Description = updatedEvent.Description;
                existingEvent.StartDate = updatedEvent.StartDate;
                existingEvent.EndDate = updatedEvent.EndDate;
                existingEvent.Location = updatedEvent.Location;
            }

            await Task.CompletedTask;

        }
    }
}
