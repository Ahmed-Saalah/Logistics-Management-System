using Logex.API.Common;
using Logex.API.Dtos.IdentityDtos;

namespace Logex.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse> Register(RegisterDto user);
        Task<LoginResponse> Login(LoginDto user);
        Task<LoginResponse> ReviveToken(string refreshToken);
    }
}
