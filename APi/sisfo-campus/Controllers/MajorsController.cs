using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sisfo_campus.Base;
using sisfo_campus.Models;

namespace sisfo_campus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorsController : BaseController<string, Major, MajorRepository>
    {
        public MajorsController(MajorRepository repository) : base(repository)
        {

        }
    }
}
