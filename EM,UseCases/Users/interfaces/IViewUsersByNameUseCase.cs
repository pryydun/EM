using EM.CoreBusiness;

namespace EM_UseCases.Users.interfaces
{
    public interface IViewUsersByNameUseCase
    {
        Task<IEnumerable<User>> ExecuteAsync(string name = "");
    }
}