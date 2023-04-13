using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class AssignmentsController : BaseController<Assignment, AssignmentRepository, int>
{
    private readonly AssignmentRepository repository;

    public AssignmentsController(AssignmentRepository repository) : base(repository)
    {
        this.repository = repository;
    }

    /* METHOD GET*/

    //Get All
    //[HttpGet]
    //public async Task<IActionResult> Index()
    //{
    //    var result = await repository.Get();
    //    var faculties = new List<Assignment>();
    //    if (result.Data != null)
    //    {
    //        faculties = result.Data.ToList();
    //    }
    //    return View(faculties);
    //}

    public IActionResult Index()
    {
        return View();
    }

    ////Create
    //[HttpGet]
    //public async Task<IActionResult> Create()
    //{
    //    return View();
    //}

    ////Details (Get by Id)
    //[HttpGet]
    //public async Task<IActionResult> Details(int id)
    //{
    //    var result = await repository.Get(id);
    //    var detail = new Assignment();
    //    if (result.Data != null)
    //    {
    //        detail.Id = result.Data.Id;
    //        detail.name = result.Data.name;
    //        detail.UploadDate = result.Data.UploadDate;
    //        detail.Score = result.Data.Score;
    //        detail.CourseCode = result.Data.CourseCode;
    //        detail.StudentNim = result.Data.StudentNim;
    //        detail.LecturerNik = result.Data.LecturerNik;
    //    }
    //    return View(detail);
    //}

    ////Edit
    //[HttpGet]
    //public async Task<IActionResult> Edit()
    //{
    //    return View();
    //}

    ////Delete
    //[HttpGet]
    //public async Task<IActionResult> Delete(int id)
    //{
    //    var result = await repository.Get(id);
    //    return View(result.Data);
    //}



    ///* POST */
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Create(Assignment assignment)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var result = await repository.Post(assignment);
    //        if (result.StatusCode == 200)
    //        {
    //            TempData["Success"] = "Create Data Successfully";
    //            return RedirectToAction(nameof(Index));
    //        }
    //        else if (result.StatusCode == 409)
    //        {
    //            ModelState.AddModelError(string.Empty, result.Message);
    //            return View();
    //        }
    //    }
    //    return View();
    //}

    ////Delete
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Remove(int id)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var result = await repository.Delete(id);
    //        if (result.StatusCode == 200)
    //        {
    //            TempData["Success"] = "Delete Data Successfully";
    //            return RedirectToAction(nameof(Index));
    //        }
    //        else if (result.StatusCode == 409)
    //        {
    //            ModelState.AddModelError(string.Empty, result.Message);
    //            return View();
    //        }
    //    }
    //    return View();
    //}

    ////Edit
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Edit(Assignment assignment)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var result = await repository.Put(assignment, assignment.Id);
    //        if (result.StatusCode == 200)
    //        {
    //            TempData["Success"] = "Data berhasil dihapus";
    //            return RedirectToAction(nameof(Index));
    //        }
    //        else if (result.StatusCode == 409)
    //        {
    //            ModelState.AddModelError(string.Empty, result.Message);
    //            return View();
    //        }
    //    }
    //    return View();
    //}
}
