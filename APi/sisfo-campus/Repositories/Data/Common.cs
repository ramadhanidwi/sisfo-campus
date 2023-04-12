﻿using sisfo_campus.Contexts;
using sisfo_campus.Models;
using sisfo_campus.Repositories.Interface;

namespace sisfo_campus.Repositories.Data;

public class Common : ICommon
{
    private readonly IWebHostEnvironment _iHostingEnvironment;
    private readonly MyContext _context;

    public Common(IWebHostEnvironment iHostingEnvironment, MyContext context)
    {
        _iHostingEnvironment = iHostingEnvironment;
        _context = context;
    }

    public string UploadedFile(IFormFile ProfilePicture)
    {
        string ProfilePictureFileName = null;
        if (ProfilePicture != null)
        {
            string uploadsFolder = Path.Combine(_iHostingEnvironment.ContentRootPath, "wwwroot\\upload");

            if (ProfilePicture.FileName == null)
                ProfilePictureFileName = Guid.NewGuid().ToString() + "_" + "blank-person.png";
            else
                ProfilePictureFileName = Guid.NewGuid().ToString() + "_" + ProfilePicture.FileName;
            string filePath = Path.Combine(uploadsFolder, ProfilePictureFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                ProfilePicture.CopyTo(fileStream);
            }
            return ProfilePictureFileName;
        }
        return "blank-person.png";
    }

    public async Task<AttachmentFile> AddAttachmentFile(IFormFile _IFormFile)
    {
        try
        {
            string _FileName = UploadedFile(_IFormFile);
            AttachmentFile _AttachmentFile = new AttachmentFile
            {
                FilePath = "/upload/" + _FileName,
                ContentType = _IFormFile.ContentType,
                FileName = _FileName,
                Length = _IFormFile.Length,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CreatedBy = "Admin",
                ModifiedBy = "Admin",
            };
            _context.AttachmentFiles.Add(_AttachmentFile);
            await _context.SaveChangesAsync();
            return _AttachmentFile;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public Tuple<byte[], string> GetDownloadDetails(long id)
    {
        byte[] bytes = null;
        try
        {
            var _AttachmentFile = _context.AttachmentFiles.Where(x => x.Id == id).SingleOrDefault();
            string _WebRootPath = _iHostingEnvironment.WebRootPath + _AttachmentFile.FilePath;
            bytes = File.ReadAllBytes(_WebRootPath);

            var _Tuple = new Tuple<byte[], string>(bytes, _AttachmentFile.FileName);
            return _Tuple;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
