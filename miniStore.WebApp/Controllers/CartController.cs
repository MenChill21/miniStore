using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using miniStore.ApiIntergration;
using miniStore.Utilities.Constants;
using miniStore.WebApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniStore.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        public CartController(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetListItems()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            var currentCart = new List<CartItemViewModel>();
            if (session != null)
            {
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            }
            return Ok(currentCart);
        }

        public async Task<IActionResult> AddToCart(int id, string languageId)
        {
            var product = await _productApiClient.GetById(id, languageId);
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            var currentCart = new List<CartItemViewModel>();
            if (session != null) { 
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            }

            foreach (var item in currentCart) {
                if (item.ProductId == id) {
                    item.Quantity++;
                    HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
                    return Ok(currentCart);
                }
            }

            var cartItem = new CartItemViewModel
            {
                ProductId = id,
                Quantity = 1,
                Description = product.Description,
                Image  = product.ThumbnailImage,
                Price = product.Price,
                Name = product.Name,
            };
             currentCart.Add(cartItem);
            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
            return Ok(currentCart);
        }

        public  IActionResult UpdateCart(int id, int quantity)
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            var currentCart = new List<CartItemViewModel>();
            if (session != null)
            {
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            }
            foreach (var item in currentCart) {
                if (item.ProductId == id) {
                    if (quantity == 0) { 
                        currentCart.Remove(item);
                        break;
                    }
                    item.Quantity = quantity;
                }
            }
            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
            return Ok(currentCart);
        }
    }
}
