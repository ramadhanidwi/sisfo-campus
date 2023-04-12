using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class MajorsController : BaseController<Major,MajorRepository,int>
{
    private readonly MajorRepository repository;

    public MajorsController(MajorRepository repository) : base(repository)
    {
        this.repository = repository;
    }

    /* METHOD GET*/

    //Get All
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var result = await repository.Get();
        var faculties = new List<Major>();
        if (result.Data != null)
        {
            faculties = result.Data.ToList();
        }
        return View(faculties);
    }

    //Create
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    //Details (Get by Id)
    [HttpGet]
    public async Task<IActionResult> Details(int code)
    {
        var result = await repository.Get(code);
        var detail = new Major();
        if (result.Data != null)
        {
            detail.Code = result.Data.Code;
            detail.Name = result.Data.Name;
            detail.FacultyCode = result.Data.FacultyCode;
        }
        return View(detail);
    }

    //Edit
    [HttpGet]
    public async Task<IActionResult> Edit()
    {
        return View();
    }

    //Delete
    [HttpGet]
    public async Task<IActionResult> Delete(int code)
    {
        var result = await repository.Get(code);
        return View(result.Data);
    }



    /* POST */
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Major major)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Post(major);
            if (result.StatusCode == 200)
            {
                TempData["Success"] = "Create Data Successfully";
                return RedirectToAction(nameof(Index));
            }
            else if (result.StatusCode == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
        }
        return View();
    }

    //Delete
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int code)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Delete(code);
            if (result.StatusCode == 200)
            {
                TempData["Success"] = "Delete Data Successfully";
                return RedirectToAction(nameof(Index));
            }
            else if (result.StatusCode == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
        }
        return View();
    }

    //Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Major major)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Put(major, major.Code);
            if (result.StatusCode == 200)
            {
                TempData["Success"] = "Data berhasil dihapus";
                return RedirectToAction(nameof(Index));
            }
            else if (result.StatusCode == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
        }
        return View();
    }

}
