using sisfo_campus.Contexts;
using sisfo_campus.Models;

namespace sisfo_campus.Repositories.Data
{
    public class StudentRepository : GeneralRepository<int, Student>
    {
        private readonly MyContext context;

        public StudentRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
