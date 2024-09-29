using System;
using System.Collections.Generic;
using System.Text;

namespace miniStore.ViewModels.Common
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public string[] ValidationErrors { get; set; }

        public ApiErrorResult(string message) {
            IsSuccessed = false;
            Message = message;
        }

        public ApiErrorResult(string[] validationResult)
        {
            IsSuccessed = false;
            ValidationErrors = validationResult;
        }
        public ApiErrorResult() { 
            IsSuccessed=false;
        }
    }
}
