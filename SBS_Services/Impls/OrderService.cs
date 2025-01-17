using System;
using SBS_Repositories;
using SBS_Repositories.Models;
using SBS_Services.Interfaces;

namespace SBS_Services.Impls;

public class OrderService : IOrderService
{
    private readonly OrderRepository _orderRepository;
    public OrderService() : base()
        => _orderRepository = new();

    public async Task<int> Delete(Order order)
        => await _orderRepository.DeleteAsync(order);

    public async Task<List<Order>> GetAll()
        => await _orderRepository.GetAllAsync();

    public async Task<Order?> GetById(Guid id)
        => await _orderRepository.GetByIdAsync(id);

    public async Task<int> Insert(Order order)
        => await _orderRepository.InsertAsync(order);

    public async Task<List<Order>> Search(string noteHolder, double minValue, double maxValue, string serviceNameHolder)
        => await _orderRepository.Search(noteHolder, minValue, maxValue, serviceNameHolder);

    public async Task<int> Update(Order order)
        => await _orderRepository.UpdateAsync(order);
}
