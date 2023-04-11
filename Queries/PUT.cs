using DatabaseLibrary.Entities.ProcurementProperties;

namespace DatabaseLibrary.Queries;

public static class PUT
{
    public static bool Law(Law law)
    {
        using ParsethingContext db = new();
        bool isSaved = true;

        try
        {
            _ = db.Laws.Add(law);
            _ = db.SaveChanges();
        }
        catch { isSaved = false; }

        return isSaved;
    }

    public static bool Method(Method method)
    {
        using ParsethingContext db = new();
        bool isSaved = true;
        try
        {
            _ = db.Methods.Add(method);
            _ = db.SaveChanges();
        }
        catch { isSaved = false; }

        return isSaved;
    }

    public static bool Organization(Organization organization)
    {
        using ParsethingContext db = new();
        bool isSaved = true;

        try
        {
            _ = db.Organizations.Add(organization);
            _ = db.SaveChanges();
        }
        catch { isSaved = false; }

        return isSaved;
    }

    public static bool Platform(Platform platform)
    {
        using ParsethingContext db = new();
        bool isSaved = true;

        try
        {
            _ = db.Platforms.Add(platform);
            _ = db.SaveChanges();
        }
        catch { isSaved = false; }

        return isSaved;
    }

    public static bool TimeZone(TimeZone timeZone)
    {
        using ParsethingContext db = new();
        bool isSaved = true;

        try
        {
            _ = db.TimeZones.Add(timeZone);
            _ = db.SaveChanges();
        }
        catch { isSaved = false; }

        return isSaved;
    }
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