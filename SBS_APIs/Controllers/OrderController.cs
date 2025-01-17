using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBS_Repositories.Models;
using SBS_Services.Impls;
using SBS_Services.Interfaces;

namespace SBS_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : ControllerBase
    {

        [HttpGet]
        public async Task<List<Order>> GetAll()
            => await orderService.GetAll();
    }
}
