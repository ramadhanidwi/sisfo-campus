using Microsoft.AspNetCore.Mvc;
using sisfo_campus.Base;
using sisfo_campus.Models;
using sisfo_campus.Repositories.Data;
using static Azure.Core.HttpHeader;
using Microsoft.EntityFrameworkCore;
using sisfo_campus.Contexts;
using sisfo_campus.ViewModels;
using sisfo_campus.Repositories.Interface;
using sisfo_campus.Repositories.Data;

namespace sisfo_campus.Controllers;

public class AttachmentFilesController : BaseController<Int64, AttachmentFile, AttachmentFileRepository>
{
    private readonly MyContext context;
    private readonly ICommon common;

    public AttachmentFilesController(MyContext context, ICommon common, AttachmentFileRepository repository) : base(repository)
    {
        this.context = context;
        this.common = common;
    }

    /*[HttpGet]
    public IActionResult Index()
    {
        var _GetGridItem = GetGridItem().ToList();
        return View(_GetGridItem);
    }

    private IQueryable<AttachmentFileVM> GetGridItem()
    {
        try
        {
            return (from _AttachmentFile in context.AttachmentFiles
                    where _AttachmentFile.Cancelled == false
                    select new AttachmentFileVM
                    {
                        Id = _AttachmentFile.Id,
                        ContentType = _AttachmentFile.ContentType,
                        FileName = _AttachmentFile.FileName,
                        Length = _AttachmentFile.Length,
                        CreatedDate = _AttachmentFile.CreatedDate,
                    }).OrderByDescending(x => x.Id);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<IActionResult> Details(Int64 id)
    {
        AttachmentFileVM vm = await context.AttachmentFiles.FirstOrDefaultAsync(m => m.Id == id);
        return PartialView("_Details", vm);
    }

    public IActionResult AddEdit(int id)
    {
        AddNewFileVM vm = new AddNewFileVM();
        return PartialView("_AddEdit", vm);
    }

    [HttpPost]
    public async Task<JsonResult> AddNewAttachmentFile(AddNewFileVM vm)
    {
        AttachmentFile _AttachmentFile = null;

        if (ModelState.IsValid)
        {
            try
            {
                foreach (var item in vm.AttachmentFile)
                {
                    _AttachmentFile = await common.AddAttachmentFile(item);
                }
            }
            catch (Exception ex)
            {
                TempData["errorAlert"] = "Operation failed.";
                throw ex;
            }
        }
        var successAlert = "File Uploaded Successfully. Total File Uploaded: " + vm.AttachmentFile.Count;
        TempData["successAlert"] = successAlert;
        return new JsonResult(successAlert);
    }

    public FileResult DownloadFile(Int64 id)
    {
        try
        {
            var _GetDownloadDetails = common.GetDownloadDetails(id);
            return File(_GetDownloadDetails.Item1, "application/octet-stream", _GetDownloadDetails.Item2);
        }
        catch (Exception ex)
        {
            TempData["errorAlert"] = "Operation failed." + ex.Message;
            throw ex;
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Int64 id)
    {
        try
        {
            var _AttachmentFile = await context.AttachmentFiles.FindAsync(id);
            _AttachmentFile.ModifiedDate = DateTime.Now;
            _AttachmentFile.ModifiedBy = "Admin";
            _AttachmentFile.Cancelled = true;

            context.Update(_AttachmentFile);
            await context.SaveChangesAsync();
            return new JsonResult(_AttachmentFile);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }*/
}
