using OrderService.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Data.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
    }
}
