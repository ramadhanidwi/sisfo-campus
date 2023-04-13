using Client.Models;

namespace Client.Repositories.Data;

public class LecturerRepository : GeneralRepository<Lecturer, int>
{
    private readonly string request;
    private readonly HttpClient _httpClient;
    public LecturerRepository(string request = "Lecturers/") : base(request)
    {
        this.request = request;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7024/api/")

        };
    }
}
