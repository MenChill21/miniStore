using miniStore.ViewModels.Common;
using miniStore.ViewModels.System.Languages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace miniStore.AdminApp.Services
{
    public interface ILanguageApiClient
    {
        Task<ApiResult<List<LanguageVM>>> GetAll();
    }
}
