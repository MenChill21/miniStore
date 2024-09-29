using miniStore.ViewModels.System.Languages;
using System.Collections.Generic;

namespace miniStore.AdminApp.Models
{
    public class NavigationViewModel
    {
        public List<LanguageVM> Languages { get; set; }

        public string  CurrentLanguageId { get; set; }
    }
}
