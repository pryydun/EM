using EM.CoreBusiness;

namespace EM_UseCases.Events.interfaces
{
    public interface IViewEventsByNameUseCase
    {
        Task<IEnumerable<Event>> ExecuteAsync(string name = "");
    }
}