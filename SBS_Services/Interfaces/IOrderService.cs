using System;
using SBS_Repositories.Models;

namespace SBS_Services.Interfaces;

public interface IOrderService
{
    Task<List<Order>> GetAll();
    Task<Order?> GetById(Guid id);
    Task<int> Insert(Order order);
    Task<int> Update(Order order);
    Task<int> Delete(Order order);

    Task<List<Order>> Search(string noteHolder, double minValue, double maxValue, string serviceNameHolder);
}
