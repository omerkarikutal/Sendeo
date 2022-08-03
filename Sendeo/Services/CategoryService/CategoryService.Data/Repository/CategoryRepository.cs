using CategoryService.Core.Entity;
using CategoryService.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryService.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryContext _context;
        public CategoryRepository(CategoryContext context)
        {
            _context = context;
        }
        public Category? GetByCode(string code)
        {
            return _context.Category.FirstOrDefault(s => s.Code == code);
        }
    }
}
