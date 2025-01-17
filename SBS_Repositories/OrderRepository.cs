using System;
using Microsoft.EntityFrameworkCore;
using SBS_Repositories.Base;
using SBS_Repositories.Models;

namespace SBS_Repositories;

public class OrderRepository : GenericRepository<Order>
{
    public OrderRepository() : base()
    {
    }

    public new async Task<List<Order>> GetAllAsync()
        => await DbSet.Include(o => o.OrderDetails).ToListAsync();

    public async Task<Order?> GetByIdAsync(Guid id)
        => await DbSet.Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.Id == id);

    public async Task<List<Order>> Search(string noteHolder, double minValue, double maxValue, string serviceNameHolder)
    {
        return await DbSet.Include(o => o.OrderDetails)
            .Where(o =>
                (string.IsNullOrEmpty(noteHolder) || o.OrderNote.Contains(noteHolder)) &&
                (minValue == 0 || o.TotalPrice >= minValue) &&
                (maxValue == 0 || o.TotalPrice <= maxValue) &&
                (string.IsNullOrEmpty(serviceNameHolder) || o.OrderDetails.Any(od => od.ServiceName.Contains(serviceNameHolder)))
            ).ToListAsync();
    }
}
