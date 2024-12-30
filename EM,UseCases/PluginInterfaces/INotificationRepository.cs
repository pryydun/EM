using EM.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases.PluginInterfaces
{
    public interface INotificationRepository
    {
        Task AddAsync(Notification notification);
        Task<List<Notification>> GetByRecipientIdAsync(string recipientId);
        Task MarkAsReadAsync(int notificationId);
        Task DeleteAsync(int notificationId);
    }
}
