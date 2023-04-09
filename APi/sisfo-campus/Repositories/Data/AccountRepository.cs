using sisfo_campus.Contexts;
using sisfo_campus.Models;

namespace sisfo_campus.Repositories.Data
{
    public class AccountRepository : GeneralRepository<int, Account>
    {
        private readonly MyContext context;

        public AccountRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
