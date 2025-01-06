using EM.CoreBusiness;

namespace EM_UseCases.Events.interfaces
{
    public interface IGetEventsByOrganizer
    {
        Task<IEnumerable<Event>> ExecuteAsync(string organizerId);
    }
}