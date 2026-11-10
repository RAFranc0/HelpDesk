using System.Security.Claims;
using HelpDesk.Data;
using HelpDesk.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;
    private readonly AppDbContext _db;
    private readonly PasswordHasher<UserModel> _passwordHasher = new();

    public AuthController(
        AppDbContext db
        )
    {
        _db = db;
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var clearUsername = model.Username.Trim();
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == clearUsername);
        bool validCredentials = false;
        
        if (user != null)
        {
            var attempt =  _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password);
            validCredentials = attempt != PasswordVerificationResult.Failed;
        }

        if (!validCredentials)
        {
            ModelState.AddModelError(string.Empty, "Login ou senha inválidos!");
            return View("Login", model);
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
        };
        
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        
        return View(model);
    }
    
}