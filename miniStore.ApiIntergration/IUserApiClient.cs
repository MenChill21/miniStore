using Microsoft.AspNetCore.Mvc.RazorPages;
using miniStore.ViewModels.System.Users;
using miniStore.ViewModels.Common;

using System.Threading.Tasks;
using System;

namespace miniStore.ApiIntergration
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<ApiResult<PagedResult<UserVM>>> GetUsersPagings(GetUserPagingRequest request);

        Task<ApiResult<bool>> RegisterUser(RegisterRequest request);

        Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request);

        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);

        Task<ApiResult<UserVM>>  GetById(Guid id);

        Task<ApiResult<bool>> Delete(Guid id);

    }
}
