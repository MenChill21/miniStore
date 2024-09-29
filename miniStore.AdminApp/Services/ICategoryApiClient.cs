using miniStore.ViewModels.Catalog.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace miniStore.AdminApp.Services
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryVM>> GetAll(string languageId);
    }
}
