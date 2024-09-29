using miniStore.ViewModels.Common;
using miniStore.ViewModels.System.Roles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace miniStore.AdminApp.Services
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleVM>>> GetAll();

    }
}
