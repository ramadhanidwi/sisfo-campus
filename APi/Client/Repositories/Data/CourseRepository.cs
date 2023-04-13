using Client.Models;

namespace Client.Repositories.Data;

public class CourseRepository : GeneralRepository<Course, int>
{
    private readonly string request;
    private readonly HttpClient _httpClient;
    public CourseRepository(string request = "Courses/") : base(request)
    {
        this.request = request;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7024/api/")

        };
    }
}
