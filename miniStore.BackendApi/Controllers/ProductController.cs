using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using miniStore.Application.Catalog.Products;
using System.Threading.Tasks;

namespace miniStore.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        public ProductController(IPublicProductService publicProductService) { 
            _publicProductService = publicProductService;
        }
        [HttpGet]
        public async Task<IActionResult> Get() {
            var products =await _publicProductService.GetAll();
            return Ok(products);
        }
    }
}
