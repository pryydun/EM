using EM.CoreBusiness;
using EM.Plugins.EFCoreSQL;
using EM_UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Plugins.EFCoreSQLServer
{
    public class EventEFCoreRepository : IEventRepository
    {
        private readonly IDbContextFactory<EMContext> _contextFactory;

        public EventEFCoreRepository(IDbContextFactory<EMContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task AddEventsAsync(Event newEvent)
        {
            using var db = _contextFactory.CreateDbContext();
            db.Events?.Add(@newEvent);
            await db.SaveChangesAsync();
        }

        public async Task DeleteEventByIdAsync(int eventId)
        {
            using var db = _contextFactory.CreateDbContext();
            var existingEvent = await db.Events.FindAsync(eventId);
            if (existingEvent != null)
            {
                db.Events.Remove(existingEvent);
                await db.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            using var db = _contextFactory.CreateDbContext();
            return await db.Events.ToListAsync() ?? Enumerable.Empty<Event>();
        }

        public async Task<Event> GetEventByIdAsync(int eventId)
        {
            using var db = _contextFactory.CreateDbContext();
            return await db.Events.FindAsync(eventId) ?? throw new Exception("Event not found.");
        }

        public async Task<IEnumerable<Event>> GetEventsByNameAsync(string name)
        {
            using var db = _contextFactory.CreateDbContext();
            return await db.Events
                .Where(e => EF.Functions.Like(e.Title, $"%{name}%"))
                .ToListAsync() ?? Enumerable.Empty<Event>();
        }

        public async Task UpdateEventAsync(Event updatedEvent)
        {
            using var db = _contextFactory.CreateDbContext();
            var existingEvent = await db.Events.FindAsync(updatedEvent.Id);
            if (existingEvent != null)
            {
                existingEvent.Title = updatedEvent.Title;
                existingEvent.Description = updatedEvent.Description;
                existingEvent.StartDate = updatedEvent.StartDate;
                existingEvent.EndDate = updatedEvent.EndDate;
                existingEvent.Location = updatedEvent.Location;
                existingEvent.ImagePath = updatedEvent.ImagePath;
                await db.SaveChangesAsync();
            }
        }
    }
}
