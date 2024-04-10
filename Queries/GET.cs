using DatabaseLibrary.Entities.ComponentCalculationProperties;

namespace DatabaseLibrary.Queries;

public static class GET
{
    public struct Entry
    {
        public static Employee? Employee(string userName, string password) // Авторизация
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

        public static Law? Law(string number) // Получить закон
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

        public static Method? Method(string text) // Получить метод
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

        public static Organization? Organization(string name) // Получить организацию
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

        public static Organization? Organization(string name, string? postalAddress) // Получить организацию по имени и адресу поставки
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

        public static Platform? Platform(string name, string address) // Получить платформу по имени и адресу
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

        public static Procurement? Procurement(string number) // Получить тендер
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
        public static Procurement? ProcurementBy(int id) // Получить тендер
        {
            using ParsethingContext db = new();
            Procurement? procurement = null;

            try
            {
                procurement = db.Procurements
                    .Include(p => p.ProcurementState)
                    .Include(p => p.Law)
                    .Include (p => p.ShipmentPlan)
                    .Where(p => p.Id == id)
                    .First();
            }
            catch { }

            return procurement;
        }

        public static TimeZone? TimeZone(string offset) // Получить часовой пояс
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
        public static Region? Region(string title, int distance) // Получить часовой пояс по дистанции и названию
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
        public static List<Law>? Laws() // Получить все законы
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

        public static List<ComponentState>? ComponentStates() // Получить все статусы тендеров
        {
            using ParsethingContext db = new();
            List<ComponentState>? componentStates = null;

            try { componentStates = db.ComponentStates.ToList(); }
            catch { }

            return componentStates;
        }

        public static List<ComponentType>? ComponentTypes() // Получить все типы комплектующих 
        {
            using ParsethingContext db = new();
            List<ComponentType>? componentTypes = null;

            try { componentTypes = db.ComponentTypes.ToList(); }
            catch { }

            return componentTypes;
        }

        public static List<Document>? Documents() // Получить документы к тендерам
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

        public static List<Employee>? Employees() // Получить сотрудников
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
        public static List<Employee>? EmployeesBy(string premierPosition, string secondPosition, string thirdPosition) // Получить сотрудников по трем должностям
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

        public static List<LegalEntity>? LegalEntities() // Получить список юридических лиц
        {
            using ParsethingContext db = new();
            List<LegalEntity>? LegalEntitys = null;

            try { LegalEntitys = db.LegalEntities.ToList(); }
            catch { }

            return LegalEntitys;
        }

        public static List<History>? HistoriesBy(int procurementId) // Получить историю изменений статусов тендеров
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

        public static List<Manufacturer>? Manufacturers() // Получить список производителей
        {
            using ParsethingContext db = new();
            List<Manufacturer>? manufacturers = null;

            try { manufacturers = db.Manufacturers.ToList(); }
            catch { }

            return manufacturers;
        }

        public static List<Minopttorg>? Minopttorgs() // Получить список Миноптторг
        {
            using ParsethingContext db = new();
            List<Minopttorg>? minopttorgs = null;

            try { minopttorgs = db.Minopttorgs.ToList(); }
            catch { }

            return minopttorgs;
        }

        public static List<Position>? Positions() // Получить список должностей
        {
            using ParsethingContext db = new();
            List<Position>? positions = null;

            try { positions = db.Positions.ToList(); }
            catch { }

            return positions;
        }

        public static List<Preference>? Preferences() // Получить список префренций
        {
            using ParsethingContext db = new();
            List<Preference>? preferences = null;

            try { preferences = db.Preferences.ToList(); }
            catch { }

            return preferences;
        }

        public static List<RepresentativeType>? RepresentativeTypes() // Получить список пусконаладочных работ
        {
            using ParsethingContext db = new();
            List<RepresentativeType>? representativeTypes = null;

            try { representativeTypes = db.RepresentativeTypes.ToList(); }
            catch { }

            return representativeTypes;
        }
        public static List<ShipmentPlan>? ShipmentPlans() // Получить список планов отгрузки
        {
            using ParsethingContext db = new();
            List<ShipmentPlan>? shipmentPlans = null;

            try { shipmentPlans = db.ShipmentPlans.ToList(); }
            catch { }

            return shipmentPlans;
        }
        public static List<ExecutionState>? ExecutionStates() // Получить список статусов БГ
        {
            using ParsethingContext db = new();
            List<ExecutionState>? executionStates = null;

            try { executionStates = db.ExecutionStates.ToList(); }
            catch { }

            return executionStates;
        }
        public static List<WarrantyState>? WarrantyStates() // Получить список статусов БГ гарантии
        {
            using ParsethingContext db = new();
            List<WarrantyState>? warrantyStates = null;

            try { warrantyStates = db.WarrantyStates.ToList(); }
            catch { }

            return warrantyStates;
        }
        public static List<SignedOriginal>? SignedOriginals() // Получить список подписанных оригиналов
        {
            using ParsethingContext db = new();
            List<SignedOriginal>? signedOriginals = null;

            try { signedOriginals = db.SignedOriginals.ToList(); }
            catch { }

            return signedOriginals;
        }
        public static List<CommisioningWork>? CommissioningWorks() // Получить список пусконаладочных работ
        {
            using ParsethingContext db = new();
            List<CommisioningWork>? commissioningWorks = null;

            try { commissioningWorks = db.CommisioningWorks.ToList(); }
            catch { }

            return commissioningWorks;
        }

        public static List<Procurement>? ProcurementSources() // Получить список полученных парсингом тендеров
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

        public static List<ComponentCalculation>? ComponentCalculationsBy(string kind) // Получить список комплектующих по их статусу 
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
                    .Include(cc => cc.Procurement.ShipmentPlan)
                    .Include(cc => cc.Manufacturer)
                    .Include(cc => cc.ComponentType)
                    .Include(cc => cc.Seller)
                    .Where(cc => cc.ComponentState.Kind == kind)
                    .ToList();
            }
            catch { }

            return componentCalculations;
        }

        public static List<ComponentCalculation>? ComponentCalculationsBy(string kind, int employeeId) //  Получить список комплектующих по их статусу и id сотрудника
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
                    .Where(cc => cc.Procurement.EmployeeId == employeeId)
                    .Where(cc => cc.ComponentState.Kind == kind)
                    .ToList();
            }
            catch { }

            return componentCalculations;
        }



        public static List<ComponentCalculation>? ComponentCalculationsBy(int procurementId) // Получить список комплектующих по конкретному тендеру
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

        public static List<SupplyMonitoringList> GetSupplyMonitoringLists(List<Procurement> procurements, List<string> componentStatuses) // Получить комплектующие по статусам и тендерам
        {
            using (var dbContext = new ParsethingContext())
            {
                var tenderIds = procurements.Select(p => p.Id).ToList();

                var query = from cc in dbContext.ComponentCalculations
                            join s in dbContext.Sellers on cc.SellerId equals s.Id
                            join m in dbContext.Manufacturers on cc.ManufacturerId equals m.Id
                            join cs in dbContext.ComponentStates on cc.ComponentStateId equals cs.Id
                            where tenderIds.Contains(cc.ProcurementId)
                            group new { cc, s, m, cs } by new { s.Name, m.ManufacturerName, cc.ComponentName, cs.Kind, cc.ProcurementId } into g
                            select new SupplyMonitoringList
                            {
                                SupplierName = g.Key.Name,
                                ManufacturerName = g.Key.ManufacturerName,
                                ComponentName = g.Key.ComponentName,
                                ComponentStatus = g.Key.Kind,
                                AveragePrice = g.Average(x => x.cc.PricePurchase),
                                TotalCount = g.Sum(x => x.cc.Count),
                                SellerName = g.Key.Name,
                                TenderNumber = g.Key.ProcurementId,
                                TotalAmount = g.Sum(x => x.cc.PricePurchase * x.cc.Count)
                            };

                if (componentStatuses != null && componentStatuses.Any())
                {
                    query = query.Where(x => componentStatuses.Contains(x.ComponentStatus));
                }

                return query.ToList();
            }
        }

        public static List<Method>? Methods() // Получить все методы определения поставщика
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

        public static List<Procurement>? ProcurementsBy(string kind, KindOf kindOf) // Получить список тендеров по: 
        {
            using ParsethingContext db = new();
            List<Procurement>? procurements = null;

            try
            {
                switch (kindOf)
                {
                    case KindOf.ProcurementState: // Статусу
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
                    case KindOf.ShipmentPlane: // Плану отгрузки
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
                    case KindOf.Applications: // Выигранным по заявкам
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

        public static List<Procurement>? ProcurementsBy(string procurementStateKind, bool isOverdue, KindOf kindOf) // Получить список тендеров:
        {
            using ParsethingContext db = new();
            List<Procurement>? procurements = null;

            try
            {
                switch (kindOf)
                {
                    case KindOf.Deadline: // Дата окончания подачи заявок
                        if (isOverdue) // Просроченных по статусу 
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
                        else // Непросроченных по статусу 
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
                    case KindOf.StartDate: // Дата начала подачи заявок
                        if (isOverdue) // Просроченных по статусу 
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
                        else // Непросроченных по статусу
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
                    case KindOf.ContractConclusion: // По дате заключения контракта
                        if (isOverdue) // Просроченных по статусу
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
                            .Where(p => p.ProcurementState.Kind == "Выигран 1ч" || p.ProcurementState.Kind == "Выигран 2ч")
                            .Where(p => p.ConclusionDate != null)
                            .ToList();
                        }
                        else // Непросроченных по статусу 
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
                            .Where(p => p.ProcurementState.Kind == "Выигран 1ч" || p.ProcurementState.Kind == "Выигран 2ч")
                            .Where(p => p.ConclusionDate == null)
                            .ToList();
                        }
                        break;
                }

            }
            catch { }

            return procurements;
        }

        public static List<Procurement>? ProcurementsBy(bool isOverdue) // Получить список неоплаченых тендеров
        {
            using ParsethingContext db = new();
            List<Procurement>? procurements = null;

            try
            {
                if (isOverdue) // Просроченная оплата
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
                else // В срок
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
        public static List<Procurement>? ProcurementsNotPaid() // Получить список неоплаченных тендеров
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

        public static List<Procurement>? ProcurementsBy(KindOf kindOf) // Получить список тендеров: 
        {
            using ParsethingContext db = new();
            List<Procurement>? procurements = null;

            try
            {
                switch (kindOf)
                {
                    case KindOf.Judgement: // В суде
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
                    case KindOf.FAS: // В ФАС
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

        public static List<Procurement>? ProcurementsBy(int searchId, string searchNumber, string searchLaw, string searchProcurementState, string searchInn) // Запрос для поиска
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

        public static List<ProcurementsEmployeesGrouping>? ProcurementsGroupByMethod() // Получить список отправленных тендеров групированных по методам проведения
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

        public static List<Comment>? CommentsBy (int procurementId) // Получить комментарии по id тендера
        {
            using ParsethingContext db = new();
            var comments = db.Comments
                .Include(c => c.Employee)
                .Where(pe => pe.EntryId == procurementId)
                .Where(c => c.EntityType == "Procurement")
                .ToList();

            return comments;
        }

        public static List<Comment>? CommentsBy(int procurementId, bool isTechical) // Получить технические комментарии по id тендера
        {
            using ParsethingContext db = new();
            var comments = db.Comments
                .Include(c => c.Employee)
                .Where(pe => pe.EntryId == procurementId)
                .Where(pe => pe.IsTechnical == true)
                .Where(c => c.EntityType == "Procurement")
                .ToList();

            return comments;
        }

        public static List<ProcurementsEmployeesGrouping>? ProcurementsEmployeesGroupBy(int employeeId) // Получить информацию по тому, сколько тендеров назначено на конкретного сотрудника
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

        public static List<ProcurementsEmployeesGrouping>? ProcurementsEmployeesGroupBy(string premierPosition, string secondPosition, string thirdPosition, string premierProcurementState, string secondProcurementState, string thirdProcurementState) // Получить список сотруников и тендеров, которые у них в работе (по трем должностям и трем статусам) 
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

        public static List<ProcurementsEmployeesGrouping>? ProcurementsEmployeesGroupBy(string premierPosition, string secondPosition, string thirdPosition) // Получить список сотруников и тендеров, которые у них в работе (по трем должностям) 
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

        //public static List<ProcurementsEmployee>? ProcurementsEmployeesQueue() // Очередь расчета
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
        //            .Where(pe => pe.Procurement.ProcurementState.Kind == "Новый")
        //            .Where(pe => pe.Employee.Position.Kind != "Специалист отдела расчетов")
        //            .ToList();
        //    }
        //    catch { }

        //    return procurements;
        //}

        public static List<ProcurementsEmployee>? ProcurementsEmployeesBy(int employeeId, string procurementStateKind) // Получить список тендеров и сотудиков, по статусу и id сотрудника
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
        public static ProcurementsEmployee? ProcurementsEmployeesBy(Procurement procurement, string premierPosition, string secondPosition, string thirdPosition) // Получить список тендеров и сотрудников, по id тендера и трем должностям
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
        public static List<ProcurementsEmployee>? ProcurementsEmployeesBy(int employeeId) // Получть список тендеров и сотрудников по id сотрудника
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
        //
        public static List<ProcurementsEmployee>? ProcurementsEmployeesBy(string kind, KindOf kindOf, int employeeId) // Получить список тендеров и закупок по:
        {
            using ParsethingContext db = new();
            List<ProcurementsEmployee>? procurementsEmployees = null;

            try
            {
                switch (kindOf)
                {
                    case KindOf.ProcurementState: // Статусу тендера и id сотрудника
                        procurementsEmployees = db.ProcurementsEmployees
                            .Include(pe => pe.Employee)
                            .Include(pe => pe.Procurement)
                            .Include(pe => pe.Procurement.ProcurementState)
                            .Include(pe => pe.Procurement.Law)
                            .Include(pe => pe.Procurement.Method)
                            .Include(pe => pe.Procurement.Platform)
                            .Include(pe => pe.Procurement.TimeZone)
                            .Include(pe => pe.Procurement.Region)
                            .Include(pe => pe.Procurement.ShipmentPlan)
                            .Include(pe => pe.Procurement.Organization)
                            .Where(pe => pe.Employee.Id == employeeId)
                            .Where(pe => pe.Procurement.ProcurementState != null && pe.Procurement.ProcurementState.Kind == kind)
                            .ToList();
                        break;
                    case KindOf.ShipmentPlane: // Плану отгрузки, конкретным статусам и id сотруника
                        procurementsEmployees = db.ProcurementsEmployees
                            .Include(pe => pe.Employee)
                            .Include(pe => pe.Procurement)
                            .Include(pe => pe.Procurement.ShipmentPlan)
                            .Include(pe => pe.Procurement.Law)
                            .Include(pe => pe.Procurement.Method)
                            .Include(pe => pe.Procurement.Platform)
                            .Include(pe => pe.Procurement.TimeZone)
                            .Include(pe => pe.Procurement.Region)
                            .Include(pe => pe.Procurement.Organization)
                            .Include(pe => pe.Procurement.ProcurementState)
                            .Where(pe => pe.Employee.Id == employeeId)
                            .Where(pe => pe.Procurement.ShipmentPlan != null && pe.Procurement.ShipmentPlan.Kind == kind)
                            .Where(pe => pe.Procurement.ProcurementState.Kind == "Выигран 1ч" || pe.Procurement.ProcurementState.Kind == "Выигран 2ч" || pe.Procurement.ProcurementState.Kind == "Приемка")
                            .ToList();
                        break;
                    case KindOf.Applications: // Положительному наличию статуса "по заявкам" и id сотрудника
                        procurementsEmployees = db.ProcurementsEmployees
                            .Include(pe => pe.Employee)
                            .Include(pe => pe.Procurement)
                            .Include(pe => pe.Procurement.ProcurementState)
                            .Include(pe => pe.Procurement.Law)
                            .Include(pe => pe.Procurement.Method)
                            .Include(pe => pe.Procurement.Platform)
                            .Include(pe => pe.Procurement.Organization)
                            .Include(pe => pe.Procurement.TimeZone)
                            .Include(pe => pe.Procurement.Region)
                            .Include(pe => pe.Procurement.ShipmentPlan)
                            .Where(pe => pe.Employee.Id == employeeId)
                            .Where(pe => pe.Procurement.Applications == true)
                            .ToList();
                        break;
                    case KindOf.ExecutionState: // Статусу обеспечения заявки, конкретным статусам тендера и id сотрудника
                        procurementsEmployees = db.ProcurementsEmployees
                            .Include(pe => pe.Employee)
                            .Include(pe => pe.Procurement)
                            .Include(pe => pe.Procurement.ProcurementState)
                            .Include(pe => pe.Procurement.Law)
                            .Include(pe => pe.Procurement.Method)
                            .Include(pe => pe.Procurement.Platform)
                            .Include(pe => pe.Procurement.Organization)
                            .Include(pe => pe.Procurement.TimeZone)
                            .Include(pe => pe.Procurement.Region)
                            .Include(pe => pe.Procurement.ShipmentPlan)
                            .Include(pe => pe.Procurement.ExecutionState)
                            .Where(pe => pe.Employee.Id == employeeId)
                            .Where(pe => pe.Procurement.ProcurementState.Kind == "Выигран 1ч" || pe.Procurement.ProcurementState.Kind == "Выигран 2ч" || pe.Procurement.ProcurementState.Kind == "Приемка")
                            .Where(pe => pe.Procurement.ExecutionState.Kind == "Запрошена БГ" || pe.Procurement.ExecutionState.Kind == "Согласована БГ" || pe.Procurement.ExecutionState.Kind == "Оформлена БГ" || pe.Procurement.ExecutionState.Kind == "Деньги(Возвратные)" || pe.Procurement.ExecutionState.Kind == "Добросовестность")
                            .ToList();
                        break;
                    case KindOf.WarrantyState: // Статусу обеспечения гарантии, конкретным статусам тендера и id сотрудника
                        procurementsEmployees = db.ProcurementsEmployees
                            .Include(pe => pe.Employee)
                            .Include(pe => pe.Procurement)
                            .Include(pe => pe.Procurement.ProcurementState)
                            .Include(pe => pe.Procurement.Law)
                            .Include(pe => pe.Procurement.Method)
                            .Include(pe => pe.Procurement.Platform)
                            .Include(pe => pe.Procurement.Organization)
                            .Include(pe => pe.Procurement.TimeZone)
                            .Include(pe => pe.Procurement.Region)
                            .Include(pe => pe.Procurement.ShipmentPlan)
                            .Include(pe => pe.Procurement.WarrantyState)
                            .Where(pe => pe.Employee.Id == employeeId)
                            .Where(pe => pe.Procurement.ProcurementState.Kind == "Выигран 1ч" || pe.Procurement.ProcurementState.Kind == "Выигран 2ч" || pe.Procurement.ProcurementState.Kind == "Приемка")
                            .Where(pe => pe.Procurement.WarrantyState.Kind == "Запрошена БГ" || pe.Procurement.WarrantyState.Kind == "Согласована БГ" || pe.Procurement.WarrantyState.Kind == "Оформлена БГ" || pe.Procurement.WarrantyState.Kind == "Деньги(Возвратные)" || pe.Procurement.WarrantyState.Kind == "Добросовестность")
                            .ToList();
                        break;
                }
            }
            catch { }

            return procurementsEmployees;
        }

        public static List<ProcurementsEmployee>? ProcurementsEmployeesBy(string procurementStateKind, bool isOverdue, KindOf kindOf, int employeeId) // Получить список тендеров и сотрудников по:
        {
            using ParsethingContext db = new();
            List<ProcurementsEmployee>? procurementsEmployees = null;

            try
            {
                switch (kindOf)
                {
                    case KindOf.Deadline: // Дате окончания подачи заявок, id сотрудника и статусу тендера
                        if (isOverdue) // Просроченные 
                        {
                            procurementsEmployees = db.ProcurementsEmployees
                                .Include(pe => pe.Employee)
                                .Include(pe => pe.Procurement)
                                .Include(pe => pe.Procurement.ProcurementState)
                                .Include(pe => pe.Procurement.Law)
                                .Include(pe => pe.Procurement.Method)
                                .Include(pe => pe.Procurement.Platform)
                                .Include(pe => pe.Procurement.Organization)
                                .Include(pe => pe.Procurement.TimeZone)
                                .Include(pe => pe.Procurement.Region)
                                .Include(pe => pe.Procurement.ShipmentPlan)
                                .Where(pe => pe.Employee.Id == employeeId)
                                .Where(pe => pe.Procurement.ProcurementState.Kind == procurementStateKind)
                                .Where(pe => pe.Procurement.Deadline < DateTime.Now)
                                .ToList();
                        }
                        else // Непросроченные 
                        {
                            procurementsEmployees = db.ProcurementsEmployees
                                .Include(pe => pe.Employee)
                                .Include(pe => pe.Procurement)
                                .Include(pe => pe.Procurement.ProcurementState)
                                .Include(pe => pe.Procurement.Law)
                                .Include(pe => pe.Procurement.Method)
                                .Include(pe => pe.Procurement.Platform)
                                .Include(pe => pe.Procurement.Organization)
                                .Include(pe => pe.Procurement.TimeZone)
                                .Include(pe => pe.Procurement.Region)
                                .Include(pe => pe.Procurement.ShipmentPlan)
                                .Where(pe => pe.Employee.Id == employeeId)
                                .Where(pe => pe.Procurement.ProcurementState.Kind == procurementStateKind)
                                .Where(pe => pe.Procurement.Deadline > DateTime.Now)
                                .ToList();
                        }
                        break;
                    case KindOf.StartDate: // Дате начала подачи заявок, id сотрудника и статусу тендера
                        if (isOverdue) // Просроченные
                        {
                            procurementsEmployees = db.ProcurementsEmployees
                                .Include(pe => pe.Employee)
                                .Include(pe => pe.Procurement)
                                .Include(pe => pe.Procurement.ProcurementState)
                                .Include(pe => pe.Procurement.Law)
                                .Include(pe => pe.Procurement.Method)
                                .Include(pe => pe.Procurement.Platform)
                                .Include(pe => pe.Procurement.Organization)
                                .Include(pe => pe.Procurement.TimeZone)
                                .Include(pe => pe.Procurement.Region)
                                .Include(pe => pe.Procurement.ShipmentPlan)
                                .Where(pe => pe.Employee.Id == employeeId)
                                .Where(pe => pe.Procurement.ProcurementState.Kind == procurementStateKind)
                                .Where(pe => pe.Procurement.StartDate < DateTime.Now)
                                .ToList();
                        }
                        else // Непросроченные
                        {
                            procurementsEmployees = db.ProcurementsEmployees
                                .Include(pe => pe.Employee)
                                .Include(pe => pe.Procurement)
                                .Include(pe => pe.Procurement.ProcurementState)
                                .Include(pe => pe.Procurement.Law)
                                .Include(pe => pe.Procurement.Method)
                                .Include(pe => pe.Procurement.Platform)
                                .Include(pe => pe.Procurement.Organization)
                                .Include(pe => pe.Procurement.TimeZone)
                                .Include(pe => pe.Procurement.Region)
                                .Include(pe => pe.Procurement.ShipmentPlan)
                                .Where(pe => pe.Employee.Id == employeeId)
                                .Where(pe => pe.Procurement.ProcurementState.Kind == procurementStateKind)
                                .Where(pe => pe.Procurement.StartDate > DateTime.Now)
                                .ToList();
                        }
                        break;
                    case KindOf.ContractConclusion: // Дате подписания контракта, id сотрудника и конкретным статусам
                        if (isOverdue) // Просроченные
                        {
                            procurementsEmployees = db.ProcurementsEmployees
                                .Include(pe => pe.Employee)
                                .Include(pe => pe.Procurement)
                                .Include(pe => pe.Procurement.ProcurementState)
                                .Include(pe => pe.Procurement.Law)
                                .Include(pe => pe.Procurement.Method)
                                .Include(pe => pe.Procurement.Platform)
                                .Include(pe => pe.Procurement.Organization)
                                .Include(pe => pe.Procurement.TimeZone)
                                .Include(pe => pe.Procurement.Region)
                                .Include(pe => pe.Procurement.ShipmentPlan)
                                .Where(pe => pe.Employee.Id == employeeId)
                                .Where(pe => pe.Procurement.ProcurementState.Kind == "Выигран 1ч" || pe.Procurement.ProcurementState.Kind == "Выигран 2ч")
                                .Where(pe => pe.Procurement.ConclusionDate != null)
                                .ToList();
                        }
                        else // Непросроченные
                        {
                            procurementsEmployees = db.ProcurementsEmployees
                                .Include(pe => pe.Employee)
                                .Include(pe => pe.Procurement)
                                .Include(pe => pe.Procurement.ProcurementState)
                                .Include(pe => pe.Procurement.Law)
                                .Include(pe => pe.Procurement.Method)
                                .Include(pe => pe.Procurement.Platform)
                                .Include(pe => pe.Procurement.Organization)
                                .Include(pe => pe.Procurement.TimeZone)
                                .Include(pe => pe.Procurement.Region)
                                .Include(pe => pe.Procurement.ShipmentPlan)
                                .Where(pe => pe.Employee.Id == employeeId)
                                .Where(pe => pe.Procurement.ProcurementState.Kind == "Выигран 1ч" || pe.Procurement.ProcurementState.Kind == "Выигран 2ч")
                                .Where(pe => pe.Procurement.ConclusionDate == null)
                                .ToList();
                        }
                        break;
                }
            }
            catch { }

            return procurementsEmployees;
        }

        public static List<ProcurementsEmployee>? ProcurementsEmployeesBy(bool isOverdue, int employeeId) // Получить тендеры, назначнные на конкретного сотрудника
        {
            using ParsethingContext db = new();
            List<ProcurementsEmployee>? procurementsEmployees = null;

            try
            {
                if (isOverdue) // Просроченные
                {
                    procurementsEmployees = db.ProcurementsEmployees
                        .Include(pe => pe.Employee)
                        .Include(pe => pe.Procurement)
                        .Include(pe => pe.Procurement.ProcurementState)
                        .Include(pe => pe.Procurement.Law)
                        .Include(pe => pe.Procurement.Method)
                        .Include(pe => pe.Procurement.Platform)
                        .Include(pe => pe.Procurement.Organization)
                        .Include(pe => pe.Procurement.TimeZone)
                        .Include(pe => pe.Procurement.Region)
                        .Include(pe => pe.Procurement.ShipmentPlan)
                        .Where(pe => pe.Employee.Id == employeeId)
                        .Where(pe => pe.Procurement.ProcurementState.Kind == "Принят")
                        .Where(pe => pe.Procurement.MaxDueDate < DateTime.Now)
                        .Where(pe => pe.Procurement.RealDueDate == null)
                        .ToList();
                }
                else // Просроченные
                {
                    procurementsEmployees = db.ProcurementsEmployees
                        .Include(pe => pe.Employee)
                        .Include(pe => pe.Procurement)
                        .Include(pe => pe.Procurement.ProcurementState)
                        .Include(pe => pe.Procurement.Law)
                        .Include(pe => pe.Procurement.Method)
                        .Include(pe => pe.Procurement.Platform)
                        .Include(pe => pe.Procurement.Organization)
                        .Include(pe => pe.Procurement.TimeZone)
                        .Include(pe => pe.Procurement.Region)
                        .Include(pe => pe.Procurement.ShipmentPlan)
                        .Where(pe => pe.Employee.Id == employeeId)
                        .Where(pe => pe.Procurement.ProcurementState.Kind == "Принят")
                        .Where(pe => pe.Procurement.MaxDueDate > DateTime.Now)
                        .Where(pe => pe.Procurement.RealDueDate == null)
                        .ToList();
                }
            }
            catch { }

            return procurementsEmployees;
        }
        public static List<ProcurementsEmployee>? ProcurementsEmployeesNotPaid(int employeeId) // Получить неоплаченные тендеры по конкретному сотруднику
        {
            using ParsethingContext db = new();
            List<ProcurementsEmployee>? procurementsEmployees = null;

            try
            {
                procurementsEmployees = db.ProcurementsEmployees
                    .Include(pe => pe.Employee)
                    .Include(pe => pe.Procurement)
                    .Include(pe => pe.Procurement.ProcurementState)
                    .Include(pe => pe.Procurement.Law)
                    .Include(pe => pe.Procurement.Method)
                    .Include(pe => pe.Procurement.Platform)
                    .Include(pe => pe.Procurement.Organization)
                    .Include(pe => pe.Procurement.TimeZone)
                    .Include(pe => pe.Procurement.Region)
                    .Include(pe => pe.Procurement.ShipmentPlan)
                    .Where(pe => pe.Employee.Id == employeeId)
                    .Where(pe => pe.Procurement.ProcurementState.Kind == "Принят")
                    .Where(pe => pe.Procurement.RealDueDate == null)
                    .Where(pe => pe.Procurement.MaxDueDate != null)
                    .ToList();
            }
            catch { }

            return procurementsEmployees;
        }

        public static List<ProcurementsEmployee>? ProcurementsEmployeesBy(KindOf kindOf, int employeeId) // Получить тендеры, назначенные на конкретного сотрудника
        {
            using ParsethingContext db = new();
            List<ProcurementsEmployee>? procurementsEmployees = null;

            try
            {
                switch (kindOf)
                {
                    case KindOf.Judgement: // Суд
                        procurementsEmployees = db.ProcurementsEmployees
                            .Include(pe => pe.Employee)
                            .Include(pe => pe.Procurement)
                            .Include(pe => pe.Procurement.ProcurementState)
                            .Include(pe => pe.Procurement.Law)
                            .Include(pe => pe.Procurement.Method)
                            .Include(pe => pe.Procurement.Platform)
                            .Include(pe => pe.Procurement.Organization)
                            .Include(pe => pe.Procurement.TimeZone)
                            .Include(pe => pe.Procurement.Region)
                            .Include(pe => pe.Procurement.ShipmentPlan)
                            .Where(pe => pe.Employee.Id == employeeId)
                            .Where(pe => pe.Procurement.Judgment == true)
                            .ToList();
                        break;
                    case KindOf.FAS: // ФАС
                        procurementsEmployees = db.ProcurementsEmployees
                            .Include(pe => pe.Employee)
                            .Include(pe => pe.Procurement)
                            .Include(pe => pe.Procurement.ProcurementState)
                            .Include(pe => pe.Procurement.Law)
                            .Include(pe => pe.Procurement.Method)
                            .Include(pe => pe.Procurement.Platform)
                            .Include(pe => pe.Procurement.Organization)
                            .Include(pe => pe.Procurement.TimeZone)
                            .Include(pe => pe.Procurement.Region)
                            .Include(pe => pe.Procurement.ShipmentPlan)
                            .Where(pe => pe.Employee.Id == employeeId)
                            .Where(pe => pe.Procurement.Fas == true)
                            .ToList();
                        break;
                }
            }
            catch { }

            return procurementsEmployees;
        }
        public static List<ProcurementsPreference>? ProcurementsPreferencesBy(int procurementId) // Получить преференции по конкретному тендеру
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

        public static List<ProcurementsDocument>? ProcurementsDocumentsBy(int procurementId) // Получить документы по конкретному тендеру
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

        public static List<ProcurementState>? DistributionOfProcurementStates(string employeePosition) // Получить статусы к которым имеют доступ конкретные должности
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
                            .Where(ps => ps.Kind == "Новый" || ps.Kind == "Посчитан" || ps.Kind == "Оформить" || ps.Kind == "Оформлен" || ps.Kind == "Выигран 1ч" || ps.Kind == "Выигран 2ч" || ps.Kind == "Разбор" || ps.Kind == "Отбой" || ps.Kind == "Неразобранный")
                            .ToList();
                        break;
                    case "Заместитель руководителя отдела расчетов":
                        procurementStates = db.ProcurementStates
                            .Where(ps => ps.Kind == "Новый" || ps.Kind == "Посчитан" || ps.Kind == "Оформить" || ps.Kind == "Оформлен" || ps.Kind == "Выигран 1ч" || ps.Kind == "Выигран 2ч" || ps.Kind == "Разбор" || ps.Kind == "Отбой" || ps.Kind == "Неразобранный")
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

        public static List<ProcurementState>? ProcurementStates() // Получить список статусов тендеров
        {
            using ParsethingContext db = new();
            List<ProcurementState>? procurementStates = null;

            try { procurementStates = db.ProcurementStates.ToList(); }
            catch { }

            return procurementStates;
        }

        public static List<Region>? Regions() // Получить список регионов
        {
            using ParsethingContext db = new();
            List<Region>? regions = null;

            try { regions = db.Regions.ToList(); }
            catch { }

            return regions;
        }

        public static List<Seller>? Sellers() // Получить список дистрибьюторов 
        {
            using ParsethingContext db = new();
            List<Seller>? sellers = null;

            try { sellers = db.Sellers.ToList(); }
            catch { }

            return sellers;
        }

        public static List<Tag>? Tags() // Получить тэги для парсинга 
        {
            using ParsethingContext db = new();
            List<Tag>? tags = null;

            try { tags = db.Tags.ToList(); }
            catch { }

            return tags;
        }

        public static List<TagException>? TagExceptions() // Получить тэги для парсинга 
        {
            using ParsethingContext db = new();
            List<TagException>? tagExceptions = null;

            try { tagExceptions = db.TagExceptions.ToList(); }
            catch { }

            return tagExceptions;
        }

        public static List<Tuple<int,int,int>>? HistoryGroupByWins() // Получить выигранные тендеры по месяцам
        {
            using ParsethingContext db = new();
            List<History>? histories = null;

            try { histories = db.Histories.ToList(); }
            catch { }

            var uniqueWiningTenders = histories
                .Where(h => h.Text == "Выигран 1ч")
                .GroupBy(tender => new { Year = tender.Date.Year, Month = tender.Date.Month, tender.Id })
                .Select(group => group.First())
                .DistinctBy(h => h.EntryId)
                .ToList();

            var winningTendersByMonth = uniqueWiningTenders
                .GroupBy(tender => new { Year = tender.Date.Year, Month = tender.Date.Month })
                .Select(group => Tuple.Create(group.Key.Year, group.Key.Month, group.Count()))
                .OrderBy(entry => entry.Item1)
                .ThenBy(entry => entry.Item2)
                .ToList();

            return winningTendersByMonth;
        }
        public static List<Tuple<int, int, int>>? HistoryGroupBySended() // Получить отправленные тендеры по месяцам
        {
            using ParsethingContext db = new();
            List<History>? histories = null;

            try { histories = db.Histories.ToList(); }
            catch { }

            var uniqueWiningTenders = histories
                .Where(h => h.Text == "Отправлен")
                .GroupBy(tender => new { Year = tender.Date.Year, Month = tender.Date.Month, tender.Id })
                .Select(group => group.First())
                .DistinctBy(h => h.EntryId)
                .ToList();

            var winningTendersByMonth = uniqueWiningTenders
                .GroupBy(tender => new { Year = tender.Date.Year, Month = tender.Date.Month })
                .Select(group => Tuple.Create(group.Key.Year, group.Key.Month, group.Count()))
                .OrderBy(entry => entry.Item1)
                .ThenBy(entry => entry.Item2)
                .ToList();

            return winningTendersByMonth;
        }
        public static List<Tuple<int, int, int>>? HistoryGroupByCalculations() // Получить посчитанные тендеры по месяцам
        {
            using ParsethingContext db = new();
            List<History>? histories = null;

            try { histories = db.Histories.ToList(); }
            catch { }

            var uniqueWiningTenders = histories
                .Where(h => h.Text == "Посчитан")
                .GroupBy(tender => new { Year = tender.Date.Year, Month = tender.Date.Month, tender.Id })
                .Select(group => group.First())
                .DistinctBy(h => h.EntryId)
                .ToList();

            var winningTendersByMonth = uniqueWiningTenders
                .GroupBy(tender => new { Year = tender.Date.Year, Month = tender.Date.Month })
                .Select(group => Tuple.Create(group.Key.Year, group.Key.Month, group.Count()))
                .OrderBy(entry => entry.Item1)
                .ThenBy(entry => entry.Item2)
                .ToList();

            return winningTendersByMonth;
        }

    }

    public struct Aggregate
    {
        public static int ProcurementsCountBy(string kind, KindOf kindOf) // Получить количество тендеров по:
        {
            using ParsethingContext db = new();
            int count = 0;

            try
            {
                switch (kindOf)
                {
                    case KindOf.ProcurementState: // Конкретному статусу
                        count = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Where(p => p.ProcurementState != null && p.ProcurementState.Kind == kind)
                            .Count();
                        break;
                    case KindOf.ShipmentPlane: // Плану отгрузки и конуретным статусам
                        count = db.Procurements
                            .Include(e => e.ShipmentPlan)
                            .Where(p => p.ShipmentPlan != null && p.ShipmentPlan.Kind == kind)
                            .Where(p => p.ProcurementState.Kind == "Выигран 1ч" || p.ProcurementState.Kind == "Выигран 2ч" || p.ProcurementState.Kind == "Приемка")
                            .Count();
                        break;
                    case KindOf.Applications: // Положительному статусу "По заявкам"
                        count = db.Procurements
                            .Where(p => p.Applications == true)
                            .Count();
                        break;
                }
            }
            catch { }

            return count;
        }
        public static int ProcurementsCountBy(bool isOverdue) // Получить количество неоплаченных тендеров
        {
            using ParsethingContext db = new();
            int count = 0;

            try
            {
                if (isOverdue) // Просроченных по дате оплаты
                {
                    count = db.Procurements
                    .Include(p => p.ProcurementState)
                    .Where(p => p.ProcurementState.Kind == "Принят")
                    .Where(p => p.MaxDueDate < DateTime.Now)
                    .Where(p => p.RealDueDate == null)
                    .Count();
                }
                else // Непросроченных по дате оплаты
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
        public static int ProcurementsCountBy(KindOf kindOf) // Получить количество тендеров по:
        {
            using ParsethingContext db = new();
            int count = 0;

            try
            {
                switch (kindOf)
                {
                    case KindOf.Judgement: // Суд
                        count = db.Procurements
                            .Where(p => p.Judgment == true)
                            .Count();
                        break;
                    case KindOf.FAS: // ФАС
                        count = db.Procurements
                            .Where(p => p.Fas == true)
                            .Count();
                        break;
                }
            }
            catch { }

            return count;
        }

        public static int ProcurementsCountBy(string procurementStateKind, bool isOverdue, KindOf kindOf) // Получить количество тендеров по:
        {
            using ParsethingContext db = new();
            int count = 0;

            try
            {
                switch (kindOf)
                {
                    case KindOf.Deadline: // Дате окончания подачи заявок
                        if (isOverdue) // Просроченные
                        {
                            count = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Where(p => p.ProcurementState.Kind == procurementStateKind)
                            .Where(p => p.Deadline < DateTime.Now)
                            .Count();
                        }
                        else // Непросроченные
                        {
                            count = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Where(p => p.ProcurementState.Kind == procurementStateKind)
                            .Where(p => p.Deadline > DateTime.Now)
                            .Count();
                        }
                        break;
                    case KindOf.StartDate: // Дате начала подачи заявок
                        if (isOverdue) // Просроченные
                        {
                            count = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Where(p => p.ProcurementState.Kind == procurementStateKind)
                            .Where(p => p.StartDate < DateTime.Now)
                            .Count();
                        }
                        else // Непросроченные
                        {
                            count = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Where(p => p.ProcurementState.Kind == procurementStateKind)
                            .Where(p => p.StartDate > DateTime.Now)
                            .Count();
                        }
                        break;
                    case KindOf.ContractConclusion: // Дате подписания контракта
                        if (isOverdue) // Просроченные
                        {
                            count = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Where(p => p.ProcurementState.Kind == "Выигран 1ч" || p.ProcurementState.Kind == "Выигран 2ч")
                            .Where(p => p.ConclusionDate != null)
                            .Count();
                        }
                        else // Непросроченные
                        {
                            count = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Where(p => p.ProcurementState.Kind == "Выигран 1ч" || p.ProcurementState.Kind == "Выигран 2ч")
                            .Where(p => p.ConclusionDate == null)
                            .Count();
                        }
                        break;
                }
                
            }
            catch { }

            return count;
        }

        public static int ProcurementsEmployeesCountBy(string kind, KindOf kindOf, int employeeId) // Получить количество тендеров по:
        {
            using ParsethingContext db = new();
            int count = 0;

            try
            {
                switch (kindOf)
                {
                    case KindOf.ProcurementState: // Статусу и конкретному сотруднику
                        count = db.ProcurementsEmployees
                            .Include(pe => pe.Employee)
                            .Include(pe => pe.Procurement)
                            .Include(pe => pe.Procurement.ProcurementState)
                            .Where(pe => pe.Employee.Id == employeeId)
                            .Where(pe => pe.Procurement.ProcurementState != null && pe.Procurement.ProcurementState.Kind == kind)
                            .Count();
                        break;
                    case KindOf.ShipmentPlane: // Плану отгрузки и конкретному сотруднику
                        count = db.ProcurementsEmployees
                            .Include(pe => pe.Employee)
                            .Include(pe => pe.Procurement)
                            .Include(pe => pe.Procurement.ShipmentPlan)
                            .Include(pe => pe.Procurement.ProcurementState)
                            .Where(pe => pe.Employee.Id == employeeId)
                            .Where(pe => pe.Procurement.ShipmentPlan != null && pe.Procurement.ShipmentPlan.Kind == kind)
                            .Where(pe => pe.Procurement.ProcurementState.Kind == "Выигран 1ч" || pe.Procurement.ProcurementState.Kind == "Выигран 2ч" || pe.Procurement.ProcurementState.Kind == "Приемка")
                            .Count();
                        break;
                    case KindOf.Applications: // Положительному статусу "По заявкам" и конкретному сотруднику
                        count = db.ProcurementsEmployees
                            .Include(pe => pe.Employee)
                            .Include(pe => pe.Procurement)
                            .Where(pe => pe.Employee.Id == employeeId)
                            .Where(pe => pe.Procurement.Applications == true)
                            .Count();
                        break;
                    case KindOf.ExecutionState: // Статусу обеспечения заявки по конкретному сотруднику 
                        count = db.ProcurementsEmployees
                            .Include(pe => pe.Employee)
                            .Include(pe => pe.Procurement)
                            .Include(pe => pe.Procurement.ExecutionState)
                            .Include(pe => pe.Procurement.ProcurementState)
                            .Where(pe => pe.Employee.Id == employeeId)
                            .Where(pe => pe.Procurement.ProcurementState.Kind == "Выигран 1ч" || pe.Procurement.ProcurementState.Kind == "Выигран 2ч" || pe.Procurement.ProcurementState.Kind == "Приемка")
                            .Where(pe => pe.Procurement.ExecutionState.Kind == "Запрошена БГ" || pe.Procurement.ExecutionState.Kind == "Согласована БГ" || pe.Procurement.ExecutionState.Kind == "Оформлена БГ" || pe.Procurement.ExecutionState.Kind == "Деньги(Возвратные)" || pe.Procurement.ExecutionState.Kind == "Добросовестность")
                            .Count();
                        break;
                    case KindOf.WarrantyState: // Статусу обеспечения гарантии заявки по конкретному сотруднику
                        count = db.ProcurementsEmployees
                            .Include(pe => pe.Employee)
                            .Include(pe => pe.Procurement)
                            .Include(pe => pe.Procurement.WarrantyState)
                            .Include(pe => pe.Procurement.ProcurementState)
                            .Where(pe => pe.Employee.Id == employeeId)
                            .Where(pe => pe.Procurement.ProcurementState.Kind == "Выигран 1ч" || pe.Procurement.ProcurementState.Kind == "Выигран 2ч" || pe.Procurement.ProcurementState.Kind == "Приемка")
                            .Where(pe => pe.Procurement.WarrantyState.Kind == "Запрошена БГ" || pe.Procurement.WarrantyState.Kind == "Согласована БГ" || pe.Procurement.WarrantyState.Kind == "Оформлена БГ" || pe.Procurement.WarrantyState.Kind == "Деньги(Возвратные)" || pe.Procurement.WarrantyState.Kind == "Добросовестность")
                            .Count();
                        break;
                }
            }
            catch { }

            return count;
        }

        public static int ProcurementsEmployeesCountBy(string procurementStateKind, bool isOverdue, KindOf kindOf, int employeeId) // Получить количество тендеров по
        {
            using ParsethingContext db = new();
            int count = 0;

            try
            {
                switch (kindOf)
                {
                    case KindOf.Deadline: // Дате окончания подачи заявок
                        if (isOverdue) // Просроченные
                        {
                            count = db.ProcurementsEmployees
                                .Include(pe => pe.Employee)
                                .Include(pe => pe.Procurement)
                                .Include(pe => pe.Procurement.ProcurementState)
                                .Where(pe => pe.Employee.Id == employeeId)
                                .Where(pe => pe.Procurement.ProcurementState.Kind == procurementStateKind)
                                .Where(pe => pe.Procurement.Deadline < DateTime.Now)
                                .Count();
                        }
                        else // Непросроченные
                        {
                            count = db.ProcurementsEmployees
                                .Include(pe => pe.Employee)
                                .Include(pe => pe.Procurement)
                                .Include(pe => pe.Procurement.ProcurementState)
                                .Where(pe => pe.Employee.Id == employeeId)
                                .Where(pe => pe.Procurement.ProcurementState.Kind == procurementStateKind)
                                .Where(pe => pe.Procurement.Deadline > DateTime.Now)
                                .Count();
                        }
                        break;
                    case KindOf.StartDate: // Дате начала подачи заявок
                        if (isOverdue) // Просроченные 
                        {
                            count = db.ProcurementsEmployees
                                .Include(pe => pe.Employee)
                                .Include(pe => pe.Procurement)
                                .Include(pe => pe.Procurement.ProcurementState)
                                .Where(pe => pe.Employee.Id == employeeId)
                                .Where(pe => pe.Procurement.ProcurementState.Kind == procurementStateKind)
                                .Where(pe => pe.Procurement.StartDate < DateTime.Now)
                                .Count();
                        }
                        else // Непросроченные
                        {
                            count = db.ProcurementsEmployees
                                .Include(pe => pe.Employee)
                                .Include(pe => pe.Procurement)
                                .Include(pe => pe.Procurement.ProcurementState)
                                .Where(pe => pe.Employee.Id == employeeId)
                                .Where(pe => pe.Procurement.ProcurementState.Kind == procurementStateKind)
                                .Where(pe => pe.Procurement.StartDate > DateTime.Now)
                                .Count();
                        }
                        break;
                    case KindOf.ContractConclusion: // Дате подписания контракта
                        if (isOverdue) // Просроченные
                        {
                            count = db.ProcurementsEmployees
                                .Include(pe => pe.Employee)
                                .Include(pe => pe.Procurement)
                                .Include(pe => pe.Procurement.ProcurementState)
                                .Where(pe => pe.Employee.Id == employeeId)
                                .Where(pe => pe.Procurement.ProcurementState.Kind == "Выигран 1ч" || pe.Procurement.ProcurementState.Kind == "Выигран 2ч")
                                .Where(pe => pe.Procurement.ConclusionDate != null)
                                .Count();
                        }
                        else // Непросроченные
                        {
                            count = db.ProcurementsEmployees
                                .Include(pe => pe.Employee)
                                .Include(pe => pe.Procurement)
                                .Include(pe => pe.Procurement.ProcurementState)
                                .Where(pe => pe.Employee.Id == employeeId)
                                .Where(pe => pe.Procurement.ProcurementState.Kind == "Выигран 1ч" || pe.Procurement.ProcurementState.Kind == "Выигран 2ч")
                                .Where(pe => pe.Procurement.ConclusionDate == null)
                                .Count();
                        }
                        break;
                }
            }
            catch { }

            return count;
        }

        public static int ProcurementsEmployeesCountBy(bool isOverdue, int employeeId) // Получить количество тендеров и сотрудников по сотрудникам
        {
            using ParsethingContext db = new();
            int count = 0;

            try
            {
                if (isOverdue) // Просросроченных неоплаченных
                {
                    count = db.ProcurementsEmployees
                        .Include(pe => pe.Employee)
                        .Include(pe => pe.Procurement)
                        .Include(pe => pe.Procurement.ProcurementState)
                        .Where(pe => pe.Employee.Id == employeeId)
                        .Where(pe => pe.Procurement.ProcurementState.Kind == "Принят")
                        .Where(pe => pe.Procurement.MaxDueDate < DateTime.Now)
                        .Where(pe => pe.Procurement.RealDueDate == null)
                        .Count();
                }
                else // Непросроченных неоплаченных
                {
                    count = db.ProcurementsEmployees
                        .Include(pe => pe.Employee)
                        .Include(pe => pe.Procurement)
                        .Include(pe => pe.Procurement.ProcurementState)
                        .Where(pe => pe.Employee.Id == employeeId)
                        .Where(pe => pe.Procurement.ProcurementState.Kind == "Принят")
                        .Where(pe => pe.Procurement.MaxDueDate > DateTime.Now)
                        .Where(pe => pe.Procurement.RealDueDate == null)
                        .Count();
                }
            }
            catch { }

            return count;
        }
        public static int ProcurementsEmployeesCountNotPaid(int employeeId) // Получить количество неоплаченных принятых тендеров и сотрудников по конкретному сотруднику
        {
            using ParsethingContext db = new();
            int count = 0;

            try
            {
                count = db.ProcurementsEmployees
                    .Include(pe => pe.Employee)
                    .Include(pe => pe.Procurement)
                    .Include(pe => pe.Procurement.ProcurementState)
                    .Where(pe => pe.Employee.Id == employeeId)
                    .Where(pe => pe.Procurement.ProcurementState.Kind == "Принят")
                    .Where(pe => pe.Procurement.RealDueDate == null)
                    .Where(pe => pe.Procurement.MaxDueDate != null)
                    .Count();
            }
            catch { }

            return count;
        }

        public static int ProcurementsEmployeesCountBy(KindOf kindOf, int employeeId) // Получить количество тендеров по конкретному сотруднику 
        {
            using ParsethingContext db = new();
            int count = 0;

            try
            {
                switch (kindOf)
                {
                    case KindOf.Judgement: // Суд
                        count = db.ProcurementsEmployees
                            .Include(pe => pe.Employee)
                            .Include(pe => pe.Procurement)
                            .Where(pe => pe.Employee.Id == employeeId)
                            .Where(pe => pe.Procurement.Judgment == true)
                            .Count();
                        break;
                    case KindOf.FAS: // ФАС
                        count = db.ProcurementsEmployees
                            .Include(pe => pe.Employee)
                            .Include(pe => pe.Procurement)
                            .Where(pe => pe.Employee.Id == employeeId)
                            .Where(pe => pe.Procurement.Fas == true)
                            .Count();
                        break;
                }
            }
            catch { }

            return count;

        }

    }

    public class SupplyMonitoringList // Класс для формирования результатов запросов на получение списка сгруппированных комплектующих
    {
        public string? SupplierName { get; set; }
        public string? ManufacturerName { get; set; }
        public string? ComponentName { get; set; }
        public string? ComponentStatus { get; set; }
        public decimal? AveragePrice { get; set; }
        public int? TotalCount { get; set; }
        public string? SellerName { get; set; }
        public int? TenderNumber { get; set; }
        public decimal? TotalAmount { get; set; }
    }

    public class ProcurementsEmployeesGrouping // Класс для формирования результатов запросов на группировку
    {
        public string Id { get; set; }
        public int CountOfProcurements { get; set; }
    }

    public enum KindOf // Перечисление для типизации запросов
    {
        ProcurementState, // Статус тендера
        ShipmentPlane, // План отгрузки
        Applications, // Статус "По заявкам"
        StartDate, // Дата начала подачи заявок
        Deadline, // Дата окончания подачи заявок
        Judgement, // Суд
        FAS, // ФАС
        ContractConclusion, // Дата подписания контракта
        ExecutionState, // Статус обеспечения исполнения заявки
        WarrantyState // Статус обеспечения гарантии заявки
    }
    
}