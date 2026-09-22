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
    public class MembershipFeeQuangTtRepository : GenericRepository<MembershipFeeQuangTt>
    {
        public MembershipFeeQuangTtRepository() { }
        public MembershipFeeQuangTtRepository(PRN222Context context) : base(context) { }

        public override async Task<List<MembershipFeeQuangTt>> GetAllAsync()
        {
            return await _context.MembershipFeeQuangTts.Include(c => c.FeePackageQuangTt).ToListAsync();
        }
        public override async Task<MembershipFeeQuangTt?> GetByIdAsync(int id)
        {
            return await _context.MembershipFeeQuangTts.Include(c => c.FeePackageQuangTt).FirstOrDefaultAsync(c => c.MembershipFeeQuangTtid == id);
        }
        public async Task<List<MembershipFeeQuangTt>> SearchAsync(decimal? amount, string? transCode, string? payMethod)
        {
            return await _context.MembershipFeeQuangTts
                .Include(c => c.FeePackageQuangTt)
                .Where(c =>
                    (!amount.HasValue || c.Amount == amount.Value) &&
                    (string.IsNullOrEmpty(transCode) || (c.TransactionCode != null && c.TransactionCode.Contains(transCode))) &&
                    (string.IsNullOrEmpty(payMethod) || (c.PaymentMethod != null && c.PaymentMethod.Contains(payMethod))))
                .ToListAsync();
        }
    }
}
