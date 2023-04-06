using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.Functions
{
    internal class PUT
    {
        public static void PutEmployee(Employee? employee)
        {
            using ParsethingContext db = new();
            try
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            catch { }
        }
    }
}
