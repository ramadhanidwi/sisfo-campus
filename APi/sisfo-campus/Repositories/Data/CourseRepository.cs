using sisfo_campus.Contexts;
using sisfo_campus.Models;

namespace sisfo_campus.Repositories.Data;

public class CourseRepository : GeneralRepository<string, Course>
{
    private readonly MyContext context;

    public CourseRepository(MyContext context) : base(context)
    {
        this.context = context;
    }
}
