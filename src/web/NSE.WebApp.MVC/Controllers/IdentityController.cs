using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Controllers;

public class IdentityController : Controller
{
    [HttpGet]
    [Route("register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterUserViewModel registerUserViewModel)
    {
        if (!ModelState.IsValid) return View(registerUserViewModel);

        if (false) return View(registerUserViewModel);

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    [Route("login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginUserViewModel loginUserViewModel)
    {
        if (!ModelState.IsValid) return View(loginUserViewModel);

        if (false) return View(loginUserViewModel);

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    [Route("logout")]
    public async Task<IActionResult> Logout()
    {
        return RedirectToAction("Index", "Home");
    }
}