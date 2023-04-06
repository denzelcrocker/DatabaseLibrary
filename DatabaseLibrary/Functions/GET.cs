namespace DatabaseLibrary.Functions;

public static class GET
{
    public static Employee? Employee(string userName, string password)
    {
        using ParsethingContext db = new();
        Employee? employee = null;

        try
        {
            employee = db.Employees.Include(e => e.Position).Where(e => e.UserName == userName).Where(e => e.Password == password).First();
        }
        catch { }

        return employee;
    }
    public static List<ProcurementsEmployee>? ProcurementsEmployeesBy(int employeeId, string position, string state)
    {
        using ParsethingContext db = new();
        List<ProcurementsEmployee>? procurements = null;

        try
        {
            procurements = db.ProcurementsEmployees.Include(e => e.Procurement).Include(e => e.Procurement.ProcurementState).Include(e => e.Employee).Include(e => e.Employee.Position).
                Where(e =>e.Procurement.ProcurementState.Kind == state).Where(e => e.Employee.Id == employeeId).Where(e => e.Employee.Position.Kind == position).ToList();
        }
        catch { }

        return procurements;
    }

    
    public static int CountOfProcurementsByState(string state)
    {
        using ParsethingContext db = new();
        int count = 0;

        try
        {
            count = db.Procurements.Include(e => e.ProcurementState).Where(p => p.ProcurementState.Kind == state).Count();
        }
        catch { }

        return count;
    }
    public static int CountOfProcurementsByShipmentPlane(string shipmentPlane)
    {
        using ParsethingContext db = new();
        int count = 0;

        try
        {
            count = db.Procurements.Include(e => e.ShipmentPlan).Where(p => p.ShipmentPlan.Kind == shipmentPlane).Count();
        }
        catch { }

        return count;
    }

}