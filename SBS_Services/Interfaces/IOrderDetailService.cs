using System;
using SBS_Repositories.Models;

namespace SBS_Services.Interfaces;

public interface IOrderDetailService
{
    Task<List<OrderDetail>> GetAllOrderDetails();
}
