using DatabaseLibrary.Entities.ComponentCalculationProperties;

namespace DatabaseLibrary.Queries;

public static class GET
{
    public struct Entry
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

        public static Law? Law(string number)
        {
            using ParsethingContext db = new();
            Law? law = null;

            try
            {
                law = db.Laws
                    .Where(l => l.Number == number)
                    .First();
            }
            catch { }

            return law;
        }

        public static Method? Method(string text)
        {
            using ParsethingContext db = new();
            Method? method = null;
            try
            {
                method = db.Methods
                    .Where(m => m.Text == text)
                    .First();
            }
            catch { }

            return method;
        }

        public static Organization? Organization(string name)
        {
            using ParsethingContext db = new();
            Organization? organization = null;

            try
            {
                organization = db.Organizations
                    .Where(o => o.Name == name)
                    .First();
            }
            catch { }

            return organization;
        }

        public static Organization? Organization(string name, string? postalAddress)
        {
            using ParsethingContext db = new();
            Organization? organization = null;

            try
            {
                organization = db.Organizations
                    .Where(o => o.Name == name)
                    .Where(o => o.PostalAddress == postalAddress)
                    .First();
            }
            catch { }

            return organization;
        }

        public static Platform? Platform(string name, string address)
        {
            using ParsethingContext db = new();
            Platform? platform = null;

            try
            {
                platform = db.Platforms
                    .Where(p => p.Name == name)
                    .Where(p => p.Address == address)
                    .First();
            }
            catch { }

            return platform;
        }

        public static Procurement? Procurement(string number)
        {
            using ParsethingContext db = new();
            Procurement? procurement = null;

            try
            {
                procurement = db.Procurements
                    .Where(p => p.Number == number)
                    .First();
            }
            catch { }

            return procurement;
        }

        public static TimeZone? TimeZone(string offset)
        {
            using ParsethingContext db = new();
            TimeZone? timeZone = null;

            try
            {
                timeZone = db.TimeZones
                    .Where(tz => tz.Offset == offset)
                    .First();
            }
            catch { }

            return timeZone;
        }
    }

    public struct View
    {
        public static List<Component>? Components()
        {
            using ParsethingContext db = new();
            List<Component>? components = null;

            try
            {
                components = db.Components
                    .Include(c => c.Manufacturer)
                    .Include(c => c.ComponentType)
                    .ToList();
            }
            catch { }

            return components;
        }

        public static List<ComponentState>? ComponentStates()
        {
            using ParsethingContext db = new();
            List<ComponentState>? componentStates = null;

            try { componentStates = db.ComponentStates.ToList(); }
            catch { }

            return componentStates;
        }

        public static List<ComponentType>? ComponentTypes()
        {
            using ParsethingContext db = new();
            List<ComponentType>? componentTypes = null;

            try { componentTypes = db.ComponentTypes.ToList(); }
            catch { }

            return componentTypes;
        }

        public static List<Employee>? Employees()
        {
            using ParsethingContext db = new();
            List<Employee>? employees = null;

            try
            {
                employees = db.Employees
                    .Include(e => e.Position)
                    .ToList();
            }
            catch { }

            return employees;
        }

        public static List<Manufacturer>? Manufacturers()
        {
            using ParsethingContext db = new();
            List<Manufacturer>? manufacturers = null;

            try { manufacturers = db.Manufacturers.ToList(); }
            catch { }

            return manufacturers;
        }

        public static List<Position>? Positions()
        {
            using ParsethingContext db = new();
            List<Position>? positions = null;

            try { positions = db.Positions.ToList(); }
            catch { }

            return positions;
        }

        public static List<ProcurementsEmployee>? ProcurementsEmployeesBy(int employeeId, string procurementStateKind)
        {
            using ParsethingContext db = new();
            List<ProcurementsEmployee>? procurements = null;

            try
            {
                procurements = db.ProcurementsEmployees
                    .Include(pe => pe.Procurement)
                    .Include(pe => pe.Procurement.ProcurementState)
                    .Include(pe => pe.Employee)
                    .Where(pe => pe.Procurement.ProcurementState != null && pe.Procurement.ProcurementState.Kind == procurementStateKind)
                    .Where(pe => pe.Employee.Id == employeeId)
                    .ToList();
            }
            catch { }

            return procurements;
        }

        public static List<Region>? Regions()
        {
            using ParsethingContext db = new();
            List<Region>? regions = null;

            try { regions = db.Regions.ToList(); }
            catch { }

            return regions;
        }

        public static List<Seller>? Sellers()
        {
            using ParsethingContext db = new();
            List<Seller>? sellers = null;

            try { sellers = db.Sellers.ToList(); }
            catch { }

            return sellers;
        }

        public static List<Tag>? Tags()
        {
            using ParsethingContext db = new();
            List<Tag>? tags = null;

            try { tags = db.Tags.ToList(); }
            catch { }

            return tags;
        }
    }

    public struct Aggregate
    {
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
    }

    public enum KindOf
    {
        ProcurementState,
        ShipmentPlane
    }
}