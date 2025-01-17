using System;
using SBS_Repositories;
using SBS_Repositories.Models;
using SBS_Services.Interfaces;

namespace SBS_Services.Impls;

public class OrderDetailService : IOrderDetailService
{
    private readonly OrderDetailRepository _orderDetailRepository;

    public OrderDetailService() => _orderDetailRepository = new();

    public async Task<List<OrderDetail>> GetAllOrderDetails()
        => await _orderDetailRepository.GetAllAsync();
}
