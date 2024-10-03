using miniStore.ViewModels.Catalog.Categories;
using miniStore.ViewModels.Catalog.Products;
using miniStore.ViewModels.Common;

namespace miniStore.WebApp.Models
{
    public class ProductCategoryViewModel
    {
        public CategoryVM Category { get; set; }

        public PagedResult<ProductVM> Products { get; set; }
    }
}
