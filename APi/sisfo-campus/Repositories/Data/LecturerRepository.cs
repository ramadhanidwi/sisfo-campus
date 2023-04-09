using sisfo_campus.Contexts;
using sisfo_campus.Models;

namespace sisfo_campus.Repositories.Data;

public class LecturerRepository : GeneralRepository<int, Lecturer>
{
    private readonly MyContext context;

    public LecturerRepository(MyContext context) : base(context)
    {
        this.context = context;
    }
}
