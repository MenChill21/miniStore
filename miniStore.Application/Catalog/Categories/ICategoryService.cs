using miniStore.ViewModels.Catalog.Categories;
using miniStore.ViewModels.Catalog.Products;
using miniStore.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace miniStore.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetAll(string languageId);

        Task<CategoryVM> GetById(string languageId, int id);

        Task<int> Create(CategoryCreateRequest request);

        Task<PagedResult<CategoryVM>> GetAllPaging(GetCategoryPagingRequest request);

        Task<int> Delete(int categoryId);
    }
}
