
using JwtAuthService.Models;

namespace JwtAuthService.Services;

public interface IAuthService
{
    string Register(RegisterRequest request);
    string Login(LoginRequest request);
}