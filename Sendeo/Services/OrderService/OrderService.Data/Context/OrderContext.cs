using Microsoft.EntityFrameworkCore;
using OrderService.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Data.Context
{
    public class OrderContext:DbContext
    {
        public OrderContext()
        {

        }
        public OrderContext(DbContextOptions<OrderContext> options)
: base(options)
        {
        }

        public virtual DbSet<Order> Order { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
            .HasData(
                new Order
                {
                    Id = 1,
                    Category = "Cat1",
                    Customer = "Cust1",
                    CompleteDate = DateTime.Now.AddDays(-1)
                },
                new Order
                {
                    Id = 2,
                    Category = "Cat2",
                    Customer = "Cust2",
                    CompleteDate = DateTime.Now.AddDays(-2)

                },
                 new Order
                 {
                     Id = 3,
                     Category = "Cat3",
                     Customer = "Cust3",
                     CompleteDate = DateTime.Now.AddDays(-3)

                 }
    );

        }
    }
}
