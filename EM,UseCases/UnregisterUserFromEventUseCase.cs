using EM.CoreBusiness;
using EM_UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases
{
    public class UnregisterUserFromEventUseCase : IUnregisterUserFromEventUseCase
    {
        private readonly IUserEventRepository _userEventRepository;

        public UnregisterUserFromEventUseCase(IUserEventRepository userEventRepository)
        {
            _userEventRepository = userEventRepository;
        }

        public async Task ExecuteAsync(UserEvent userEvent)
        {
            await _userEventRepository.RemoveUserFromEventAsync(userEvent);
        }
    }
}

