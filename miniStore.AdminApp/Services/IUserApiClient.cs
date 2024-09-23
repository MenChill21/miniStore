using miniStore.ViewModels.System.Users;
using System.Threading.Tasks;

namespace miniStore.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}
