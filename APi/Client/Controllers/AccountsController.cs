using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Client.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class AccountsController : BaseController<Account, AccountRepository, string>
{
    private readonly AccountRepository repository;

    public AccountsController(AccountRepository repository) : base(repository)
    {
        this.repository = repository;
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Account account)
    {
        var result = await repository.Post(account);
        if (result.StatusCode == 200)
        {
            RedirectToAction("Index", "Home");
        }
        return View();
    }

    //Login 
    [HttpGet]
    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVM loginVM)
    {
        var result = await repository.Login(loginVM);
        if (result is null)
        {
            return RedirectToAction("Error", "Home");
        }
        else if (result.StatusCode == 409)
        {
            ModelState.AddModelError(string.Empty, result.Message);
            return View();
        }
        else if (result.StatusCode == 200)
        {
            HttpContext.Session.SetString("jwtoken", result.Data);
            return RedirectToAction("Index", "Home");
        }
        return View();
    }
}
