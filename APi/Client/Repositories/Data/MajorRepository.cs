using Client.Models;

namespace Client.Repositories.Data;

public class MajorRepository : GeneralRepository<Major, int>
{
    private readonly string request;
    private readonly HttpClient _httpClient;
    public MajorRepository(string request = "Majors/") : base(request)
    {
        this.request = request;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7049/api/")
        };
    }
}
