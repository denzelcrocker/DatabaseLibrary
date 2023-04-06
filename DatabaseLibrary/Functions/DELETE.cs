using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.Functions
{
    internal class DELETE
    {
        public static void EmployeeDelete(Employee? employee)
        {
            using ParsethingContext db = new();
            db.Employees.Remove(employee);
            db.SaveChanges();
        }
    }
}
