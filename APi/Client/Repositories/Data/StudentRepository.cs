using Client.Models;

namespace Client.Repositories.Data;

public class StudentRepository : GeneralRepository<Student, string>
{
    private readonly string request;
    private readonly HttpClient _httpClient;
    public StudentRepository(string request = "Students/") : base(request)
    {
        this.request = request;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7024/api/")
        };
    }
}
