using sisfo_campus.Contexts;
using sisfo_campus.Models;

namespace sisfo_campus.Repositories.Data;

public class RoleRepository : GeneralRepository<int, Role>
{
    private readonly MyContext context;

    public RoleRepository(MyContext context) : base(context)
    {
        this.context = context;
    }
}
