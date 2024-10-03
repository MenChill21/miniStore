using Microsoft.AspNetCore.Mvc.Rendering;
using miniStore.ViewModels.System.Languages;
using System.Collections.Generic;

namespace miniStore.AdminApp.Models
{
    public class NavigationViewModel
    {
        public List<SelectListItem> Languages { get; set; }

        public string  CurrentLanguageId { get; set; }

        public string ReturnUrl { set; get; }
    }
}
