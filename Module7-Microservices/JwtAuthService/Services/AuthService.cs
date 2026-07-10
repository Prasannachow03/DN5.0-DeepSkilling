using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtAuthService.Models;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthService.Services;

public class AuthService : IAuthService
{
    private readonly List<User> _users = new();
    private readonly string _jwtKey = "SuperSecretMicroservicesKey_32Chars!";

    public string Register(RegisterRequest request)
    {
        if (_users.Any(u => u.Username == request.Username))
            return "User already exists.";

        var user = new User
        {
            Id = _users.Count + 1,
            Username = request.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = request.Role
        };

        _users.Add(user);
        return "User registered successfully.";
    }

    public string Login(LoginRequest request)
    {
        var user = _users.FirstOrDefault(u => u.Username == request.Username);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return "Invalid username or password.";

        return GenerateToken(user);
    }

    private string GenerateToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim("UserId", user.Id.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: "MicroserviceApp",
            audience: "MicroserviceUsers",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}