using Client.Models;

namespace Client.Repositories.Interface;

public interface ICommon
{
    string UploadedFile(IFormFile ProfilePicture);
    Tuple<byte[], string> GetDownloadDetails(long id);
    Task<AttachmentFile> AddAttachmentFile(IFormFile _IFormFile);
}
