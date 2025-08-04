using Microsoft.AspNetCore.Mvc;
using WorkflowManagement.DTOs;
using WorkflowManagement.Services;

namespace WorkflowManagement.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(AuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var token = authService.Authenticate(request);
        if (token == null)
            return Unauthorized(new { message = "Invalid credentials" });

        return Ok(new { token });
    }
}