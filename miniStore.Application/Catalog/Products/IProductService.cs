using System;
using miniStore.ViewModels.Catalog.Products;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using miniStore.ViewModels.Common;
using miniStore.ViewModels.Catalog.ProductImages;

namespace miniStore.Application.Catalog.Products
{
    public interface IProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<int> UpdateStock(int productId, int addedQuantity);

        Task<int> AddViewcount(int productId);

        Task<PagedResult<ProductVM>> GetAllPaging(GetManageProductPagingRequest request);

        Task<ProductVM> GetById(int productId, string languageId);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);

        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);

        Task<int> DeleteImage(int imageId);

        Task<ProductImageViewModel> GetImageById(int imageId);

        Task<List<ProductImageViewModel>> GetListImage(int productId);

        Task<PagedResult<ProductVM>> GetAllByCatagoryId(GetPublicProductPagingRequest request);
        Task<List<ProductVM>> GetAll(string language);

        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

        Task<List<ProductVM>> GetFeaturedProducts(string languageId, int take);

    }
}
