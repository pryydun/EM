using EM.CoreBusiness;

namespace EM_UseCases.Events.interfaces
{
    public interface IEditEventUseCase
    {
        public Task ExecuteAsync(Event updatedEvent);
    }
}