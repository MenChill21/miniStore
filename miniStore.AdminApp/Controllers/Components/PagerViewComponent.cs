using Microsoft.AspNetCore.Mvc;
using miniStore.ViewModels.Common;
using System.Threading.Tasks;

namespace miniStore.AdminApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
