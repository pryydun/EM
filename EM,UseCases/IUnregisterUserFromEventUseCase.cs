using EM.CoreBusiness;

namespace EM_UseCases
{
    public interface IUnregisterUserFromEventUseCase
    {
        Task ExecuteAsync(UserEvent userEvent);
    }
}