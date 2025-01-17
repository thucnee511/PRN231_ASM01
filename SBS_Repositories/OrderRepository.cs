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
}
