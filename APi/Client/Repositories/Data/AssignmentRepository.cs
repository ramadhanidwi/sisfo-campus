using Client.Models;

namespace Client.Repositories.Data;

public class AssignmentRepository : GeneralRepository<Assignment, int>
{
    private readonly string request;
    private readonly HttpClient _httpClient;
    public AssignmentRepository(string request = "Assignments/") : base(request)
    {
        this.request = request;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7024/api/")
        };
    }
}
