using miniStore.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace miniStore.ViewModels.Catalog.Categories
{
    public class GetCategoryPagingRequest : PagingRequestBase
    {
        public string LanguageId { get; set; }

        public string Keyword { get; set; }

    }
}
