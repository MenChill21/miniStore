using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using miniStore.ViewModels.Catalog.Categories;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace miniStore.AdminApp.Services
{
    public class CategoryApiClient : BaseApiClient, ICategoryApiClient
    {
        public CategoryApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<List<CategoryVM>> GetAll(string languageId)
        {
            return await GetListAsync<CategoryVM>("/api/categories?languageId=" + languageId);
        }
    }
}
