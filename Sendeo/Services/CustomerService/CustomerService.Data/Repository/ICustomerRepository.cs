using CustomerService.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Data.Repository
{
    public  interface ICustomerRepository
    {
        Customer? GetCustomer(string code);
    }
}
