using System;
using System.Collections.Generic;
using System.Text;

namespace miniStore.ViewModels.Common
{
    public class PagedResultBase
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int TotalRecord { get; set; }

        public int PageCount {
            get
            {
                var pageCount = (double)TotalRecord / PageSize;
                return (int)Math.Ceiling(pageCount);
            }
        }
    }
}
