using miniStore.ViewModels.Catalog.Categories;
using miniStore.ViewModels.Catalog.Products;
using miniStore.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace miniStore.ApiIntergration
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryVM>> GetAll(string languageId);

        Task<CategoryVM> GetById(string languageId, int id);

        Task<bool> CreateCategory(CategoryCreateRequest request);

        Task<PagedResult<CategoryVM>> GetAllPagings(GetCategoryPagingRequest request);

        Task<bool> DeleteCategory(int id);
    }
}
