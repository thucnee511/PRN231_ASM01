using SBS_Repositories.Models;

namespace SBS_Services.Interfaces;

public interface IUserService
{
    Task<List<UserAccount>> GetAllUsers();
    Task<UserAccount?> GetUserById(object id);
    Task<int> InsertUser(UserAccount user);
    Task<int> UpdateUser(UserAccount user);
    Task<int> DeleteUser(UserAccount user);
}
