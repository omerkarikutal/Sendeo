using CustomerService.Data.Context;
using CustomerService.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CustomerTest
{
    public class Customer
    {
        [Fact]
        public void GetCustomer()
        {
            // arrange
            var context = CreateCustomerContext();
            var service = new CustomerRepository(context.Object);

            // act
            var results = service.GetCustomer("Cust1");

            // assert
            Assert.Equal("Cust1", results.Code);

        }
        private Mock<CustomerContext> CreateCustomerContext()
        {
            var persons = FakeData().AsQueryable();

            var dbSet = new Mock<DbSet<CustomerService.Core.Entity.Customer>>();
            dbSet.As<IQueryable<CustomerService.Core.Entity.Customer>>().Setup(m => m.Provider).Returns(persons.Provider);
            dbSet.As<IQueryable<CustomerService.Core.Entity.Customer>>().Setup(m => m.Expression).Returns(persons.Expression);
            dbSet.As<IQueryable<CustomerService.Core.Entity.Customer>>().Setup(m => m.ElementType).Returns(persons.ElementType);
            dbSet.As<IQueryable<CustomerService.Core.Entity.Customer>>().Setup(m => m.GetEnumerator()).Returns(persons.GetEnumerator());

            var context = new Mock<CustomerContext>();
            context.Setup(c => c.Customer).Returns(dbSet.Object);
            return context;

        }
        private IEnumerable<CustomerService.Core.Entity.Customer> FakeData()
        {
            return new List<CustomerService.Core.Entity.Customer>
           {
               new CustomerService.Core.Entity.Customer
               {
                   Id = 1,
                   Code = "Cust1",
                   Name="Test1",
                   Surname = "Asd1"
               },
               new CustomerService.Core.Entity.Customer
               {
                   Id = 2,
                   Code = "Cust2",
                   Name="Test2",
                   Surname = "Asd2"
               }
           };
        }
    }
}