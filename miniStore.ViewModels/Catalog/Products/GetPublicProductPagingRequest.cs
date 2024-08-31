using miniStore.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace miniStore.ViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest:PagingRequestBase
    {
        public int? CatagoryId { get; set; }
    }
}
