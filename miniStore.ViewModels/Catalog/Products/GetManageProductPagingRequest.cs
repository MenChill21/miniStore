using miniStore.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace miniStore.ViewModels.Catalog.Products
{
    public class GetManageProductPagingRequest:PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryId { get; set; }
    }
}
