using zSubscription.Repositories.QuangTT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zSubscription.Entities.QuangTT.Models;

namespace zSubscription.Services.QuangTT
{
    public class FeePackageQuangTtService : IFeePackageQuangTtService
    {
        private readonly FeePackageQuangTtRepository _repository;

        public FeePackageQuangTtService(FeePackageQuangTtRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FeePackageQuangTt>> GetAllAsync()
        {
            try 
            {
                return await _repository.GetAllAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Error in GetAllAsync", ex);
            }
        }
    }
}
