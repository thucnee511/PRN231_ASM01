using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBS_Repositories.Models;
using SBS_Services.Interfaces;

namespace SBS_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
            => this.userService = userService;

        [HttpGet]
        public async Task<List<UserAccount>> GetAll()
            => await userService.GetAllUsers();
    }
}
