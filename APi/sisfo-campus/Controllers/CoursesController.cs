﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sisfo_campus.Base;
using sisfo_campus.Models;

namespace sisfo_campus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : BaseController<string, Course, CourseRepository>
    {
        public CoursesController(CourseRepository repository) : base(repository)
        {

        }
    }
}