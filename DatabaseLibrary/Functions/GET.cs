namespace DatabaseLibrary.Functions;

public static class GET
{
    public static Employee? Employee(string userName, string password)
    {
        using ParsethingContext db = new();
        Employee? employee = null;

        try
        {
            employee = db.Employees
                .Include(e => e.Position)
                .Where(e => e.UserName == userName)
                .Where(e => e.Password == password)
                .First();
        }
        catch { }

        return employee;
    }

    public static List<Employee>? Employees()
    {
        using ParsethingContext db = new();
        List<Employee>? employees = null;

        try
        {
            employees = db.Employees.ToList();
        }
        catch { }

        return employees;
    }

    public static List<ProcurementsEmployee>? ProcurementsEmployeesBy(int employeeId, string positionKind, string procurementStateKind)
    {
        using ParsethingContext db = new();
        List<ProcurementsEmployee>? procurements = null;

        try
        {
            procurements = db.ProcurementsEmployees
                .Include(pe => pe.Procurement)
                .Include(pe => pe.Procurement.ProcurementState)
                .Include(pe => pe.Employee)
                .Include(pe => pe.Employee.Position)
                .Where(pe => pe.Procurement.ProcurementState != null && pe.Procurement.ProcurementState.Kind == procurementStateKind)
                .Where(pe => pe.Employee.Id == employeeId)
                .Where(pe => pe.Employee.Position.Kind == positionKind)
                .ToList();
        }
        catch { }

        return procurements;
    }


    public static int ProcurementsCountBy(string kind, KindOf kindOf)
    {
        using ParsethingContext db = new();
        int count = 0;

        try
        {
            switch (kindOf)
            {
                case KindOf.ProcurementState:
                    count = db.Procurements
                        .Include(p => p.ProcurementState)
                        .Where(p => p.ProcurementState != null && p.ProcurementState.Kind == kind)
                        .Count();
                    break;
                case KindOf.ShipmentPlane:
                    count = db.Procurements
                        .Include(e => e.ShipmentPlan)
                        .Where(p => p.ShipmentPlan != null && p.ShipmentPlan.Kind == kind)
                        .Count();
                    break;
            }
        }
        catch { }

        return count;
    }

    public enum KindOf
    {
        ProcurementState,
        ShipmentPlane
    }
}