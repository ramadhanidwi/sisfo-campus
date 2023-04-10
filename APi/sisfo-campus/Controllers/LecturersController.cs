using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sisfo_campus.Base;
using sisfo_campus.Models;

namespace sisfo_campus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturersController : BaseController<int, Lecturer, LecturerRepository>
    {
        public LecturersController(LecturerRepository repository) : base(repository)
        {

        }
    }
}
