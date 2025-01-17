using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBS_Repositories.Models;
using SBS_Services.Impls;
using SBS_Services.Interfaces;

namespace SBS_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        
        public OrderController(IOrderService orderService)
            => this.orderService = orderService;

        [HttpGet]
        public async Task<List<Order>> GetAll()
            => await orderService.GetAll();

        [HttpGet("{id}")]
        public async Task<Order?> GetById(Guid id)
            => await orderService.GetById(id);

        [HttpGet("Search")]
        public async Task<List<Order>> Search(
            [FromQuery] string noteHolder, 
            [FromQuery] double minValue, 
            [FromQuery] double maxValue, 
            [FromQuery] string serviceNameHolder)
            => await orderService.Search(noteHolder, minValue, maxValue, serviceNameHolder);

        [HttpPost]
        public async Task<int> Insert(Order order)
            => await orderService.Insert(order);

        [HttpPut]
        public async Task<int> Update(Order order)
            => await orderService.Update(order);
        
        [HttpDelete]
        public async Task<int> Delete(Order order)
            => await orderService.Delete(order);
    }
}
