using EM.CoreBusiness;
using EM_UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace EM_UseCases.Events
{
    
        public class RegisterUserToEventUseCase
        {
            private readonly IUserEventRepository _userEventRepository;

            public RegisterUserToEventUseCase(IUserEventRepository userEventRepository)
            {
                _userEventRepository = userEventRepository;
            }

            public async Task ExecuteAsync(UserEvent userEvent)
            {
                await _userEventRepository.AddUserToEventAsync(userEvent);
            }
        }
    }