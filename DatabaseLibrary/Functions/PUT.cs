using DatabaseLibrary.Entities.EmployeeMuchToMany;

namespace DatabaseLibrary.Functions;

internal class PUT
{
    public static bool Employee(Employee employee)
    {
        using ParsethingContext db = new();
        bool isSaved = true;

        try
        {
            if (employee.Position != null)
                employee.PositionId = employee.Position.Id;
            else throw new Exception();
            employee.Position = null;

            _ = db.Employees.Add(employee);
            _ = db.SaveChanges();
        }
        catch { isSaved = false; }

        return isSaved;
    }

    public static bool ProcurementsEmployees(ProcurementsEmployee procurementsEmployee)
    {
        using ParsethingContext db = new();
        bool isSaved = true;

        try
        {
            if (procurementsEmployee.Procurement != null && procurementsEmployee.Employee != null)
            {
                procurementsEmployee.ProcurementId = procurementsEmployee.Procurement.Id;
                procurementsEmployee.EmployeeId = procurementsEmployee.Employee.Id;
            }
            else throw new Exception();

            _ = db.ProcurementsEmployees.Add(procurementsEmployee);
            _ = db.SaveChanges();
        }
        catch { isSaved = false; }

        return isSaved;
    }
}