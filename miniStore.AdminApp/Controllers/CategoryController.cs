using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using miniStore.ApiIntergration;
using miniStore.Utilities.Constants;
using miniStore.ViewModels.Catalog.Categories;
using miniStore.ViewModels.Catalog.Products;
using System.Threading.Tasks;

namespace miniStore.AdminApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ICategoryApiClient _categoryApiClient;
        public CategoryController(IConfiguration config,
            ICategoryApiClient categoryApiClient)
        {
            _config = config;
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 1)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var request = new GetCategoryPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId,
            };

            var categories = await _categoryApiClient.GetAllPagings(request);
            ViewBag.Keyword = keyword;

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _categoryApiClient.CreateCategory(request);
            if (result)
            {
                TempData["result"] = "Add category successful";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Add category failed");
            return View(request);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new CategoryDeleteRequest() { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoryDeleteRequest request)
        {
            if (!ModelState.IsValid) return View();

            var result = await _categoryApiClient.DeleteCategory(request.Id);

            if (result)
            {
                TempData["result"] = "Delete category successful";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Delete category failed");
            return View(request);
        }

    }
}
