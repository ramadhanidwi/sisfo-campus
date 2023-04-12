using sisfo_campus.Models;

namespace sisfo_campus.Repositories.Interface;

public interface ICommon
{
    string UploadedFile(IFormFile ProfilePicture);
    Tuple<byte[], string> GetDownloadDetails(Int64 id);
    Task<AttachmentFile> AddAttachmentFile(IFormFile _IFormFile);
}
