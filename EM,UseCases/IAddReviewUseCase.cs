using EM.CoreBusiness;
using EM_UseCases.PluginInterfaces;

namespace EM_UseCases
{
    public interface IAddReviewUseCase
    {
        public Task ExecuteAsync(Review review);
         
    }
}