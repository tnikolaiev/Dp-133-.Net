using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ras.DAL.EF;
using Ras.DAL.Entity;

namespace Ras.DAL.Implementation.Repositories
{
    public class EmployeeRepository : RasRepository<Employee>
    {
        public EmployeeRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<Employee> All => db.Employee.AsNoTracking();

        public override Employee Create(Employee item)
        {
            return db.Employee.Add(item).Entity;
        }

        public override void Delete(Employee item)
        {
            db.Employee.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            Employee item = Read(key);
            if (item != null)
            {
                db.Employee.Remove(item);
            }
        }

        public override Employee Read(params object[] key)
        {
            return db.Employee.Find(key);
        }

        public override Employee Upate(Employee item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }
    }
}
