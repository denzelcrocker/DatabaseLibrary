using DatabaseLibrary.Entities.ComponentCalculationProperties;
using DatabaseLibrary.Entities.EmployeeMuchToMany;
using static DatabaseLibrary.Entities.ProcurementProperties.Procurement;
using System.Collections.ObjectModel;

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
        public static List<Organization>? Organizations() // Получить все законы
        {
            using ParsethingContext db = new();
            List<Organization> organizations = null;
            try
            {
                organizations = db.Organizations
                    .ToList();
            }
            catch { }

            return organizations;
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
        public static Procurement? ProcurementBy(int id) // Получить тендер по Id
        {
            using ParsethingContext db = new();
            Procurement? procurement = null;

            try
            {
                procurement = db.Procurements
                    .Include(p => p.ProcurementState)
                            .Include(p => p.Law)
                            .Include(p => p.Method)
                            .Include(p => p.Platform)
                            .Include(p => p.TimeZone)
                            .Include(p => p.Region)
                            .Include(p => p.ShipmentPlan)
                            .Include(p => p.Organization)
                    .Where(p => p.Id == id)
                    .First();
            }
            catch { }

            return procurement;
        }
        public static List<Procurement> PopulateComponentStates(List<Procurement> procurements)
        {
            using ParsethingContext db = new();
            try
            {
                var procurementIds = procurements.Select(p => p.Id).ToList();
                var componentCalculations = db.ComponentCalculations
                    .Where(cc => procurementIds.Contains(cc.ProcurementId))
                    .Include(cc => cc.ComponentState)
                    .ToList();

                var groupedComponentCalculations = componentCalculations
                    .GroupBy(cc => cc.ProcurementId)
                    .ToDictionary(g => g.Key, g => g.ToList());

                foreach (var procurement in procurements)
                {
                    if (groupedComponentCalculations.ContainsKey(procurement.Id))
                    {
                        var calculations = groupedComponentCalculations[procurement.Id];
                        procurement.ComponentStates = new ObservableCollection<ComponentStateCount>(
                            calculations
                                .Where(cc => cc.ComponentState != null) // Добавляем проверку на null
                                .GroupBy(cc => cc.ComponentState?.Kind) // Используем безопасную навигацию для ComponentState
                                .Select(group => new ComponentStateCount
                                {
                                    State = group.Key ?? "Unknown", // Используем значение по умолчанию, если group.Key равен null
                                    Count = group.Count()
                                })
                        );
                    }
                    else
                    {
                        // Если компоненты отсутствуют, устанавливаем пустую коллекцию
                        procurement.ComponentStates = new ObservableCollection<ComponentStateCount>();
                    }
                }
            }
            catch { }

            return procurements;
        }
        public static List<ComponentHeaderType>? ComponentHeaderTypes() // Получить список заголовков расчета и закупки
        {
            using ParsethingContext db = new();
            List<ComponentHeaderType>? componentHeaderTypes = null;

            try { componentHeaderTypes = db.ComponentHeaderTypes.ToList(); }
            catch { }

            return componentHeaderTypes;
        }
        public static List<ComponentCalculation>? ComponentCalculationsBy(string kind) // Получить список комплектующих по их статусу 
        {
            using ParsethingContext db = new();
            List<ComponentCalculation> componentCalculations = null;

            try
            {
                componentCalculations = db.ComponentCalculations
                    .Include(cc => cc.ComponentState)
                    .Include(cc => cc.ComponentHeaderType)
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
                var procurementIds = db.ProcurementsEmployees
            .Where(pe => pe.EmployeeId == employeeId)
            .Select(pe => pe.ProcurementId)
            .ToList();

                componentCalculations = db.ComponentCalculations
                    .Include(cc => cc.ComponentState)
                    .Include(cc => cc.ComponentHeaderType)
                    .Include(cc => cc.Procurement)
                        .ThenInclude(p => p.Law)
                    .Include(cc => cc.Procurement)
                        .ThenInclude(p => p.ProcurementState)
                    .Include(cc => cc.Procurement)
                        .ThenInclude(p => p.Region)
                    .Include(cc => cc.Procurement)
                        .ThenInclude(p => p.Method)
                    .Include(cc => cc.Procurement)
                        .ThenInclude(p => p.Platform)
                    .Include(cc => cc.Procurement)
                        .ThenInclude(p => p.TimeZone)
                    .Include(cc => cc.Procurement)
                        .ThenInclude(p => p.Organization)
                    .Include(cc => cc.Manufacturer)
                    .Include(cc => cc.ComponentType)
                    .Include(cc => cc.Seller)
                    .Where(cc => cc.ComponentState.Kind == kind && procurementIds.Contains(cc.ProcurementId))
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
                    .Include(cc => cc.ComponentHeaderType)
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
        public static List<ComponentCalculation> ComponentCalculationsBy(List<int?> procurementIds, List<string> componentStatuses) // Получить список комплектующих по списку Id и статусов товара
        {
            {
                using ParsethingContext db = new();
                List<ComponentCalculation> componentCalculations = null;

                try
                {
                    componentCalculations = db.ComponentCalculations
                        .Include(cc => cc.ComponentState)
                        .Include(cc => cc.ComponentHeaderType)
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
                        .Where(cc => procurementIds.Contains(cc.ProcurementId) && componentStatuses.Contains(cc.ComponentState.Kind))
                        .ToList();
                }
                catch { }

                return componentCalculations;
            }
        }
        public static List<ComponentCalculation>? ComponentCalculationsBy(int procurementId, List<string> componentStatuses) // Получить список комплектующих по конкретному тендеру и определенным статусам
        {
            using ParsethingContext db = new();
            List<ComponentCalculation> componentCalculations = null;

            try
            {
                componentCalculations = db.ComponentCalculations
                    .Include(cc => cc.ComponentState)
                    .Include(cc => cc.ComponentHeaderType)
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

        public static List<SupplyMonitoringList> GetSupplyMonitoringLists(List<Procurement> procurements, List<string> componentStatuses)
        {
            using (var dbContext = new ParsethingContext())
            {
                var tenderIds = procurements.Select(p => p.Id).ToList();

                var query = from cc in dbContext.ComponentCalculations
                            join s in dbContext.Sellers on cc.SellerIdPurchase equals s.Id
                            join m in dbContext.Manufacturers on cc.ManufacturerIdPurchase equals m.Id
                            join cs in dbContext.ComponentStates on cc.ComponentStateId equals cs.Id
                            where tenderIds.Contains(cc.ProcurementId) &&
                                  (componentStatuses == null || componentStatuses.Contains(cs.Kind))
                            select new
                            {
                                cc,
                                s,
                                m,
                                cs
                            };

                var supplyMonitoringLists = new List<SupplyMonitoringList>();

                foreach (var item in query)
                {
                    var supplyMonitoring = new SupplyMonitoringList
                    {
                        SupplierName = item.s.Name,
                        ManufacturerName = item.m.ManufacturerName,
                        ComponentName = item.cc.ComponentNamePurchase,
                        ComponentStatus = item.cs.Kind,
                        AveragePrice = item.cc.PricePurchase,
                        TotalCount = item.cc.CountPurchase,
                        SellerName = item.s.Name,
                        TenderNumber = item.cc.ProcurementId,
                        TotalAmount = item.cc.PricePurchase * item.cc.CountPurchase
                    };

                    supplyMonitoringLists.Add(supplyMonitoring);
                }

                return supplyMonitoringLists;
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
                            .Where(p => p.ProcurementState.Kind == "Выигран 2ч")
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
                    case KindOf.CorrectionDate: // Тендерам на исправлении
                        procurements = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Include(p => p.Law)
                            .Include(p => p.Method)
                            .Include(p => p.Platform)
                            .Include(p => p.Organization)
                            .Include(p => p.TimeZone)
                            .Include(p => p.Region)
                            .Include(p => p.ShipmentPlan)
                            .Where(p => p.CorrectionDate != null && p.ProcurementState.Kind == kind)
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
                    case KindOf.ResultDate: // Дата подведения итогов
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
                            .Where(p => p.ResultDate < DateTime.Now)
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
                            .Where(p => p.ResultDate > DateTime.Now)
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
                    .Where(p => p.Amount < (p.ReserveContractAmount != null && p.ReserveContractAmount != 0 ? p.ReserveContractAmount : p.ContractAmount))

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
                    .Where(p => p.Amount < (p.ReserveContractAmount != null && p.ReserveContractAmount != 0 ? p.ReserveContractAmount : p.ContractAmount))
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
            .Where(p => p.Amount < (p.ReserveContractAmount != null && p.ReserveContractAmount != 0 ? p.ReserveContractAmount : p.ContractAmount))
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
        public static List<Procurement>? ProcurementsBy(bool isTrue, KindOf kindOf) // Получить список тендеров: 
        {
            using ParsethingContext db = new();
            List<Procurement>? procurements = null;

            try
            {
                switch (kindOf)
                {
                    case KindOf.Calculating: // По визе расчета
                        if (isTrue)
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
                            .Where(p => p.Calculating == true)
                            .Where(p => p.ProcurementState.Kind == "Выигран 1ч" || p.ProcurementState.Kind == "Выигран 2ч")
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
                            .Where(p => p.Calculating == false || p.Calculating == null)
                            .Where(p => p.ProcurementState.Kind == "Выигран 1ч" || p.ProcurementState.Kind == "Выигран 2ч")
                            .ToList();
                        }
                        break;
                    case KindOf.Purchase: // По визе закупки
                        if (isTrue)
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
                            .Where(p => p.Purchase == true)
                            .Where(p => p.ProcurementState.Kind == "Выигран 1ч" || p.ProcurementState.Kind == "Выигран 2ч")
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
                            .Where(p => p.Purchase == false || p.Purchase == null)
                            .Where(p => p.ProcurementState.Kind == "Выигран 1ч" || p.ProcurementState.Kind == "Выигран 2ч")
                            .ToList();
                        }
                        break;
                }
            }
            catch { }

            return procurements;
        }

        public static List<Procurement>? ProcurementsBy(string searchIds, string searchNumber, string searchLaw, string searchProcurementState, string searchInn, string searchEmployeeName, string searchOrganizationName, int pageSize, int currentPage)
        {
            using ParsethingContext db = new();
            List<Procurement>? procurements = null;

            var procurementQuery = db.Procurements.AsQueryable();

            // Обрабатываем поле searchIds, чтобы избежать ошибок при вводе букв
            var ids = searchIds.Split(',')
                               .Select(id => int.TryParse(id.Trim(), out int intId) ? intId : (int?)null)
                               .Where(id => id.HasValue)
                               .Select(id => id.Value)
                               .ToList();

            // Если нет выбранных идентификаторов тендеров, сотрудника и остальные поля также пусты, возвращаем пустой список тендеров
            if (ids.Count == 0 && string.IsNullOrEmpty(searchEmployeeName)
                && string.IsNullOrEmpty(searchNumber) && string.IsNullOrEmpty(searchLaw)
                && string.IsNullOrEmpty(searchProcurementState) && string.IsNullOrEmpty(searchInn)
                && string.IsNullOrEmpty(searchOrganizationName))
            {
                return new List<Procurement>();
            }

            // Фильтруем тендеры по выбранным параметрам
            if (ids.Count > 0)
            {
                procurementQuery = procurementQuery.Where(p => ids.Contains(p.Id));
            }

            if (!string.IsNullOrEmpty(searchNumber))
                procurementQuery = procurementQuery.Where(p => p.Number == searchNumber);
            if (!string.IsNullOrEmpty(searchLaw))
                procurementQuery = procurementQuery.Where(p => p.Law.Number == searchLaw);
            if (!string.IsNullOrEmpty(searchProcurementState))
                procurementQuery = procurementQuery.Where(p => p.ProcurementState.Kind == searchProcurementState);
            if (!string.IsNullOrEmpty(searchInn))
                procurementQuery = procurementQuery.Where(p => p.Inn == searchInn);
            if (!string.IsNullOrEmpty(searchOrganizationName))
                procurementQuery = procurementQuery.Where(p => p.Organization.Name.Contains(searchOrganizationName));

            // Если выбран сотрудник, проверяем есть ли у него связанные тендеры
            if (!string.IsNullOrEmpty(searchEmployeeName))
            {
                var query = db.ProcurementsEmployees
                              .Where(pe => pe.Employee.FullName == searchEmployeeName)
                              .Select(pe => pe.ProcurementId)
                              .ToList();

                if (query.Count == 0)
                {
                    return new List<Procurement>();
                }

                procurementQuery = procurementQuery.Where(p => query.Contains(p.Id));
            }

            // Запросы Include остаются без изменений
            procurementQuery = procurementQuery
                .Include(p => p.ProcurementState)
                .Include(p => p.Law)
                .Include(p => p.Method)
                .Include(p => p.Platform)
                .Include(p => p.TimeZone)
                .Include(p => p.Region)
                .Include(p => p.ShipmentPlan)
                .Include(p => p.Organization);

            // Применяем пагинацию
            procurements = procurementQuery
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return procurements;
        }


        public static List<ProcurementsEmployeesGrouping>? ProcurementsGroupByMethod() // Получить список отправленных тендеров групированных по методам проведения
        {
            using ParsethingContext db = new();
            var procurementsEmployees = db.Procurements
                .Include(p => p.Law)
                .Include(p => p.Method)
                .Include(p => p.ProcurementState)
                .Where(p => p.Method != null)
                .Where(p => p.ProcurementState.Kind == "Отправлен")
                .GroupBy(p => p.Method.Text)
                .Select(g => new ProcurementsEmployeesGrouping
                {
                    Id = g.Key,
                    CountOfProcurements = g.Count(),
                    Procurements = g.ToList() // Добавлено
                })
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
                .Include(pe => pe.Procurement.Law)
                .Include(pe => pe.Employee)
                .Include(pe => pe.Procurement.Method)
                .Include(pe => pe.Procurement)
                .Where(pe => pe.EmployeeId == employeeId)
                .GroupBy(pe => pe.Employee.FullName)
                .Select(g => new ProcurementsEmployeesGrouping
                {
                    Id = g.Key,
                    CountOfProcurements = g.Count(),
                    Procurements = g.Select(pe => pe.Procurement).ToList() // Добавлено
                })
                .ToList();

            return procurementsEmployees;
        }

        public static List<ProcurementsEmployeesGrouping>? ProcurementsEmployeesGroupBy(string premierPosition, string secondPosition, string thirdPosition, string premierProcurementState, string secondProcurementState, string thirdProcurementState) // Получить список сотруников и тендеров, которые у них в работе (по трем должностям и трем статусам) 
        {
            using ParsethingContext db = new();
            var procurementsEmployees = db.ProcurementsEmployees
                .Include(pe => pe.Procurement.Law)
                .Include(pe => pe.Employee)
                .Include(pe => pe.Procurement.ProcurementState)
                .Include(pe => pe.Employee.Position)
                .Include(pe => pe.Procurement.Method)
                .Include(pe => pe.Procurement)
                .Where(pe => pe.Employee.Position.Kind == premierPosition || pe.Employee.Position.Kind == secondPosition || pe.Employee.Position.Kind == thirdPosition)
                .Where(pe => pe.Procurement.ProcurementState.Kind == premierProcurementState || pe.Procurement.ProcurementState.Kind == secondProcurementState || pe.Procurement.ProcurementState.Kind == thirdProcurementState)
                .GroupBy(pe => pe.Employee.FullName)
                .Select(g => new ProcurementsEmployeesGrouping
                {
                    Id = g.Key,
                    CountOfProcurements = g.Count(),
                    Procurements = g.Select(pe => pe.Procurement).ToList() // Добавлено
                })
                .ToList();

            return procurementsEmployees;
        }

        public static List<ProcurementsEmployeesGrouping>? ProcurementsEmployeesGroupBy(string premierPosition, string secondPosition, string thirdPosition) // Получить список сотруников и тендеров, которые у них в работе (по трем должностям) 
        {
            using ParsethingContext db = new();
            var procurementsEmployees = db.ProcurementsEmployees
                .Include(pe => pe.Procurement.Law)
                .Include(pe => pe.Employee)
                .Include(pe => pe.Procurement.ProcurementState)
                .Include(pe => pe.Employee.Position)
                .Include(pe => pe.Procurement.Method)
                .Include(pe => pe.Procurement)
                .Where(pe => pe.Employee.Position.Kind == premierPosition || pe.Employee.Position.Kind == secondPosition || pe.Employee.Position.Kind == thirdPosition)
                .GroupBy(pe => pe.Employee.FullName)
                .Select(g => new ProcurementsEmployeesGrouping
                {
                    Id = g.Key,
                    CountOfProcurements = g.Count(),
                    Procurements = g.Select(pe => pe.Procurement).ToList() // Добавлено
                })
                .ToList();

            return procurementsEmployees;
        }

        public static List<Procurement>? ProcurementsQueue() // Очередь расчета
        {
            using ParsethingContext db = new();
            List<Procurement>? procurements = null;

            try
            {
                procurements = db.Procurements
                    .Include(p => p.ProcurementState)
                    .Include(p => p.Law)
                    .Where(p => p.ProcurementState.Kind == "Новый" && !db.ProcurementsEmployees.Any(pe => pe.ProcurementId == p.Id))
                    .ToList();
            }
            catch { }

            return procurements;
        }
        public static List<Procurement>? ProcurementsManagersQueue()
        {
            using ParsethingContext db = new();
            List<Procurement>? procurements = null;

            try
            {
                procurements = db.Procurements
                    .Include(p => p.ProcurementState)
                    .Include(p => p.Law)
                    .Where(p => p.ProcurementState.Kind == "Выигран 1ч" && !db.ProcurementsEmployees.Any(pe => pe.ProcurementId == p.Id && pe.Employee.Position.Id == 8))
                    .ToList();
            }
            catch { }

            return procurements;
        }

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
        public static List<ProcurementsEmployee>? ProcurementsEmployeesByProcurement(int procurementId) // Получть список тендеров и сотрудников по id тендера
        {
            using ParsethingContext db = new();
            List<ProcurementsEmployee>? procurements = null;

            try
            {
                procurements = db.ProcurementsEmployees
                    .Include(pe => pe.Employee)
                    .Where(pe => pe.Procurement.Id == procurementId)
                    .ToList();
            }
            catch { }

            return procurements;
        }

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
                            .Where(pe => pe.Procurement.ProcurementState.Kind == "Выигран 2ч")
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
                            .Where(pe => pe.Procurement.ExecutionState.Kind == "Запрошена БГ" || pe.Procurement.ExecutionState.Kind == "На согласовании заказчика" || pe.Procurement.ExecutionState.Kind == "Внесение правок" || pe.Procurement.ExecutionState.Kind == "Согласована БГ" || pe.Procurement.ExecutionState.Kind == "Ожидает оплаты" || pe.Procurement.ExecutionState.Kind == "Оформлена БГ" || pe.Procurement.ExecutionState.Kind == "Деньги(Возвратные)" || pe.Procurement.ExecutionState.Kind == "Добросовестность")
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
                            .Where(pe => pe.Procurement.WarrantyState.Kind == "Запрошена БГ" || pe.Procurement.WarrantyState.Kind == "На согласовании заказчика" || pe.Procurement.WarrantyState.Kind == "Внесение правок" || pe.Procurement.WarrantyState.Kind == "Согласована БГ" || pe.Procurement.WarrantyState.Kind == "Ожидает оплаты" || pe.Procurement.WarrantyState.Kind == "Оформлена БГ" || pe.Procurement.WarrantyState.Kind == "Деньги(Возвратные)" || pe.Procurement.WarrantyState.Kind == "Добросовестность")
                            .ToList();
                        break;
                    case KindOf.CorrectionDate: // Статусу обеспечения гарантии, конкретным статусам тендера и id сотрудника
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
                            .Where(pe => pe.Procurement.ProcurementState.Kind == kind)
                            .Where(pe => pe.Procurement.CorrectionDate != null)
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
                        .Where(pe => pe.Procurement.Amount < (pe.Procurement.ReserveContractAmount != null && pe.Procurement.ReserveContractAmount != 0 ? pe.Procurement.ReserveContractAmount : pe.Procurement.ContractAmount))
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
                        .Where(pe => pe.Procurement.Amount < (pe.Procurement.ReserveContractAmount != null && pe.Procurement.ReserveContractAmount != 0 ? pe.Procurement.ReserveContractAmount : pe.Procurement.ContractAmount))
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
                    .Where(pe => pe.Procurement.Amount < (pe.Procurement.ReserveContractAmount != null && pe.Procurement.ReserveContractAmount != 0 ? pe.Procurement.ReserveContractAmount : pe.Procurement.ContractAmount))
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
        public static List<ProcurementsEmployee>? ProcurementsEmployeesBy(bool isTrue, KindOf kindOf, int employeeId) // Получить тендеры, назначенные на конкретного сотрудника
        {
            using ParsethingContext db = new();
            List<ProcurementsEmployee>? procurementsEmployees = null;

            try
            {
                switch (kindOf)
                {
                    case KindOf.Calculating: // По визе расчета
                        if (isTrue)
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
                            .Where(pe => pe.Procurement.Calculating == true)
                            .Where(p => p.Procurement.ProcurementState.Kind == "Выигран 1ч" || p.Procurement.ProcurementState.Kind == "Выигран 2ч")
                            .ToList();
                        }
                        else
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
                            .Where(pe => pe.Procurement.Calculating == false || pe.Procurement.Calculating == null)
                            .Where(p => p.Procurement.ProcurementState.Kind == "Выигран 1ч" || p.Procurement.ProcurementState.Kind == "Выигран 2ч")
                            .ToList();
                        }
                        break;
                    case KindOf.Purchase: // По визе закупки
                        if (isTrue)
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
                            .Where(pe => pe.Procurement.Purchase == true)
                            .Where(p => p.Procurement.ProcurementState.Kind == "Выигран 1ч" || p.Procurement.ProcurementState.Kind == "Выигран 2ч")
                            .ToList();
                        }
                        else
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
                            .Where(pe => pe.Procurement.Purchase == false || pe.Procurement.Purchase == null)
                            .Where(p => p.Procurement.ProcurementState.Kind == "Выигран 1ч" || p.Procurement.ProcurementState.Kind == "Выигран 2ч")
                            .ToList();
                        }
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
                            .Where(ps => ps.Kind == "Новый" || ps.Kind == "Посчитан" || ps.Kind == "Оформлен")
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
                            .Where(ps => ps.Kind == "Оформлен" || ps.Kind == "Новый" || ps.Kind == "Отправлен" || ps.Kind == "Выигран 1ч" || ps.Kind == "Отмена" || ps.Kind == "Проигран")
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
        public static List<Procurement>? ApplicationsBy(int procurementId)
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
                    .Where(p => p.ParentProcurementId == procurementId)
                    .ToList();
            }
            catch { }
            return procurements;
        }
    }

    public struct Aggregate
    {
        public static int ComponentClculationCountBy(int id) // Получить количество позиций по id тендера
        {
            using ParsethingContext db = new();
            int count = 0;

            try
            {
                count = db.ComponentCalculations
                    .Where(cc => cc.ProcurementId == id && cc.IsHeader == false && cc.IsAdded == false)
                    .Count();
            }
            catch { }

            return count;
        }
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
                            .Where(p => p.ProcurementState.Kind == "Выигран 2ч")
                            .Count();
                        break;
                    case KindOf.Applications: // Положительному статусу "По заявкам"
                        count = db.Procurements
                            .Where(p => p.Applications == true)
                            .Count();
                        break;
                    case KindOf.CorrectionDate: // По тендерам на исправлении
                        count = db.Procurements
                            .Where(p => p.CorrectionDate != null)
                            .Where(p => p.ProcurementState.Kind == kind)
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
                    .Where(p => p.Amount < (p.ReserveContractAmount != null && p.ReserveContractAmount != 0 ? p.ReserveContractAmount : p.ContractAmount))
                    .Count();
                }
                else // Непросроченных по дате оплаты
                {
                    count = db.Procurements
                    .Include(p => p.ProcurementState)
                    .Where(p => p.ProcurementState.Kind == "Принят")
                    .Where(p => p.MaxDueDate > DateTime.Now)
                    .Where(p => p.RealDueDate == null)
                    .Where(p => p.Amount < (p.ReserveContractAmount != null && p.ReserveContractAmount != 0 ? p.ReserveContractAmount : p.ContractAmount))
                    .Count();
                }
            }
            catch { }

            return count;
        }
        public static int ProcurementsQueueCount() // Очередь расчета
        {
            using ParsethingContext db = new();
            int count = 0;
            try
            {
                count = db.Procurements
                    .Include(p => p.ProcurementState)
                    .Include(p => p.Law)
                    .Where(p => p.ProcurementState.Kind == "Новый" && !db.ProcurementsEmployees.Any(pe => pe.ProcurementId == p.Id))
                    .Count();
            }
            catch { }

            return count;
        }
        public static int ProcurementsManagersQueueCount() // Тендеры, не назначенные не конкретного менеджера (количество)
        {
            using ParsethingContext db = new();
            int count = 0;
            try
            {
                count = db.Procurements
                    .Include(p => p.ProcurementState)
                    .Include(p => p.Law)
                    .Where(p => p.ProcurementState.Kind == "Выигран 1ч" && !db.ProcurementsEmployees.Any(pe => pe.ProcurementId == p.Id && pe.Employee.Position.Id == 8))
                    .Count();
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
        public static int ProcurementsCountBy(bool isTrue, KindOf kindOf) // Получить количество тендеров по:
        {
            using ParsethingContext db = new();
            int count = 0;

            try
            {
                switch (kindOf)
                {
                    case KindOf.Calculating: // По визе расчета
                        if (isTrue)
                        {
                            count = db.Procurements
                              .Where(p => p.Calculating == true)
                              .Where(p => p.ProcurementState.Kind == "Выигран 1ч" || p.ProcurementState.Kind == "Выигран 2ч")
                              .Count();
                        }
                        else
                        {
                            count = db.Procurements
                              .Where(p => p.Calculating == false || p.Calculating == null)
                              .Where(p => p.ProcurementState.Kind == "Выигран 1ч" || p.ProcurementState.Kind == "Выигран 2ч")
                              .Count();
                        }
                        break;
                    case KindOf.Purchase: // По визе закупки
                        if (isTrue)
                        {
                            count = db.Procurements
                              .Where(p => p.Purchase == true)
                              .Where(p => p.ProcurementState.Kind == "Выигран 1ч" || p.ProcurementState.Kind == "Выигран 2ч")
                              .Count();
                        }
                        else
                        {
                            count = db.Procurements
                              .Where(p => p.Purchase == false || p.Purchase == null)
                              .Where(p => p.ProcurementState.Kind == "Выигран 1ч" || p.ProcurementState.Kind == "Выигран 2ч")
                              .Count();
                        }
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
                    case KindOf.ResultDate: // Дате начала подачи заявок
                        if (isOverdue) // Просроченные
                        {
                            count = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Where(p => p.ProcurementState.Kind == procurementStateKind)
                            .Where(p => p.ResultDate < DateTime.Now)
                            .Count();
                        }
                        else // Непросроченные
                        {
                            count = db.Procurements
                            .Include(p => p.ProcurementState)
                            .Where(p => p.ProcurementState.Kind == procurementStateKind)
                            .Where(p => p.ResultDate > DateTime.Now)
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
                            .Where(pe => pe.Procurement.ProcurementState.Kind == "Выигран 2ч")
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
                            .Where(pe => pe.Procurement.ExecutionState.Kind == "Запрошена БГ" || pe.Procurement.ExecutionState.Kind == "На согласовании заказчика" || pe.Procurement.ExecutionState.Kind == "Внесение правок" || pe.Procurement.ExecutionState.Kind == "Согласована БГ" || pe.Procurement.ExecutionState.Kind == "Ожидает оплаты" || pe.Procurement.ExecutionState.Kind == "Оформлена БГ" || pe.Procurement.ExecutionState.Kind == "Деньги(Возвратные)" || pe.Procurement.ExecutionState.Kind == "Добросовестность")
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
                            .Where(pe => pe.Procurement.WarrantyState.Kind == "Запрошена БГ" || pe.Procurement.WarrantyState.Kind == "На согласовании заказчика" || pe.Procurement.WarrantyState.Kind == "Внесение правок" || pe.Procurement.WarrantyState.Kind == "Согласована БГ" || pe.Procurement.WarrantyState.Kind == "Ожидает оплаты" || pe.Procurement.WarrantyState.Kind == "Оформлена БГ" || pe.Procurement.WarrantyState.Kind == "Деньги(Возвратные)" || pe.Procurement.WarrantyState.Kind == "Добросовестность")
                            .Count();
                        break;
                    case KindOf.CorrectionDate: // По тендерам на исправлении
                        count = db.ProcurementsEmployees
                            .Include(pe => pe.Employee)
                            .Include(pe => pe.Procurement)
                            .Include(pe => pe.Procurement.WarrantyState)
                            .Include(pe => pe.Procurement.ProcurementState)
                            .Where(pe => pe.Employee.Id == employeeId)
                            .Where(pe => pe.Procurement.ProcurementState.Kind == kind)
                            .Where(pe => pe.Procurement.CorrectionDate != null)
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
                    case KindOf.ResultDate: // Дате подведения итогов
                        if (isOverdue) // Просроченные 
                        {
                            count = db.ProcurementsEmployees
                                .Include(pe => pe.Employee)
                                .Include(pe => pe.Procurement)
                                .Include(pe => pe.Procurement.ProcurementState)
                                .Where(pe => pe.Employee.Id == employeeId)
                                .Where(pe => pe.Procurement.ProcurementState.Kind == procurementStateKind)
                                .Where(pe => pe.Procurement.ResultDate < DateTime.Now)
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
                                .Where(pe => pe.Procurement.ResultDate > DateTime.Now)
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
                        .Where(pe => pe.Procurement.Amount < (pe.Procurement.ReserveContractAmount != null && pe.Procurement.ReserveContractAmount != 0 ? pe.Procurement.ReserveContractAmount : pe.Procurement.ContractAmount))
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
                    .Where(pe => pe.Procurement.Amount < (pe.Procurement.ReserveContractAmount != null && pe.Procurement.ReserveContractAmount != 0 ? pe.Procurement.ReserveContractAmount : pe.Procurement.ContractAmount))
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
        public static int ProcurementsEmployeesCountBy(bool isTrue, KindOf kindOf, int employeeId) // Получить количество тендеров по конкретному сотруднику 
        {
            using ParsethingContext db = new();
            int count = 0;

            try
            {
                switch (kindOf)
                {
                    case KindOf.Calculating: // По визе расчета
                        if (isTrue) // Есть
                        {
                            count = db.ProcurementsEmployees
                            .Include(pe => pe.Employee)
                            .Include(pe => pe.Procurement)
                            .Where(pe => pe.Employee.Id == employeeId)
                            .Where(pe => pe.Procurement.Calculating == true)
                            .Where(pe => pe.Procurement.ProcurementState.Kind == "Выигран 1ч" || pe.Procurement.ProcurementState.Kind == "Выигран 2ч")
                            .Count();
                        }
                        else // Нет
                        {
                            count = db.ProcurementsEmployees
                            .Include(pe => pe.Employee)
                            .Include(pe => pe.Procurement)
                            .Where(pe => pe.Employee.Id == employeeId)
                            .Where(pe => pe.Procurement.Calculating == false || pe.Procurement.Calculating == null)
                            .Where(pe => pe.Procurement.ProcurementState.Kind == "Выигран 1ч" || pe.Procurement.ProcurementState.Kind == "Выигран 2ч")
                            .Count();
                        }
                        break;
                    case KindOf.Purchase: // По визе закупки
                        if (isTrue)// Есть
                        {
                            count = db.ProcurementsEmployees
                            .Include(pe => pe.Employee)
                            .Include(pe => pe.Procurement)
                            .Where(pe => pe.Employee.Id == employeeId)
                            .Where(pe => pe.Procurement.Purchase == true)
                            .Where(pe => pe.Procurement.ProcurementState.Kind == "Выигран 1ч" || pe.Procurement.ProcurementState.Kind == "Выигран 2ч")
                            .Count();
                        }
                        else // Нет
                        {
                            count = db.ProcurementsEmployees
                            .Include(pe => pe.Employee)
                            .Include(pe => pe.Procurement)
                            .Where(pe => pe.Employee.Id == employeeId)
                            .Where(pe => pe.Procurement.Purchase == false || pe.Procurement.Purchase == null)
                            .Where(pe => pe.Procurement.ProcurementState.Kind == "Выигран 1ч" || pe.Procurement.ProcurementState.Kind == "Выигран 2ч")
                            .Count();
                        }
                        break;
                }
            }
            catch { }

            return count;

        }

        public static int NumberOfApplication(int procurementId) // получить номер создаваемой заявки при ее создании
        {
            using ParsethingContext db = new();
            int number = 0;

            try
            {
                number = db.Procurements.Count(p => p.ParentProcurementId == procurementId);
            }
            catch { }

            return number + 1;
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
        public List<Procurement> Procurements { get; set; }

    }

    public enum KindOf // Перечисление для типизации запросов
    {
        ProcurementState, // Статус тендера
        ShipmentPlane, // План отгрузки
        Applications, // Статус "По заявкам"
        StartDate, // Дата начала подачи заявок
        Deadline, // Дата окончания подачи заявок
        ResultDate, // Дата подведения итогов
        CorrectionDate, // Дата исправления недостатков
        Judgement, // Суд
        FAS, // ФАС
        ContractConclusion, // Дата подписания контракта
        ExecutionState, // Статус обеспечения исполнения заявки
        WarrantyState, // Статус обеспечения гарантии заявки
        Calculating, // Виза расчетчиков
        Purchase, // Виза закупки
        IsUnitPrice // Цена за единицу товара
    }
    
}