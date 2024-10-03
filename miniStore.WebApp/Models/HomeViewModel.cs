using miniStore.ViewModels.Catalog.Products;
using miniStore.ViewModels.Utilities.Slides;
using System.Collections.Generic;

namespace miniStore.WebApp.Models
{
    public class HomeViewModel
    {
        public List<SlideVM> Slides { get; set; }

        public List<ProductVM> FeaturedProducts { get; set; }
            
        public List<ProductVM> LatestProducts { get; set; }

    }
}
