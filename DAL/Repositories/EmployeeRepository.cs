using System.Linq;
using Ras.DAL.EF;
using Ras.DAL.Entity;
using Ras.DAL.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Ras.DAL.Repositories
{
    public class EmployeeRepository : RasRepository<Employee>
    {
        public EmployeeRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<Employee> All => db.Employee;

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
