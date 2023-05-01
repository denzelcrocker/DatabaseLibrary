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

        public static List<Document>? Documents()
        {
            using ParsethingContext db = new();
            List<Document>? documents = null;

            try
            {
                documents = db.Documents
                    .ToList();
            }
            catch { }

            return documents;
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

        public static List<LegalEntity>? LegalEntities()
        {
            using ParsethingContext db = new();
            List<LegalEntity>? LegalEntitys = null;

            try { LegalEntitys = db.LegalEntities.ToList(); }
            catch { }

            return LegalEntitys;
        }

        public static List<Manufacturer>? Manufacturers()
        {
            using ParsethingContext db = new();
            List<Manufacturer>? manufacturers = null;

            try { manufacturers = db.Manufacturers.ToList(); }
            catch { }

            return manufacturers;
        }

        public static List<Minopttorg>? Minopttorgs()
        {
            using ParsethingContext db = new();
            List<Minopttorg>? minopttorgs = null;

            try { minopttorgs = db.Minopttorgs.ToList(); }
            catch { }

            return minopttorgs;
        }

        public static List<Position>? Positions()
        {
            using ParsethingContext db = new();
            List<Position>? positions = null;

            try { positions = db.Positions.ToList(); }
            catch { }

            return positions;
        }

        public static List<Preference>? Preferences()
        {
            using ParsethingContext db = new();
            List<Preference>? preferences = null;

            try { preferences = db.Preferences.ToList(); }
            catch { }

            return preferences;
        }

        public static List<Procurement>? ProcurementSources()
        {
            using ParsethingContext db = new();
            List<Procurement>? procurements = null;

            try
            {
                procurements = db.Procurements
                    .Include(p => p.ProcurementState)
                    .Include(p => p.Law)
                    .Include(p => p.Organization)
                    .Include(p => p.Method)
                    .Include(p => p.Platform)
                    .Include(p => p.TimeZone)
                    .Where(p => p.ProcurementState != null && p.ProcurementState.Kind == "Получен")
                    .ToList();
            }
            catch { }

            return procurements;
        }

        public static List<Procurement>? ProcurementsBy(string kind, KindOf kindOf)
        {
            using ParsethingContext db = new();
            List<Procurement>? procurements = null;

            try
            {
                switch (kindOf)
                {
                    case KindOf.ProcurementState:
                        procurements = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Include(p => p.Law)
                            .Include(e => e.ShipmentPlan)
                            .Where(p => p.ProcurementState != null && p.ProcurementState.Kind == kind)
                            .ToList();
                        break;
                    case KindOf.ShipmentPlane:
                        procurements = db.Procurements
                            .Include(e => e.ShipmentPlan)
                            .Include(p => p.Law)
                            .Include(p => p.ProcurementState)
                            .Where(p => p.ShipmentPlan != null && p.ShipmentPlan.Kind == kind)
                            .ToList();
                        break;
                    case KindOf.Applications:
                        procurements = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Include(p => p.Law)
                            .Include(e => e.ShipmentPlan)
                            .Where(p => p.Applications == true)
                            .ToList();
                        break;
                }
            }
            catch { }

            return procurements;
        }

        public static List<ProcurementsEmployeesGrouping>? ProcurementsEmployeesGroupBy(int employeeId)
        {
            using ParsethingContext db = new();
            var procurementsEmployees = db.ProcurementsEmployees
                .Include(pe => pe.Employee)
                .Include(pe => pe.Procurement)
                .Where(pe => pe.EmployeeId == employeeId)
                .GroupBy(pe => pe.Employee.FullName)
                .Select(g => new ProcurementsEmployeesGrouping {Id = g.Key, CountOfProcurements = g.Count() })
                .ToList();

            return procurementsEmployees;
        }

        public static List<ProcurementsEmployeesGrouping>? ProcurementsEmployeesGroupBy(string position)
        {
            using ParsethingContext db = new();
            var procurementsEmployees = db.ProcurementsEmployees
                .Include(pe => pe.Employee)
                .Include(pe => pe.Employee.Position)
                .Include(pe => pe.Procurement)
                .Where(pe => pe.Employee.Position.Kind == position)
                .GroupBy(pe => pe.Employee.FullName)
                .Select(g => new ProcurementsEmployeesGrouping { Id = g.Key , CountOfProcurements = g.Count() })
                .ToList();

            return procurementsEmployees;
        }

        //public static List<ProcurementsEmployee>? ProcurementsEmployeesQueue()
        //{
        //    using ParsethingContext db = new();
        //    List<ProcurementsEmployee>? procurements = null;

        //    try
        //    {
        //        procurements = db.ProcurementsEmployees
        //            .Include(pe => pe.Procurement)
        //            .Include(pe => pe.Procurement.ProcurementState)
        //            .Include(pe => pe.Employee)
        //            .Include(pe => pe.Employee.Position)
        //            .Include(pe => pe.Procurement.Law)
        //            .Where(pe => pe.Procurement.ProcurementState != null && pe.Procurement.ProcurementState.Kind == "Новый")
        //            .Where(pe => pe.Employee.Position.Kind != "Специалист отдела расчетов")
        //            .ToList();
        //    }
        //    catch { }

        //    return procurements;
        //}

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
                    .Include(pe => pe.Procurement.Law)
                    .Where(pe => pe.Procurement.ProcurementState != null && pe.Procurement.ProcurementState.Kind == procurementStateKind)
                    .Where(pe => pe.Employee.Id == employeeId)
                    .ToList();
            }
            catch { }

            return procurements;
        }
        public static List<ProcurementsEmployee>? ProcurementsEmployeesBy(int employeeId)
        {
            using ParsethingContext db = new();
            List<ProcurementsEmployee>? procurements = null;

            try
            {
                procurements = db.ProcurementsEmployees
                    .Include(pe => pe.Procurement)
                    .Include(pe => pe.Procurement.ProcurementState)
                    .Include(pe => pe.Employee)
                    .Include(pe => pe.Procurement.Law)
                    .Where(pe => pe.Procurement.ProcurementState != null)
                    .Where(pe => pe.Employee.Id == employeeId)
                    .ToList();
            }
            catch { }

            return procurements;
        }

        public static List<ProcurementState>? DistributionOfProcurementStates(string employeePosition)
        {
            using ParsethingContext db = new();
            List<ProcurementState>? procurementStates = null;

            try 
            { 
                switch(employeePosition)
                {
                    case "Администратор":
                        procurementStates = db.ProcurementStates.ToList();
                        break;
                    case "Руководитель отдела расчетов":
                        procurementStates = db.ProcurementStates
                            .Where(ps => ps.Kind == "Новый" || ps.Kind == "Посчитан" || ps.Kind == "Оформить" || ps.Kind == "Оформлен" || ps.Kind == "Выигран 1ч" || ps.Kind == "Выигран 2ч" || ps.Kind == "Разбор" || ps.Kind == "Отбой")
                            .ToList();
                        break;
                    case "Заместитель руководителя отдела расчетов":
                        procurementStates = db.ProcurementStates
                            .Where(ps => ps.Kind == "Новый" || ps.Kind == "Посчитан" || ps.Kind == "Оформить" || ps.Kind == "Оформлен" || ps.Kind == "Выигран 1ч" || ps.Kind == "Выигран 2ч" || ps.Kind == "Разбор" || ps.Kind == "Отбой")
                            .ToList();
                        break;
                    case "Специалист отдела расчетов":
                        procurementStates = db.ProcurementStates
                            .Where(ps => ps.Kind == "Новый" || ps.Kind == "Посчитан" || ps.Kind == "Оформить" || ps.Kind == "Оформлен")
                            .ToList();
                        break;
                    case "Руководитель тендерного отдела":
                        procurementStates = db.ProcurementStates
                            .Where(ps => ps.Kind == "Выигран 1ч" || ps.Kind == "Выигран 2ч" || ps.Kind == "Приемка" || ps.Kind == "Принят" || ps.Kind == "Отклонен" || ps.Kind == "Отмена" || ps.Kind == "Проигран")
                            .ToList();
                        break;
                    case "Заместитель руководителя тендреного отдела":
                        procurementStates = db.ProcurementStates
                            .Where(ps => ps.Kind == "Выигран 1ч" || ps.Kind == "Выигран 2ч" || ps.Kind == "Приемка" || ps.Kind == "Принят" || ps.Kind == "Отклонен" || ps.Kind == "Отмена" || ps.Kind == "Проигран")
                            .ToList();
                        break;
                    case "Специалист тендерного отдела":
                        procurementStates = db.ProcurementStates
                            .Where(ps => ps.Kind == "Выигран 1ч" || ps.Kind == "Выигран 2ч" || ps.Kind == "Приемка" || ps.Kind == "Принят")
                            .ToList();
                        break;
                    case "Специалист по работе с электронными площадками":
                        procurementStates = db.ProcurementStates
                            .Where(ps => ps.Kind == "Оформлен" || ps.Kind == "Отправлен" || ps.Kind == "Выигран 1ч" || ps.Kind == "Отмена" || ps.Kind == "Проигран")
                            .ToList();
                        break;
                    case "Руководитель отдела закупки":
                        procurementStates = db.ProcurementStates
                            .Where(ps => ps.Kind == "Выигран 1ч" || ps.Kind == "Выигран 2ч" || ps.Kind == "Приемка")
                            .ToList();
                        break;
                    case "Заместитель руководителя отдела закупок":
                        procurementStates = db.ProcurementStates
                            .Where(ps => ps.Kind == "Выигран 1ч" || ps.Kind == "Выигран 2ч" || ps.Kind == "Приемка")
                            .ToList();
                        break;
                    case "Специалист закупки":
                        procurementStates = db.ProcurementStates
                            .Where(ps => ps.Kind == "Выигран 1ч" || ps.Kind == "Выигран 2ч" || ps.Kind == "Приемка")
                            .ToList();
                        break;
                    case "Руководитель отдела производства":
                        procurementStates = db.ProcurementStates
                            .Where(ps => ps.Kind == "Выигран 2ч")
                            .ToList();
                        break;
                    case "Заместитель руководителя отдела производства":
                        procurementStates = db.ProcurementStates
                            .Where(ps => ps.Kind == "Выигран 2ч")
                            .ToList();
                        break;
                    case "Специалист по производству":
                        procurementStates = db.ProcurementStates
                            .Where(ps => ps.Kind == "Выигран 2ч")
                            .ToList();
                        break;
                    case "Юрист":
                        procurementStates = db.ProcurementStates
                            .ToList();
                        break;
                }
            }
            catch { }

            return procurementStates;
        }

        public static List<ProcurementState>? ProcurementStates()
        {
            using ParsethingContext db = new();
            List<ProcurementState>? procurementStates = null;

            try { procurementStates = db.ProcurementStates.ToList(); }
            catch { }

            return procurementStates;
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
                    case KindOf.Applications:
                        count = db.Procurements
                            .Where(p => p.Applications == true)
                            .Count();
                        break;
                }
            }
            catch { }

            return count;
        }
        public static int ProcurementsCountBy(bool isOverdue)
        {
            using ParsethingContext db = new();
            int count = 0;

            try
            {
                if (isOverdue)
                {
                    count = db.Procurements
                    .Include(p => p.ProcurementState)
                    .Where(p => p.ProcurementState.Kind == "Принят")
                    .Where(p => p.MaxDueDate < DateTime.Now)
                    .Where(p => p.RealDueDate == null)
                    .Count();
                }
                else
                {
                    count = db.Procurements
                    .Include(p => p.ProcurementState)
                    .Where(p => p.ProcurementState.Kind == "Принят")
                    .Where(p => p.MaxDueDate > DateTime.Now)
                    .Where(p => p.RealDueDate == null)
                    .Count();
                }
            }
            catch { }

            return count;
        }
        public static int ProcurementsCountBy(KindOf kindOf)
        {
            using ParsethingContext db = new();
            int count = 0;

            try
            {
                switch (kindOf)
                {
                    case KindOf.Judgement:
                        count = db.Procurements
                            .Where(p => p.Judgment == true)
                            .Count();
                        break;
                    case KindOf.FAS:
                        count = db.Procurements
                            .Where(p => p.Fas == true)
                            .Count();
                        break;
                }
            }
            catch { }

            return count;
        }

        public static int ProcurementsCountBy(string procurementStateKind, bool isOverdue, KindOf kindOf)
        {
            using ParsethingContext db = new();
            int count = 0;

            try
            {
                switch (kindOf)
                {
                    case KindOf.Deadline:
                        if (isOverdue)
                        {
                            count = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Where(p => p.ProcurementState.Kind == procurementStateKind)
                            .Where(p => p.Deadline < DateTime.Now)
                            .Count();
                        }
                        else
                        {
                            count = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Where(p => p.ProcurementState.Kind == procurementStateKind)
                            .Where(p => p.Deadline > DateTime.Now)
                            .Count();
                        }
                        break;
                    case KindOf.StartDate:
                        if (isOverdue)
                        {
                            count = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Where(p => p.ProcurementState.Kind == procurementStateKind)
                            .Where(p => p.StartDate < DateTime.Now)
                            .Count();
                        }
                        else
                        {
                            count = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Where(p => p.ProcurementState.Kind == procurementStateKind)
                            .Where(p => p.StartDate > DateTime.Now)
                            .Count();
                        }
                        break;
                }
                
            }
            catch { }

            return count;
        }


    }
    public class ProcurementsEmployeesGrouping
    {
        public string Id { get; set; }
        public int CountOfProcurements { get; set; }
    }
    public enum KindOf
    {
        ProcurementState,
        ShipmentPlane,
        Applications,
        StartDate,
        Deadline,
        Judgement,
        FAS
    }
}