using DatabaseLibrary.Entities.EmployeeMuchToMany;

namespace DatabaseLibrary.Functions;

public static class GET
{
    public static int LawId(Law law)
    {
        using ParsethingContext db = new();
        int id = 0;
        Law? def = null;

        try
        {
            def = db.Laws
                .Where(l => l.Number == law.Number)
                .First();
        }
        catch { }

        if (def != null)
            id = def.Id;
        else
        {
            _ = db.Laws.Add(law);
            _ = db.SaveChanges();

            id = db.Laws
                .Where(l => l.Number == law.Number)
                .First().Id;
        }

        return id;
    }

    public static int MethodId(Method method)
    {
        using ParsethingContext db = new();
        int id = 0;
        Method? def = null;

        if (method.Text != string.Empty)
        {
            try
            {
                def = db.Methods
                    .Where(m => m.Text == method.Text)
                    .First();
            }
            catch { }

            if (def != null)
                id = def.Id;
            else
            {
                _ = db.Methods.Add(method);
                _ = db.SaveChanges();

                id = db.Methods
                    .Where(m => m.Text == method.Text)
                    .First().Id;
            }
        }

        return id;
    }

    public static int OrganizationId(Organization organization)
    {
        using ParsethingContext db = new();
        int id = 0;
        Organization? def = null;

        try
        {
            def = db.Organizations
                .Where(o => o.Name == organization.Name)
                .First();
        }
        catch { }

        if (def != null)
        {
            if (organization.PostalAddress != string.Empty)
                def.PostalAddress = organization.PostalAddress;

            _ = db.Organizations.Update(def);
            _ = db.SaveChanges();

            id = def.Id;
        }
        else
        {
            if (organization.PostalAddress != string.Empty)
                organization.PostalAddress = null;

            _ = db.Organizations.Add(organization);
            _ = db.SaveChanges();

            id = db.Organizations
                .Where(o => o.Name == organization.Name)
                .Where(o => o.PostalAddress == organization.PostalAddress)
                .First().Id;
        }

        return id;
    }

    public static int PlatformId(Platform platform)
    {
        using ParsethingContext db = new();
        int id = 0;
        Platform? def = null;

        if (platform.Name != string.Empty && platform.Address != string.Empty)
        {
            try
            {
                def = db.Platforms
                    .Where(p => p.Name == platform.Name)
                    .Where(p => p.Address == platform.Address)
                    .First();
            }
            catch { }

            if (def != null)
                id = def.Id;
            else
            {
                _ = db.Platforms.Add(platform);
                _ = db.SaveChanges();

                id = db.Platforms
                    .Where(p => p.Name == platform.Name)
                    .Where(p => p.Address == platform.Address)
                    .First().Id;
            }
        }

        return id;
    }

    public static int TimeZoneId(TimeZone timeZone)
    {
        using ParsethingContext db = new();
        int id = 0;
        TimeZone? def = null;

        if (timeZone.Offset != string.Empty)
        {
            try
            {
                def = db.TimeZones
                    .Where(tz => tz.Offset == timeZone.Offset)
                    .First();
            }
            catch { }

            if (def != null)
                id = def.Id;
            else
            {
                _ = db.TimeZones.Add(timeZone);
                _ = db.SaveChanges();

                id = db.TimeZones
                    .Where(tz => tz.Offset == timeZone.Offset)
                    .First().Id;
            }
        }

        return id;
    }

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

        try { employees = db.Employees.ToList(); }
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

    public static List<Tag>? Tags()
    {
        using ParsethingContext db = new();
        List<Tag>? tags = null;

        try { tags = db.Tags.ToList(); }
        catch { }

        return tags;
    }

    public enum KindOf
    {
        ProcurementState,
        ShipmentPlane
    }
}