using Client.Models;

namespace Client.Repositories.Data;

public class RoleRepository : GeneralRepository<Role, int>
{
    private readonly string request;
    private readonly HttpClient _httpClient;
    public RoleRepository(string request = "Roles/") : base(request)
    {
        this.request = request;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7024/api/")
        };
    }
}
