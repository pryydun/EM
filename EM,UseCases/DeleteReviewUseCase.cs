using EM_UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_UseCases
{
    public class DeleteReviewUseCase : IDeleteReviewUseCase
    {
        private readonly IReviewRepository _reviewRepository;

        public DeleteReviewUseCase(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task ExecuteAsync(int reviewId)
        {
            await _reviewRepository.DeleteAsync(reviewId);
        }
    }
}
