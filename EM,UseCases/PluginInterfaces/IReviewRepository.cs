using EM.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases.PluginInterfaces
{
   public interface IReviewRepository
    {
        public Task AddReviewAsync(Review review);
        public Task<List<Review>> GetReviewsByEventIdAsync(int eventId);
        Task DeleteAsync(int reviewId);
    }
}
