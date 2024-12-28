
using EM.CoreBusiness;
using EM_UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 


namespace EM.UseCases
{
    public class GetUsersByEventIdUseCase: IGetUsersByEventIdUseCase
    {
        private readonly IUserEventRepository _userEventRepository;

        public GetUsersByEventIdUseCase(IUserEventRepository userEventRepository)
        {
            _userEventRepository = userEventRepository;
        }

        public async Task<List<User>> ExecuteAsync(int eventId)
        {
            var userEvents = await _userEventRepository.GetUsersByEventIdAsync(eventId);

            return userEvents.Select(ue => new User
            {   Id= ue.UserId,
                Name = ue.Name,
                Email = ue.UserId // або отримуйте пошту, якщо потрібно
            }).ToList();
        }



    }

     


}
