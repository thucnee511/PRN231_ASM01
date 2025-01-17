using System;
using SBS_Repositories.Models;

namespace SBS_Services.Interfaces;

public interface IAuthService
{
    Task<UserAccount?> Login(string username, string password);
}
