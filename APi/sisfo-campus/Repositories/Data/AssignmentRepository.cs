using sisfo_campus.Contexts;
using sisfo_campus.Models;

namespace sisfo_campus.Repositories.Data
{
    public class AssignmentRepository : GeneralRepository<int, Assignment>
    {
        private readonly MyContext context;

        public AssignmentRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
