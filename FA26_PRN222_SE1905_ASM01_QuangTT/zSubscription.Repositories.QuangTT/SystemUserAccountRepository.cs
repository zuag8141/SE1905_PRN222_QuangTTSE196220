using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zSubscription.Entities.QuangTT.Models;
using zSubscription.Repositories.QuangTT.DBContext;

namespace zSubscription.Repositories.QuangTT
{
     public class SystemUserAccountRepository : GenericRepository<SystemUserAccount>
    {
        public SystemUserAccountRepository() { }
        public SystemUserAccountRepository(PRN222Context context) : base(context) { }
        public async Task<SystemUserAccount?> GetByUserNameAsync(string userName, string password)
        {
            return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.Email == userName && u.Password == password && u.IsActive);
        }
    }
}
