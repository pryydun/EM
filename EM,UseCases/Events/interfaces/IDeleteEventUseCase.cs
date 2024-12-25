namespace EM_UseCases.Events.interfaces
{
    public interface IDeleteEventUseCase
    {
        Task ExecuteAsync(int eventId);
    }
}