using CustomerService.Data.Repository;
using Grpc.Core;

namespace CustomerService.Grpc.Services
{
    public class CustomerService : Customer.CustomerBase
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public override Task<CustomerModel> GetCustomer(GetCustomerRequest request, ServerCallContext context)
        {
            var result = _repository.GetCustomer(request.Code);

            var model = new CustomerModel
            {
                Id = result.Id,
                Code = result.Code,
                NameSurname = result.Name + " " + result.Surname
            };

            return Task.FromResult(model);
        }
    }
}
