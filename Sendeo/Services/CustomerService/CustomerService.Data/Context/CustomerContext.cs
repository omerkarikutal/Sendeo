using CustomerService.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Data.Context
{
    public class CustomerContext : DbContext
    {
        public CustomerContext()
        {

        }
        public CustomerContext(DbContextOptions<CustomerContext> options)
    : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
            .HasData(
                new Customer
                {
                    Id = 1,
                    Code = "Cust1",
                    Name = "Omer1",
                    Surname = "Karikutal1"
                },
                new Customer
                {
                    Id = 2,
                    Code = "Cust2",
                    Name = "Omer2",
                    Surname = "Karikutal2"
                },
                new Customer
                {
                    Id = 3,
                    Code = "Cust3",
                    Name = "Omer3",
                    Surname = "Karikutal3"
                }
                );
        }
    }
}
