using CategoryService.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryService.Data.Context
{
    public class CategoryContext:DbContext
    {
        public CategoryContext()
        {

        }
        public CategoryContext(DbContextOptions<CategoryContext> options)
    : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
            .HasData(
                new Category
                {
                    Id = 1,
                    Code = "Cat1",
                    Name = "Cat1",
                },
                new Category
                {
                    Id = 2,
                    Code = "Cat2",
                    Name = "Cat2",
                },
                new Category
                {
                    Id = 3,
                    Code = "Cat3",
                    Name = "Cat3",
                }
                );
        }
    }
}
