using miniStore.ViewModels.Common;
using miniStore.ViewModels.System.Languages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace miniStore.Application.System.Laguages
{
    public interface ILanguageService
    {
        Task<ApiResult<List<LanguageVM>>> GetAll();
    }
}
