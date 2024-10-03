using Microsoft.AspNetCore.Mvc;
using miniStore.ApiIntergration;
using miniStore.ViewModels.Catalog.Products;
using miniStore.WebApp.Models;
using System.Threading.Tasks;

namespace miniStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;

        public ProductController(IProductApiClient productApiClient, ICategoryApiClient categoryApiClient) {
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IActionResult> Category(int id, string culture, int page = 1)
        {
            var products =await _productApiClient.GetAllPagings(new GetManageProductPagingRequest
            {
                CategoryId = id,
                LanguageId = culture,
                PageIndex = page,
                PageSize = 2
            });

            return View(new ProductCategoryViewModel { 
                Products = products,
                Category = await _categoryApiClient.GetById(culture,id)
            });
        }
        public async Task<IActionResult> Detail(int id, string culture)
        {
            var product = await _productApiClient.GetById(id, culture);
            return View(new ProductDetailViewModel { 
                Product = product
            });
        }
    }
}
