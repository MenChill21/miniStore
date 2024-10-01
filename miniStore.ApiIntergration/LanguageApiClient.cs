using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using miniStore.ViewModels.Common;
using miniStore.ViewModels.System.Languages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace miniStore.ApiIntergration
{
    public class LanguageApiClient : BaseApiClient, ILanguageApiClient
    {
        public LanguageApiClient(IHttpClientFactory httpClientFactory,
                  IHttpContextAccessor httpContextAccessor,
                   IConfiguration configuration)
           : base(httpClientFactory, httpContextAccessor, configuration)
        {

        }

        public async Task<ApiResult<List<LanguageVM>>> GetAll()
        {
            return await GetAsync<ApiResult<List<LanguageVM>>>("/api/languages");
        }
    }
}
