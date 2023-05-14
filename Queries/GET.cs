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
        public static Region? Region(string title, int distance)
        {
            using ParsethingContext db = new();
            Region? region = null;

            try
            {
                region = db.Regions
                    .Where(r => r.Title == title && r.Distance == distance)
                    .First();
            }
            catch { }

            return region;
        }
    }

    public struct View
    {
        public static List<Law>? Laws()
        {
            using ParsethingContext db = new();
            List<Law> laws = null;
            try
            {
                laws = db.Laws
                    .ToList();
            }
            catch { }

            return laws;
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
        public static List<Employee>? EmployeesBy(string premierPosition, string secondPosition, string thirdPosition)
        {
            using ParsethingContext db = new();
            List<Employee>? employees = null;

            try
            {
                employees = db.Employees
                    .Include(e => e.Position)
                    .Where(e => e.Position.Kind == premierPosition || e.Position.Kind == secondPosition || e.Position.Kind == thirdPosition)
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

        public static List<History>? HistoriesBy(int procurementId)
        {
            using ParsethingContext db = new();
            List<History>? histories = null;

            try
            { 
                histories = db.Histories
                    .Include(h => h.Employee)
                    .Where(h => h.EntryId == procurementId && h.EntityType == "Procurement")
                    .ToList(); 
            }
            catch { }

            return histories;
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

        public static List<RepresentativeType>? RepresentativeTypes()
        {
            using ParsethingContext db = new();
            List<RepresentativeType>? representativeTypes = null;

            try { representativeTypes = db.RepresentativeTypes.ToList(); }
            catch { }

            return representativeTypes;
        }
        public static List<ShipmentPlan>? ShipmentPlans()
        {
            using ParsethingContext db = new();
            List<ShipmentPlan>? shipmentPlans = null;

            try { shipmentPlans = db.ShipmentPlans.ToList(); }
            catch { }

            return shipmentPlans;
        }
        public static List<ExecutionState>? ExecutionStates()
        {
            using ParsethingContext db = new();
            List<ExecutionState>? executionStates = null;

            try { executionStates = db.ExecutionStates.ToList(); }
            catch { }

            return executionStates;
        }
        public static List<WarrantyState>? WarrantyStates()
        {
            using ParsethingContext db = new();
            List<WarrantyState>? warrantyStates = null;

            try { warrantyStates = db.WarrantyStates.ToList(); }
            catch { }

            return warrantyStates;
        }
        public static List<SignedOriginal>? SignedOriginals()
        {
            using ParsethingContext db = new();
            List<SignedOriginal>? signedOriginals = null;

            try { signedOriginals = db.SignedOriginals.ToList(); }
            catch { }

            return signedOriginals;
        }
        public static List<CommisioningWork>? CommissioningWorks()
        {
            using ParsethingContext db = new();
            List<CommisioningWork>? commissioningWorks = null;

            try { commissioningWorks = db.CommisioningWorks.ToList(); }
            catch { }

            return commissioningWorks;
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

        public static List<ComponentCalculation>? ComponentCalculationsBy(string kind)
        {
            using ParsethingContext db = new();
            List<ComponentCalculation> componentCalculations = null;

            try
            {
                componentCalculations = db.ComponentCalculations
                    .Include(cc => cc.ComponentState)
                    .Include(cc => cc.Procurement)
                    .Include(cc => cc.Procurement.Law)
                    .Include(cc => cc.Procurement.ProcurementState)
                    .Include(cc => cc.Procurement.Region)
                    .Include(cc => cc.Procurement.Method)
                    .Include(cc => cc.Procurement.Platform)
                    .Include(cc => cc.Procurement.TimeZone)
                    .Include(cc => cc.Procurement.Organization)
                    .Include(cc => cc.Manufacturer)
                    .Include(cc => cc.ComponentType)
                    .Include(cc => cc.Seller)
                    .Where(cc => cc.ComponentState.Kind == kind)
                    .ToList();
            }
            catch { }

            return componentCalculations;
        }

        public static List<ComponentCalculation>? ComponentCalculationsBy(int procurementId)
        {
            using ParsethingContext db = new();
            List<ComponentCalculation> componentCalculations = null;

            try
            {
                componentCalculations = db.ComponentCalculations
                    .Include(cc => cc.ComponentState)
                    .Include(cc => cc.Procurement)
                    .Include(cc => cc.Procurement.Law)
                    .Include(cc => cc.Procurement.ProcurementState)
                    .Include(cc => cc.Procurement.Region)
                    .Include(cc => cc.Procurement.Method)
                    .Include(cc => cc.Procurement.Platform)
                    .Include(cc => cc.Procurement.TimeZone)
                    .Include(cc => cc.Procurement.Organization)
                    .Include(cc => cc.Manufacturer)
                    .Include(cc => cc.ComponentType)
                    .Include(cc => cc.Seller)
                    .Where(cc => cc.ProcurementId == procurementId)
                    .ToList();
            }
            catch { }

            return componentCalculations;
        }

        public static List<Method>? Methods()
        {
            using ParsethingContext db = new();
            List<Method> methods = null;
            try
            {
                methods = db.Methods
                    .ToList();
            }
            catch { }

            return methods;
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
                            .Include(p => p.Method)
                            .Include(p => p.Platform)
                            .Include(p => p.TimeZone)
                            .Include(p => p.Region)
                            .Include(p => p.ShipmentPlan)
                            .Include(p => p.Organization)
                            .Where(p => p.ProcurementState != null && p.ProcurementState.Kind == kind)
                            .ToList();
                        break;
                    case KindOf.ShipmentPlane:
                        procurements = db.Procurements
                            .Include(p => p.ShipmentPlan)
                            .Include(p => p.Law)
                            .Include(p => p.Method)
                            .Include(p => p.Platform)
                            .Include(p => p.TimeZone)
                            .Include(p => p.Region)
                            .Include(p => p.Organization)
                            .Include(p => p.ProcurementState)
                            .Where(p => p.ShipmentPlan != null && p.ShipmentPlan.Kind == kind)
                            .Where(p => p.ProcurementState.Kind == "Выигран 1ч" || p.ProcurementState.Kind == "Выигран 2ч" || p.ProcurementState.Kind == "Приемка")
                            .ToList();
                        break;
                    case KindOf.Applications:
                        procurements = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Include(p => p.Law)
                            .Include(p => p.Method)
                            .Include(p => p.Platform)
                            .Include(p => p.Organization)
                            .Include(p => p.TimeZone)
                            .Include(p => p.Region)
                            .Include(p => p.ShipmentPlan)
                            .Where(p => p.Applications == true)
                            .ToList();
                        break;
                }
            }
            catch { }

            return procurements;
        }

        public static List<Procurement>? ProcurementsBy(string procurementStateKind, bool isOverdue, KindOf kindOf)
        {
            using ParsethingContext db = new();
            List<Procurement>? procurements = null;

            try
            {
                switch (kindOf)
                {
                    case KindOf.Deadline:
                        if (isOverdue)
                        {
                            procurements = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Include(p => p.Law)
                            .Include(p => p.Method)
                            .Include(p => p.Platform)
                            .Include(p => p.Organization)
                            .Include(p => p.TimeZone)
                            .Include(p => p.Region)
                            .Include(p => p.ShipmentPlan)
                            .Where(p => p.ProcurementState.Kind == procurementStateKind)
                            .Where(p => p.Deadline < DateTime.Now)
                            .ToList();
                        }
                        else
                        {
                            procurements = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Include(p => p.Law)
                            .Include(p => p.Method)
                            .Include(p => p.Platform)
                            .Include(p => p.Organization)
                            .Include(p => p.TimeZone)
                            .Include(p => p.Region)
                            .Include(p => p.ShipmentPlan)
                            .Where(p => p.ProcurementState.Kind == procurementStateKind)
                            .Where(p => p.Deadline > DateTime.Now)
                            .ToList();
                        }
                        break;
                    case KindOf.StartDate:
                        if (isOverdue)
                        {
                            procurements = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Include(p => p.Law)
                            .Include(p => p.Method)
                            .Include(p => p.Platform)
                            .Include(p => p.Organization)
                            .Include(p => p.TimeZone)
                            .Include(p => p.Region)
                            .Include(p => p.ShipmentPlan)
                            .Where(p => p.ProcurementState.Kind == procurementStateKind)
                            .Where(p => p.StartDate < DateTime.Now)
                            .ToList();
                        }
                        else
                        {
                            procurements = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Include(p => p.Law)
                            .Include(p => p.Method)
                            .Include(p => p.Platform)
                            .Include(p => p.Organization)
                            .Include(p => p.TimeZone)
                            .Include(p => p.Region)
                            .Include(p => p.ShipmentPlan)
                            .Where(p => p.ProcurementState.Kind == procurementStateKind)
                            .Where(p => p.StartDate > DateTime.Now)
                            .ToList();
                        }
                        break;
                }

            }
            catch { }

            return procurements;
        }

        public static List<Procurement>? ProcurementsBy(bool isOverdue)
        {
            using ParsethingContext db = new();
            List<Procurement>? procurements = null;

            try
            {
                if (isOverdue)
                {
                    procurements = db.Procurements
                    .Include(p => p.ProcurementState)
                    .Include(p => p.Law)
                    .Include(p => p.Method)
                    .Include(p => p.Platform)
                    .Include(p => p.Organization)
                    .Include(p => p.TimeZone)
                    .Include(p => p.Region)
                    .Include(p => p.ShipmentPlan)
                    .Where(p => p.ProcurementState.Kind == "Принят")
                    .Where(p => p.MaxDueDate < DateTime.Now)
                    .Where(p => p.RealDueDate == null)
                    .ToList();
                }
                else
                {
                    procurements = db.Procurements
                    .Include(p => p.ProcurementState)
                    .Include(p => p.Law)
                    .Include(p => p.Method)
                    .Include(p => p.Platform)
                    .Include(p => p.Organization)
                    .Include(p => p.TimeZone)
                    .Include(p => p.Region)
                    .Include(p => p.ShipmentPlan)
                    .Where(p => p.ProcurementState.Kind == "Принят")
                    .Where(p => p.MaxDueDate > DateTime.Now)
                    .Where(p => p.RealDueDate == null)
                    .ToList();
                }
            }
            catch { }

            return procurements;
        }
        public static List<Procurement>? ProcurementsNotPaid()
        {
            using ParsethingContext db = new();
            List<Procurement>? procurements = null;

            try
            {
                procurements = db.Procurements
                .Include(p => p.ProcurementState)
                .Include(p => p.Law)
                .Include(p => p.Method)
                .Include(p => p.Platform)
                .Include(p => p.Organization)
                .Include(p => p.TimeZone)
                .Include(p => p.Region)
                .Include(p => p.ShipmentPlan)
                .Where(p => p.ProcurementState.Kind == "Принят")
                .Where(p => p.RealDueDate == null)
                .Where(p => p.MaxDueDate != null)
                .ToList();
            }
            catch { }

            return procurements;
        }

        public static List<Procurement>? ProcurementsBy(KindOf kindOf)
        {
            using ParsethingContext db = new();
            List<Procurement>? procurements = null;

            try
            {
                switch (kindOf)
                {
                    case KindOf.Judgement:
                        procurements = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Include(p => p.Law)
                            .Include(p => p.Method)
                            .Include(p => p.Platform)
                            .Include(p => p.Organization)
                            .Include(p => p.TimeZone)
                            .Include(p => p.Region)
                            .Include(p => p.ShipmentPlan)
                            .Where(p => p.Judgment == true)
                            .ToList();
                        break;
                    case KindOf.FAS:
                        procurements = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Include(p => p.Law)
                            .Include(p => p.Method)
                            .Include(p => p.Platform)
                            .Include(p => p.Organization)
                            .Include(p => p.TimeZone)
                            .Include(p => p.Region)
                            .Include(p => p.ShipmentPlan)
                            .Where(p => p.Fas == true)
                            .ToList();
                        break;
                }
            }
            catch { }

            return procurements;
        }

        public static List<Procurement>? ProcurementsBy(int searchId, string searchNumber, string searchLaw, string searchProcurementState, string searchInn)
        {
            using ParsethingContext db = new();
            List<Procurement>? procurements = null;

            var query = db.Procurements.AsQueryable();

            if (searchId != 0)
                query = query.Where(p => p.Id == searchId);
            if (!string.IsNullOrEmpty(searchNumber))
                query = query.Where(p => p.Number == searchNumber);
            if (!string.IsNullOrEmpty(searchLaw))
                query = query.Where(p => p.Law.Number == searchLaw);
            if (!string.IsNullOrEmpty(searchProcurementState))
                query = query.Where(p => p.ProcurementState.Kind == searchProcurementState);
            if (!string.IsNullOrEmpty(searchInn))
                query = query.Where(p => p.Inn == searchInn);

            query = query.Include(p => p.ProcurementState);
            query = query.Include(p => p.Law);
            query = query.Include(p => p.Method);
            query = query.Include(p => p.Platform);
            query = query.Include(p => p.TimeZone);
            query = query.Include(p => p.Region);
            query = query.Include(p => p.ShipmentPlan);
            query = query.Include(p => p.Organization);

            procurements = query.ToList();

            return procurements;
        }

        public static List<ProcurementsEmployeesGrouping>? ProcurementsGroupByMethod()
        {
            using ParsethingContext db = new();
            var procurementsEmployees = db.Procurements
                .Include(p => p.Method)
                .Include(p => p.ProcurementState)
                .Where(p => p.Method != null)
                .Where(p => p.ProcurementState.Kind == "Отправлен")
                .GroupBy(p => p.Method.Text)
                .Select(g => new ProcurementsEmployeesGrouping { Id = g.Key, CountOfProcurements = g.Count() })
                .ToList();

            return procurementsEmployees;
        }

        public static List<Comment>? CommentsBy (int procurementId)
        {
            using ParsethingContext db = new();
            var comments = db.Comments
                .Include(c => c.Employee)
                .Where(pe => pe.EntryId == procurementId)
                .Where(c => c.EntityType == "Procurement")
                .ToList();

            return comments;
        }

        public static List<ProcurementsEmployeesGrouping>? ProcurementsEmployeesGroupBy(int employeeId)
        {
            using ParsethingContext db = new();
            var procurementsEmployees = db.ProcurementsEmployees
                .Include(pe => pe.Employee)
                .Include(pe => pe.Procurement.Method)
                .Include(pe => pe.Procurement)
                .Where(pe => pe.EmployeeId == employeeId)
                .GroupBy(pe => pe.Employee.FullName)
                .Select(g => new ProcurementsEmployeesGrouping {Id = g.Key, CountOfProcurements = g.Count() })
                .ToList();

            return procurementsEmployees;
        }

        public static List<ProcurementsEmployeesGrouping>? ProcurementsEmployeesGroupBy(string premierPosition, string secondPosition, string thirdPosition, string premierProcurementState, string secondProcurementState, string thirdProcurementState)
        {
            using ParsethingContext db = new();
            var procurementsEmployees = db.ProcurementsEmployees
                .Include(pe => pe.Employee)
                .Include(pe => pe.Procurement.ProcurementState)
                .Include(pe => pe.Employee.Position)
                .Include(pe => pe.Procurement.Method)
                .Include(pe => pe.Procurement)
                .Where(pe => pe.Employee.Position.Kind == premierPosition || pe.Employee.Position.Kind == secondPosition || pe.Employee.Position.Kind == thirdPosition)
                .Where(pe => pe.Procurement.ProcurementState.Kind == premierProcurementState || pe.Procurement.ProcurementState.Kind == secondProcurementState || pe.Procurement.ProcurementState.Kind == thirdProcurementState)
                .GroupBy(pe => pe.Employee.FullName)
                .Select(g => new ProcurementsEmployeesGrouping { Id = g.Key , CountOfProcurements = g.Count() })
                .ToList();

            return procurementsEmployees;
        }

        public static List<ProcurementsEmployeesGrouping>? ProcurementsEmployeesGroupBy(string premierPosition, string secondPosition, string thirdPosition)
        {
            using ParsethingContext db = new();
            var procurementsEmployees = db.ProcurementsEmployees
                .Include(pe => pe.Employee)
                .Include(pe => pe.Procurement.ProcurementState)
                .Include(pe => pe.Employee.Position)
                .Include(pe => pe.Procurement.Method)
                .Include(pe => pe.Procurement)
                .Where(pe => pe.Employee.Position.Kind == premierPosition || pe.Employee.Position.Kind == secondPosition || pe.Employee.Position.Kind == thirdPosition)
                .GroupBy(pe => pe.Employee.FullName)
                .Select(g => new ProcurementsEmployeesGrouping { Id = g.Key, CountOfProcurements = g.Count() })
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
                    .Include(pe => pe.Procurement.Method)
                    .Include(pe => pe.Procurement.Platform)
                    .Include(pe => pe.Procurement.TimeZone)
                    .Include(pe => pe.Procurement.Region)
                    .Include(pe => pe.Procurement.Organization)
                    .Where(pe => pe.Procurement.ProcurementState != null && pe.Procurement.ProcurementState.Kind == procurementStateKind)
                    .Where(pe => pe.Employee.Id == employeeId)
                    .ToList();
            }
            catch { }

            return procurements;
        }
        public static ProcurementsEmployee? ProcurementsEmployeesBy(Procurement procurement, string premierPosition, string secondPosition, string thirdPosition)
        {
            using ParsethingContext db = new();
            ProcurementsEmployee? procurementsEmployee = null;

            try
            {
                procurementsEmployee = db.ProcurementsEmployees
                .Include(pe => pe.Employee)
                .Include(pe => pe.Employee.Position)
                .Where(pe => pe.ProcurementId == procurement.Id && (pe.Employee.Position.Kind == premierPosition || pe.Employee.Position.Kind == secondPosition || pe.Employee.Position.Kind == thirdPosition))
                .First();
            }
            catch { }

            return procurementsEmployee;
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
                    .Include(pe => pe.Procurement.Method)
                    .Include(pe => pe.Employee)
                    .Include(pe => pe.Procurement.Law)
                    .Include(pe => pe.Procurement.Platform)
                    .Include(pe => pe.Procurement.TimeZone)
                    .Include(pe => pe.Procurement.Region)
                    .Include(pe => pe.Procurement.Organization)
                    .Where(pe => pe.Procurement.ProcurementState != null)
                    .Where(pe => pe.Employee.Id == employeeId)
                    .ToList();
            }
            catch { }

            return procurements;
        }
        public static List<ProcurementsPreference>? ProcurementsPreferencesBy(int procurementId)
        {
            using ParsethingContext db = new();
            List<ProcurementsPreference>? procurementsPreferences = null;

            try
            {
                procurementsPreferences = db.ProcurementsPreferences
                    .Include(pp => pp.Procurement)
                    .Include(pp => pp.Preference)
                    .Where(pe => pe.ProcurementId == procurementId)
                    .ToList();
            }
            catch { }

            return procurementsPreferences;
        }

        public static List<ProcurementsDocument>? ProcurementsDocumentsBy(int procurementId)
        {
            using ParsethingContext db = new();
            List<ProcurementsDocument>? procurementsDocuments = null;

            try
            {
                procurementsDocuments = db.ProcurementsDocuments
                    .Include(pd => pd.Procurement)
                    .Include(pd => pd.Document)
                    .Where(pd => pd.ProcurementId == procurementId)
                    .ToList();
            }
            catch { }

            return procurementsDocuments;
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