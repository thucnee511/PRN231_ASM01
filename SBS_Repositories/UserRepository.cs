using Microsoft.EntityFrameworkCore;
using SBS_Repositories.Base;
using SBS_Repositories.Models;

namespace SBS_Repositories;

public class UserRepository : GenericRepository<UserAccount>
{
    public UserRepository() : base()
    {
    }

    public async Task<UserAccount?> Login(string username, string password)
        => await DbSet.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
}
