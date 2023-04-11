using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sisfo_campus.Base;
using sisfo_campus.Models;
using sisfo_campus.Repositories.Data;

namespace sisfo_campus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorsController : BaseController<int, Major, MajorRepository>
    {
        public MajorsController(MajorRepository repository) : base(repository)
        {

        }
    }
}
