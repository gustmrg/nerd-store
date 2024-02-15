using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSE.Identity.API.Models;

namespace NSE.Identity.API.Controllers;

[ApiController]
[Route("api/identity")]
public class IdentityController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    
    public IdentityController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(RegisterUserViewModel registerUserViewModel)
    {
        if (!ModelState.IsValid) return BadRequest();

        var user = new IdentityUser
        {
            UserName = registerUserViewModel.Email,
            Email = registerUserViewModel.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, registerUserViewModel.Password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);
            return Ok();
        }

        return BadRequest();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginUserViewModel loginUserViewModel)
    {
        if (!ModelState.IsValid) return BadRequest();

        var result = await _signInManager.PasswordSignInAsync(loginUserViewModel.Email, loginUserViewModel.Password, 
            false, true);

        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest();
    }
}