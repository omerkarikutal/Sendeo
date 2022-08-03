using CategoryService.Data.Context;
using CategoryService.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CategoryTest
{
    public class Category
    {
        [Fact]
        public void GetCategory()
        {
            // arrange
            var context = CreateCategoryContext();
            var service = new CategoryRepository(context.Object);

            // act
            var results = service.GetByCode("cat1");

            // assert
            Assert.Equal("cat1", results.Code);

        }
        private Mock<CategoryContext> CreateCategoryContext()
        {
            var persons = FakeData().AsQueryable();

            var dbSet = new Mock<DbSet<CategoryService.Core.Entity.Category>>();
            dbSet.As<IQueryable<CategoryService.Core.Entity.Category>>().Setup(m => m.Provider).Returns(persons.Provider);
            dbSet.As<IQueryable<CategoryService.Core.Entity.Category>>().Setup(m => m.Expression).Returns(persons.Expression);
            dbSet.As<IQueryable<CategoryService.Core.Entity.Category>>().Setup(m => m.ElementType).Returns(persons.ElementType);
            dbSet.As<IQueryable<CategoryService.Core.Entity.Category>>().Setup(m => m.GetEnumerator()).Returns(persons.GetEnumerator());

            var context = new Mock<CategoryContext>();
            context.Setup(c => c.Category).Returns(dbSet.Object);
            return context;

        }
        private IEnumerable<CategoryService.Core.Entity.Category> FakeData()
        {
            return new List<CategoryService.Core.Entity.Category>
           {
               new CategoryService.Core.Entity.Category
               {
                   Id = 1,
                   Code = "cat1",
                   Name="Test1",
               },
               new CategoryService.Core.Entity.Category
               {
                   Id = 2,
                   Code = "cat2",
                   Name="Test2",
               }
           };
        }
    }
}