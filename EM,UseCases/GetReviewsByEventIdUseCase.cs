using EM.CoreBusiness;
using EM_UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases
{
    public class GetReviewsByEventIdUseCase: IGetReviewsByEventIdUseCase
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewsByEventIdUseCase(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<Review>> ExecuteAsync(int eventId)
        {
            return await _reviewRepository.GetReviewsByEventIdAsync(eventId);
        }
    }
}