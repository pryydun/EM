using EM.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases.PluginInterfaces
{
    public interface IUserEventRepository
    {

        Task AddUserToEventAsync(UserEvents userEvent);
        Task<IEnumerable<User>> GetUsersByEventIdAsync(int eventId);

    }
}
