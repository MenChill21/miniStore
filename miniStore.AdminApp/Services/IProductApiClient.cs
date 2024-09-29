using Microsoft.AspNetCore.Mvc.RazorPages;
using miniStore.ViewModels.Catalog.Products;
using miniStore.ViewModels.Common;
using System.Threading.Tasks;

namespace miniStore.AdminApp.Services
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductVM>> GetAllPagings(GetManageProductPagingRequest request);

        Task<bool> CreateProduct(ProductCreateRequest request);

        Task<ProductVM> GetById(int id, string languageId);

        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request); 
    }
}
