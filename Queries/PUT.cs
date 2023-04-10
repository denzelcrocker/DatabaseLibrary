namespace DatabaseLibrary.Functions;

public static class PUT
{
    public static bool ProcurementSource(Procurement procurement, bool isGetted)
    {
        using ParsethingContext db = new();
        bool isSaved = true;
        Procurement? def = null;

        try
        {
            def = db.Procurements
                .Where(p => p.Number == procurement.Number)
                .First();
        }
        catch { }

        try
        {
            if (def == null)
            {
                procurement.ProcurementStateId = 20;

                _ = db.Procurements.Add(procurement);
                _ = db.SaveChanges();
            }
            else if (!PULL.ProcurementSource(procurement, def, isGetted))
                throw new Exception();
        }
        catch { isSaved = false; }

        return isSaved;
    }

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
            procurementsEmployee.Procurement = null;
            procurementsEmployee.Employee = null;

            _ = db.ProcurementsEmployees.Add(procurementsEmployee);
            _ = db.SaveChanges();
        }
        catch { isSaved = false; }

        return isSaved;
    }
}