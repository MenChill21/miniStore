using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using miniStore.ApiIntergration;
using miniStore.Utilities.Constants;
using miniStore.WebApp.Models;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace miniStore.WebApp.Controllers
{
    public class HomeController : Controller
    {
    
        private readonly ILogger<HomeController> _logger;
        private readonly IProductApiClient _productApiClient;
        private readonly ISlideApiClient _slideApiClient;

        public HomeController(ILogger<HomeController> logger, ISlideApiClient slideApiClient,
            IProductApiClient productApiClient)
        {
            _logger = logger;
            _slideApiClient = slideApiClient;
            _productApiClient = productApiClient;   
        }

        public async Task<IActionResult> Index()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var HomeViewModel = new HomeViewModel
            {
                Slides = await _slideApiClient.GetAll(),
                FeaturedProducts = await _productApiClient.GetFeaturedProducts(culture, SystemConstants.ProductSettings.NumberOfFeaturedProducts),
                LatestProducts = await _productApiClient.GetLatestProducts(culture, SystemConstants.ProductSettings.NumberOfLatestProducts)
            };
            return View(HomeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SetCultureCookie(string cltr, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cltr)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
