using EM.CoreBusiness;

namespace EM_UseCases
{
    public interface IGetReviewsByEventIdUseCase
    {
        public Task<List<Review>> ExecuteAsync(int eventId);
    }
}