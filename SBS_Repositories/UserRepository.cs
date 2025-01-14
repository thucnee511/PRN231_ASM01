using SBS_Repositories.Base;
using SBS_Repositories.Models;

namespace SBS_Repositories;

public class UserRepository : GenericRepository<UserAccount>
{
    public UserRepository() : base()
    {
    }
}
