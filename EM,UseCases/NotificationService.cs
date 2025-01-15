using EM.CoreBusiness;
using EM_UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases
{
    public class NotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task AddNotificationAsync(string recipientId, string title, string message, string sender)
        {
            var notification = new Notification
            {
                RecipientId = recipientId,
                Title = title,
                Message = message,
                IsRead = false,
                CreatedAt = DateTime.UtcNow,
                Sender = sender
            };

            await _notificationRepository.AddAsync(notification);
        }

        public async Task<List<Notification>> GetNotificationsAsync(string recipientId)
        {
            return await _notificationRepository.GetByRecipientIdAsync(recipientId);
        }

        public async Task MarkAsReadAsync(int notificationId)
        {
            await _notificationRepository.MarkAsReadAsync(notificationId);
        }
        public async Task DeleteNotificationAsync(int notificationId)
        {
            await _notificationRepository.DeleteAsync(notificationId);
        }

        public async Task AddNotificationToAllAsync(string title, string message, string sender, List<string> userIds)
        {
            var notifications = userIds.Select(userId => new Notification
            {
                RecipientId = userId,
                Title = title,
                Message = message,
                IsRead = false,
                CreatedAt = DateTime.UtcNow,
                Sender = sender
            }).ToList();

            await _notificationRepository.AddRangeAsync(notifications); // Масове додавання сповіщень
        }

    }
}
