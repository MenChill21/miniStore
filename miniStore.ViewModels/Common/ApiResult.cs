using System;
using System.Collections.Generic;
using System.Text;

namespace miniStore.ViewModels.Common
{
    public class ApiResult <T>
    {
        public string Message { get; set; }

        public bool IsSuccessed { get; set; }

        public T ResultObj { get; set; }
    }
}
