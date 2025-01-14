using SBS_Repositories;
using SBS_Repositories.Models;
using SBS_Services.Interfaces;

namespace SBS_Services.Impls;

public class UserService : IUserService
{
    private readonly UserRepository _userRepository;

    public UserService()
    {
        _userRepository = new();
    }

    public async Task<int> DeleteUser(UserAccount user)
    {
        return await _userRepository.DeleteAsync(user);
    }

    public async Task<List<UserAccount>> GetAllUsers()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<UserAccount?> GetUserById(object id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<int> InsertUser(UserAccount user)
    {
        return await _userRepository.InsertAsync(user);
    }

    public async Task<int> UpdateUser(UserAccount user)
    {
        return await _userRepository.UpdateAsync(user);
    }
}
