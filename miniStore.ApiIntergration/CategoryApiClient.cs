using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using miniStore.Utilities.Constants;
using miniStore.ViewModels.Catalog.Categories;
using miniStore.ViewModels.Catalog.Products;
using miniStore.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace miniStore.ApiIntergration
{
    public class CategoryApiClient : BaseApiClient, ICategoryApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpClientFactory = httpClientFactory;
            _config = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<CategoryVM>> GetAll(string languageId)
        {
            return await GetListAsync<CategoryVM>("/api/categories?languageId=" + languageId);
        }

        public async Task<CategoryVM> GetById(string languageId, int id)
        {
            return await GetAsync<CategoryVM>($"/api/categories/{id}/{languageId}");
        }
        public async Task<bool> CreateCategory(CategoryCreateRequest request)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_config[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "name");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoDescription) ? "" : request.SeoDescription.ToString()), "seoDescription");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoTitle) ? "" : request.SeoTitle.ToString()), "seoTitle");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoAlias) ? "" : request.SeoAlias.ToString()), "seoAlias");
            requestContent.Add(new StringContent(request.ParentId.ToString()), "parentId");
            requestContent.Add(new StringContent(languageId), "languageId");

            var respone = await client.PostAsync("/api/categories/", requestContent);
            return respone.IsSuccessStatusCode;
        }

        public async Task<PagedResult<CategoryVM>> GetAllPagings(GetCategoryPagingRequest request)
        {
            var data = await GetAsync<PagedResult<CategoryVM>>($"/api/categories/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&languageId={request.LanguageId}");
            return data;
        }
        public async Task<bool> DeleteCategory(int id)
        {
            return await Delete($"/api/categories/" + id);
        }


    }
}
