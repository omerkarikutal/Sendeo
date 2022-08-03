using CategoryService.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryService.Data.Repository
{
    public interface ICategoryRepository
    {
        Category? GetByCode(string code);
    }
}
