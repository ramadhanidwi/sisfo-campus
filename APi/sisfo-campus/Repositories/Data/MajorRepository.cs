using sisfo_campus.Contexts;
using sisfo_campus.Models;

namespace sisfo_campus.Repositories.Data;

public class MajorRepository : GeneralRepository<string, Major>
{
    private readonly MyContext context;

    public MajorRepository(MyContext context) : base(context)
    {
        this.context = context;
    }
}
