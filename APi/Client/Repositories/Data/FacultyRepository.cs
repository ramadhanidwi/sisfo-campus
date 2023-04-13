﻿using Client.Models;

namespace Client.Repositories.Data;

public class FacultyRepository : GeneralRepository<Faculty, int>
{
    private readonly string request;
    private readonly HttpClient _httpClient;
    public FacultyRepository(string request = "Faculties/") : base(request)
    {
        this.request = request;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7024/api/")

        };
    }
}
