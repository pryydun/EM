using EM.CoreBusiness;
using EM.Plugins.EFCoreSQL;
using EM_UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Plugins.EFCoreSQLServer
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly EMContext _context;

        public NotificationRepository(EMContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Notification notification)
        {
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Notification>> GetByRecipientIdAsync(string recipientId)
        {
            return await _context.Notifications
                .Where(n => n.RecipientId == recipientId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task MarkAsReadAsync(int notificationId)
        {
            var notification = await _context.Notifications.FindAsync(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(int notificationId)
        {
            var notification = await _context.Notifications.FindAsync(notificationId);
            if (notification != null)
            {
                _context.Notifications.Remove(notification);
                await _context.SaveChangesAsync();
            }
        }
        public async Task AddRangeAsync(IEnumerable<Notification> notifications)
        {
            _context.Notifications.AddRange(notifications);
            await _context.SaveChangesAsync();
        }
    }
}
