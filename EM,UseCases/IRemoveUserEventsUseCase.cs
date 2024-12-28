using EM_UseCases.PluginInterfaces;

namespace EM_UseCases
{
    public interface IRemoveUserEventsUseCase
    {
        Task ExecuteAsync(string userId);
    }
}