using System;
using miniStore.ViewModels.Catalog.Products;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using miniStore.ViewModels.Common;
using miniStore.ViewModels.Catalog.ProductImages;

namespace miniStore.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<int> UpdateStock(int productId, int addedQuantity);

        Task<int> AddViewcount(int productId);

        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task<ProductViewModel> GetById(int productId, string languageId);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);

        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);

        Task<int> DeleteImage(int imageId);

        Task<ProductImageViewModel> GetImageById(int imageId);

        Task<List<ProductImageViewModel>> GetListImage(int productId);
    }
}
