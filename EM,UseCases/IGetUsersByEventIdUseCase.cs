


using EM.CoreBusiness;

namespace EM.UseCases
{
    public interface IGetUsersByEventIdUseCase
    {
        public Task<List<User>> ExecuteAsync(int eventId);
    }
}