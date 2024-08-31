using System;
using miniStore.ViewModels.Catalog.Products;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using miniStore.ViewModels.Common;

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
    }
}
