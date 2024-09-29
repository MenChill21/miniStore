using miniStore.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace miniStore.ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
