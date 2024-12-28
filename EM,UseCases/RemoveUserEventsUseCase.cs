using EM_UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases
{
    public class RemoveUserEventsUseCase : IRemoveUserEventsUseCase
    {
        private readonly IUserEventRepository _userEventRepository;

        public RemoveUserEventsUseCase(IUserEventRepository userEventRepository)
        {
            _userEventRepository = userEventRepository;
        }

        public async Task ExecuteAsync(string userId)
        {
            // Видаляємо всі записи про користувача з таблиці UserEvents через репозиторій
            await _userEventRepository.DeleteUserEventsByUserIdAsync(userId);
        }
    }
}
