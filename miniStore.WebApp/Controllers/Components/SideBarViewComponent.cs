using Microsoft.AspNetCore.Mvc;
using miniStore.ApiIntergration;
using System.Globalization;
using System.Threading.Tasks;

namespace miniStore.WebApp.Controllers.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        private readonly ICategoryApiClient _categoryApiClient;

        public SideBarViewComponent(ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient = categoryApiClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _categoryApiClient.GetAll(CultureInfo.CurrentCulture.Name);
            return View(result);
        }
    }
}
