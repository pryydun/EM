using EM.CoreBusiness;
using EM_UseCases.PluginInterfaces;
using EM_UseCases.Users.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases.Users
{
    public class ViewUsersByNameUseCase : IViewUsersByNameUseCase
    {
        private readonly IUserRepository _userRepository;

        public ViewUsersByNameUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> ExecuteAsync(string name = "")
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return await _userRepository.GetAllUsersAsync();
            }

            return await _userRepository.SearchUsersAsync(name);
        }
    }
}
