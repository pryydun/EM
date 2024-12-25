using EM.CoreBusiness;

namespace EM_UseCases.Events.interfaces
{
    public interface IAddEventsUseCase
    {
        Task ExecuteAsync(Event newEvent);
    }
}