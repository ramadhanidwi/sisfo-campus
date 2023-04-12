using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class AttachmentFilesController : BaseController<AttachmentFile,Common, Int64>
{
    private readonly Common repository;

    public AttachmentFilesController(Common repository) : base(repository)
    {
        this.repository = repository;
    }

    public IActionResult Index()
    {
        return View();
    }



}
