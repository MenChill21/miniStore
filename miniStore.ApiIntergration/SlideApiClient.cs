using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using miniStore.ViewModels.Utilities.Slides;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace miniStore.ApiIntergration
{
    public class SlideApiClient : BaseApiClient, ISlideApiClient
    {
        public SlideApiClient(IHttpClientFactory httpClientFactory,
                    IHttpContextAccessor httpContextAccessor,
                     IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }
        public async Task<List<SlideVM>> GetAll()
        {
            var data = await GetListAsync<SlideVM>("/api/slides");
            return data;
        }
    }
}
