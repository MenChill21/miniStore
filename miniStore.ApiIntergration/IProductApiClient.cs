using miniStore.ViewModels.Catalog.Products;
using miniStore.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace miniStore.ApiIntergration
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductVM>> GetAllPagings(GetManageProductPagingRequest request);

        Task<bool> CreateProduct(ProductCreateRequest request);

        Task<ProductVM> GetById(int id, string languageId);

        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

        Task<List<ProductVM>> GetFeaturedProducts(string languageId, int take);

        Task<List<ProductVM>> GetLatestProducts(string languageId, int take);

        Task<bool> UpdateProduct(ProductUpdateRequest request);

        Task<bool> DeleteProduct(int id);


    }
}
