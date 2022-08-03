using CustomerService.Core.Entity;
using CustomerService.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;
        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }
        public Customer? GetCustomer(string code)
        {
            return _context.Customer.FirstOrDefault(s => s.Code == code);
        }
    }
}
