using EM.CoreBusiness;
using EM.Plugins.EFCoreSQL;
using EM_UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Plugins.EFCoreSQLServer
{
    public class UserEFCoreRepository : IUserRepository
    {
        private readonly IDbContextFactory<EMContext> _contextFactory;

        public UserEFCoreRepository(IDbContextFactory<EMContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
       public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            using var db = _contextFactory.CreateDbContext();
            return await db.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> SearchUsersAsync(string searchText)
        {
            using var db = _contextFactory.CreateDbContext();
            return await db.Users
                .Where(u => EF.Functions.Like(u.Name, $"%{searchText}%") ||
                            EF.Functions.Like(u.Email, $"%{searchText}%"))
                .ToListAsync();
        }

        
    }
}
