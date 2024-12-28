using EM.CoreBusiness;
using EM.Plugins.EFCoreSQL;
using EM_UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserEventEFCoreRepository : IUserEventRepository
{
    private readonly EMContext _context;

    public UserEventEFCoreRepository(EMContext context)
    {
        _context = context;
    }

    public async Task AddUserToEventAsync(UserEvent userEvent)
    {
        _context.UserEvents.Add(userEvent);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Event>> GetEventsByUserIdAsync(string userId)
    {
        return await _context.UserEvents
            .Where(ue => ue.UserId == userId)
            .Select(ue => ue.Event) // Використовуємо навігаційну властивість
            .ToListAsync();
    }

    public async Task<List<UserEvent>> GetUsersByEventIdAsync(int eventId)
    {
        return await _context.UserEvents
            .Where(ue => ue.EventId == eventId)
            .ToListAsync();
    }
    public async Task RemoveUserFromEventAsync(UserEvent userEvent)
    {
        var entity = await _context.UserEvents
            .FirstOrDefaultAsync(e => e.UserId == userEvent.UserId && e.EventId == userEvent.EventId);

        if (entity != null)
        {
            _context.UserEvents.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
    public async Task DeleteUserEventsByUserIdAsync(string userId)
    {
        var userEvents = await _context.UserEvents.Where(ue => ue.UserId == userId).ToListAsync();
        if (userEvents.Any())
        {
            _context.UserEvents.RemoveRange(userEvents);
            await _context.SaveChangesAsync();
        }
    }

}
