using System;
using SBS_Repositories;
using SBS_Repositories.Models;
using SBS_Services.Interfaces;

namespace SBS_Services.Impls;

public class AuthService : IAuthService
{
    private readonly UserRepository _userRepository;

    public AuthService() => _userRepository = new();

    public Task<UserAccount?> Login(string username, string password)
        => _userRepository.Login(username, password);
}
