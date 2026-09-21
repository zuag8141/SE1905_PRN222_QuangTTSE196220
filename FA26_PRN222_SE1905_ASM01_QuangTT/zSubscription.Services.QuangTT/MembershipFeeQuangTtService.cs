using zSubscription.Repositories.QuangTT;
using zSubscription.Entities.QuangTT.Models;

namespace zSubscription.Services.QuangTT
{
    public class MembershipFeeQuangTtService : IMembershipFeeQuangTtService
    {
        private readonly MembershipFeeQuangTtRepository _repository;

        public MembershipFeeQuangTtService(MembershipFeeQuangTtRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateAsync(MembershipFeeQuangTt membershipFee)
        {
            try 
            {
                return await _repository.CreateAsync(membershipFee);
            } 
            catch (Exception ex) { throw new ApplicationException("Error creating Membership fee " + ex.Message, ex); }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var item = await _repository.GetByIdAsync(id);
                return item != null && await _repository.RemoveAsync(item);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error deleting Membership fee " + ex.Message, ex);
            }
        }

        public async Task<List<MembershipFeeQuangTt>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex) { throw new ApplicationException("Error retrieving Membership fee list " + ex.Message, ex); }
        }

        public async Task<MembershipFeeQuangTt?> GetByIdAsync(int id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception ex) { throw new ApplicationException("Error retrieving Membership fee by ID " + ex.Message, ex); }
        }

        public async Task<List<MembershipFeeQuangTt>> SearchAsync(string? transCode, decimal? amount, string? payMethod)
        {
            try 
            {
                return await _repository.SearchAsync(amount, transCode, payMethod);
            } 
            catch (Exception ex) { throw new ApplicationException("Error searching Membership fee " + ex.Message, ex); }
        }

        public async Task<int> UpdateAsync(MembershipFeeQuangTt membershipFee)
        {
            try 
            {
                return await _repository.UpdateAsync(membershipFee);
            } 
            catch (Exception ex) { throw new ApplicationException("Error updating Membership fee " + ex.Message, ex); }
        }
    }
}
