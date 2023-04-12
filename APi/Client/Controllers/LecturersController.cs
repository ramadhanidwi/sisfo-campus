using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class LecturersController : BaseController<Lecturer, LecturerRepository, int>
{
    private readonly LecturerRepository repository;

    public LecturersController(LecturerRepository repository) : base(repository)
    {
        this.repository = repository;
    }

    /* METHOD GET*/

    //Get All
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var result = await repository.Get();
        var faculties = new List<Lecturer>();
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
    public async Task<IActionResult> Details(int nik)
    {
        var result = await repository.Get(nik);
        var detail = new Lecturer();
        if (result.Data != null)
        {
            detail.Nik = result.Data.Nik;
            detail.FirstName = result.Data.FirstName;
            detail.LastName = result.Data.LastName;
            detail.Address = result.Data.Address;
            detail.PhoneNumber = result.Data.PhoneNumber;
            detail.Degree = result.Data.Degree;
            detail.Email = result.Data.Email;
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
    public async Task<IActionResult> Delete(int nik)
    {
        var result = await repository.Get(nik);
        return View(result.Data);
    }



    /* POST */
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Lecturer lecturer)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Post(lecturer);
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
    public async Task<IActionResult> Remove(int nik)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Delete(nik);
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
    public async Task<IActionResult> Edit(Lecturer lecturer)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Put(lecturer, lecturer.Nik);
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
