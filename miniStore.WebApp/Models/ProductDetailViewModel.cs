using miniStore.ViewModels.Catalog.Categories;
using miniStore.ViewModels.Catalog.ProductImages;
using miniStore.ViewModels.Catalog.Products;
using System.Collections.Generic;

namespace miniStore.WebApp.Models
{
    public class ProductDetailViewModel
    {
        public CategoryVM  Category { get; set; }

        public ProductVM Product { get; set; }

        public List<ProductVM> ProductRelated { get; set; }

        public List<ProductImageViewModel> ProductImages { get; set; }
    }
}
