using EM.CoreBusiness;

namespace EM_UseCases.Users.interfaces
{
    public interface ISearchUsersUseCase
    {
        Task<IEnumerable<User>> ExecuteAsync(string searchText);
    }
}