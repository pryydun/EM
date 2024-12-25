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
    private readonly IDbContextFactory<EMContext> _contextFactory;

    public UserEventEFCoreRepository(IDbContextFactory<EMContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task AddUserToEventAsync(UserEvents userEvent)
    {
        using var db = _contextFactory.CreateDbContext();
        db.UserEvents.Add(userEvent);
        await db.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetUsersByEventIdAsync(int eventId)
    {
        using var db = _contextFactory.CreateDbContext();
        return await db.UserEvents
            .Where(ue => ue.EventId == eventId)
            .Include(ue => ue.User)
            .Select(ue => ue.User)
            .ToListAsync();
    }
}