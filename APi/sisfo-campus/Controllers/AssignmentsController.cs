using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sisfo_campus.Base;
using sisfo_campus.Models;

namespace sisfo_campus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : BaseController<int, Assignment, AssignmentRepository>
    {
        public AssignmentsController(AssignmentRepository repository) : base(repository)
        {

        }
    }
}
