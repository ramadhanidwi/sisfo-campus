using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;
[Authorize]
public class StudentsController : BaseController<Student, StudentRepository, string>
{
    private readonly StudentRepository repository;

    public StudentsController(StudentRepository repository) : base(repository)
    {
        this.repository = repository;
    }

    /* METHOD GET*/

    //Get All
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var result = await repository.Get();
        var students = new List<Student>();
        if (result.Data != null)
        {
            students = result.Data.ToList();
        }
        return View(students);
    }

    //Create
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    //Details (Get by Id)
    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        var result = await repository.Get(id);
        var detail = new Student();
        if (result.Data != null)
        {
            detail.Nim = result.Data.Nim;
            detail.FirstName = result.Data.FirstName;
            detail.LastName = result.Data.LastName;
            detail.BirthDate = result.Data.BirthDate;
            detail.Gender = result.Data.Gender;
            detail.PhoneNumber = result.Data.PhoneNumber;
            detail.Address = result.Data.Address;
            detail.Email = result.Data.Email;
            detail.MajorCode = result.Data.MajorCode;
            detail.CourseCode= result.Data.CourseCode;
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
    public async Task<IActionResult> Delete(string nim)
    {
        var result = await repository.Get(nim);
        return View(result.Data);
    }



    /* POST */
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Student student)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Post(student);
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
    public async Task<IActionResult> Remove(string nim)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Delete(nim);
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
    public async Task<IActionResult> Edit(Student student)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Put(student, student.Nim);
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
