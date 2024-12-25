using EM.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases.PluginInterfaces
{
    public interface IEventRepository
    {
        public Task AddEventsAsync(Event newEvent);
       public Task DeleteEventByIdAsync(int eventId);
       public Task<IEnumerable<Event>> GetAllEventsAsync();
      public  Task<Event> GetEventByIdAsync(int eventId);
       public Task<IEnumerable<Event>> GetEventsByNameAsync(string name);
       public Task UpdateEventAsync(Event updatedEvent);
    }

}
