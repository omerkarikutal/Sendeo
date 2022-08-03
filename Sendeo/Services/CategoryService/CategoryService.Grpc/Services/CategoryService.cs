using CategoryService.Data.Repository;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryService.Grpc.Services
{
    public class CategoryService : Category.CategoryBase
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public override Task<CategoryModel> GetCategory(GetCategoryRequest request, ServerCallContext context)
        {
            var result = _repository.GetByCode(request.Code);

            var model = new CategoryModel
            {
                Id = result.Id,
                Name = result.Name
            };

            return Task.FromResult(model);
        }
    }
}
