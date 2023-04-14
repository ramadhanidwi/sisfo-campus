using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sisfo_campus.Base;
using sisfo_campus.Models;
using sisfo_campus.Repositories.Data;

namespace sisfo_campus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : BaseController<string, Student, StudentRepository>
    {
        public StudentsController(StudentRepository repository) : base(repository)
        {
        }
    }
}
