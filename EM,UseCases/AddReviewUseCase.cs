using EM.CoreBusiness;
using EM_UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases
{
    public class AddReviewUseCase: IAddReviewUseCase
    {
        private readonly IReviewRepository _reviewRepository;

        public AddReviewUseCase(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task ExecuteAsync(Review review)
        {
            await _reviewRepository.AddReviewAsync(review);
        }
    }
}
