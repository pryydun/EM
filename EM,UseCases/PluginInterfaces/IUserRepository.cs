using EM.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases.PluginInterfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAllUsersAsync();
         
        public Task<IEnumerable<User>> SearchUsersAsync(string searchText);
        

    }
}
