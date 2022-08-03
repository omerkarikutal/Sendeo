using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Core.Dto
{
    public class OrderList
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string Category { get; set; }
        public DateTime CompleteDate { get; set; }
    }
}
