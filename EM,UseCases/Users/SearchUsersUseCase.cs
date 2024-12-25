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
    namespace EM_UseCases.Users
    {
        public class SearchUsersUseCase: ISearchUsersUseCase
        {
            private readonly IUserRepository userRepository;

            public SearchUsersUseCase(IUserRepository userRepository)
            {
                this.userRepository = userRepository;
            }

            public async Task<IEnumerable<User>> ExecuteAsync(string searchText)
            {
                return await userRepository.SearchUsersAsync(searchText); // Пошук через репозиторій
            }
        }
    }
}
