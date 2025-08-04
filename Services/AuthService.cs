using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using WorkflowManagement.DTOs;
using WorkflowManagement.Models;
using WorkflowManagement.Data;

namespace WorkflowManagement.Services;

public class AuthService
{
    private readonly string _jwtKey;
    private readonly List<User> _users;

    public AuthService(IConfiguration config)
    {
        _jwtKey = config["Jwt:Key"] ?? throw new Exception("JWT Key not configured");
        _users = AuthSeed.Users;
    }

    public string? Authenticate(LoginRequest request)
    {
        var user = _users.FirstOrDefault(u =>
            (u.Username.Equals(request.UsernameOrEmail, StringComparison.OrdinalIgnoreCase) ||
             u.Email.Equals(request.UsernameOrEmail, StringComparison.OrdinalIgnoreCase))
            && u.Password == request.Password);

        if (user == null) return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtKey);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, string.Join(",", user.Roles.Select(r => r.Name)))
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}