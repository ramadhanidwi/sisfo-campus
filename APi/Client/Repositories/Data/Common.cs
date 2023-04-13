using Client.Models;

namespace Client.Repositories.Data;

public class Common : GeneralRepository<AttachmentFile, Int64>
{
    private readonly string request;
    private readonly HttpClient _httpClient;

    public Common(string request = "Commons/") : base(request)
    {
        this.request = request;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7024/api/")

        };
    }
}
