using Logex.API.DTOs;
using Logex.API.DTOs.IdentityDTOs;

namespace Logex.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse> Register(RegisterDTO user);
        Task<LoginResponse> Login(LoginDTO user);
        Task<LoginResponse> ReviveToken(string refreshToken);
    }
}
