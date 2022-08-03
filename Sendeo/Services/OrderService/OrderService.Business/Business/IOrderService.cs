using OrderService.Core.Dto;
using OrderService.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Business.Business
{
    public interface IOrderService
    {
        List<OrderList> GetAll();
    }
}
