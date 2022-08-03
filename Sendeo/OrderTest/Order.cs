using Moq;
using OrderService.Data.Context;
using OrderService.Data.Repository;
using OrderService.Business.Business;
using Microsoft.EntityFrameworkCore;

namespace OrderTest
{
    public class Order
    {
    
        [Fact]
        public void GetAllOrder()
        {
            // arrange
            var context = CreateOrderContext();
            var service = new OrderRepository(context.Object);

            // act
            var results = service.GetAll();
            var count = results.Count();

            // assert
            Assert.Equal(2, count);

        }
        private Mock<OrderContext> CreateOrderContext()
        {
            var persons = FakeData().AsQueryable();

            var dbSet = new Mock<DbSet<OrderService.Core.Entity.Order>>();
            dbSet.As<IQueryable<OrderService.Core.Entity.Order>>().Setup(m => m.Provider).Returns(persons.Provider);
            dbSet.As<IQueryable<OrderService.Core.Entity.Order>>().Setup(m => m.Expression).Returns(persons.Expression);
            dbSet.As<IQueryable<OrderService.Core.Entity.Order>>().Setup(m => m.ElementType).Returns(persons.ElementType);
            dbSet.As<IQueryable<OrderService.Core.Entity.Order>>().Setup(m => m.GetEnumerator()).Returns(persons.GetEnumerator());

            var context = new Mock<OrderContext>();
            context.Setup(c => c.Order).Returns(dbSet.Object);
            return context;

        }
        private IEnumerable<OrderService.Core.Entity.Order> FakeData()
        {
            return new List<OrderService.Core.Entity.Order>
           {
               new OrderService.Core.Entity.Order
               {
                   Id = 1,
                   Category = "Cat1",
                   Customer = "Cust1",
                   CompleteDate = DateTime.Now
               },
               new OrderService.Core.Entity.Order
               {
                   Id = 2,
                   Category = "Cat2",
                   Customer = "Cust2",
                   CompleteDate = DateTime.Now
               }
           };
        }
    }
}