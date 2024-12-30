using EM.CoreBusiness;

namespace EM_UseCases
{
    public interface IAddReviewUseCase
    {
        public Task ExecuteAsync(Review review);

    }
}