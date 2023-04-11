using sisfo_campus.Contexts;
using sisfo_campus.Models;

namespace sisfo_campus.Repositories.Data;

public class FacultyRepository : GeneralRepository<int, Faculty>
{
    private readonly MyContext context;

    public FacultyRepository(MyContext context) : base(context)
    {
        this.context = context;
    }
}
