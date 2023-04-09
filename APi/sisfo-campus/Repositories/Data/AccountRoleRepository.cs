using sisfo_campus.Contexts;
using sisfo_campus.Models;

namespace sisfo_campus.Repositories.Data;

public class AccountRoleRepository : GeneralRepository<int, AccountRole>
{
    private readonly MyContext context;

    public AccountRoleRepository(MyContext context) : base(context)
    {
        this.context = context;
    }
}
