using EM.CoreBusiness;

namespace EM_UseCases.Events.interfaces
{
    public interface IViewEventByIdUseCase
    {
        public Task<Event> ExecuteAsync(int eventId);
    }
}