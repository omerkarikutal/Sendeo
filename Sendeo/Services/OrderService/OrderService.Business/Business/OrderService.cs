using OrderService.Core.Entity;
using OrderService.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryService.Grpc;
using CustomerService.Grpc;
using OrderService.Core.Dto;

namespace OrderService.Business.Business
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly Category.CategoryClient _categoryClient;
        private readonly Customer.CustomerClient _customerClient;
        public OrderService(IOrderRepository repository, Category.CategoryClient categoryClient, Customer.CustomerClient customerClient)
        {
            _repository = repository;
            _categoryClient = categoryClient;
            _customerClient = customerClient;
        }
        public List<OrderList> GetAll()
        {
            var result = new List<OrderList>();
            var data = _repository.GetAll();

            foreach (var item in data)
            {
                var custm = _customerClient.GetCustomer(new GetCustomerRequest { Code = item.Customer });
                var ctg = _categoryClient.GetCategory(new GetCategoryRequest { Code = item.Category });

                var ord = new OrderList
                {
                    Id = item.Id,
                    CompleteDate = item.CompleteDate,
                    Category = ctg.Name,
                    Customer = custm.NameSurname
                };

                result.Add(ord);
            }

            return result;
        }
    }
}
