using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace DatabaseLibrary.Entities.ProcurementProperties
{
    public partial class Procurement : INotifyPropertyChanged
    {
        private int _id;
        private int? _displayId;
        private string _requestUri = null!;
        private string _number = null!;
        private int _lawId;
        private string _object = null!;
        private decimal _initialPrice;
        private int _organizationId;
        private int? _methodId;
        private int? _platformId;
        private string? _location;
        private DateTime? _postingDate;
        private DateTime? _startDate;
        private DateTime? _deadline;
        private DateTime? _resultDate;
        private int? _timeZoneId;
        private string? _securing;
        private string? _enforcement;
        private string? _warranty;
        private int? _regionId;
        private int? _cityId;
        private int? _distance;
        private string? _organizationContractName;
        private string? _organizationContractPostalAddress;
        private string? _contactPerson;
        private string? _contactPhone;
        private string? _organizationEmail;
        private string? _headOfAcceptance;
        private string? _deliveryDetails;
        private string? _deadlineAndType;
        private string? _deliveryDeadline;
        private string? _acceptanceDeadline;
        private string? _contractDeadline;
        private string? _deadlineAndOrder;
        private int? _representativeTypeId;
        private int? _commissioningWorksId;
        private int? _placeCount;
        private string? _finesAndPennies;
        private string? _penniesPerDay;
        private string? _terminationConditions;
        private string? _eliminationDeadline;
        private string? _guaranteePeriod;
        private string? _inn;
        private string? _contractNumber;
        private int? _employeeId;
        private bool? _assemblyNeed;
        private int? _minopttorgId;
        private int? _legalEntityId;
        private bool? _applications;
        private int? _applicationNumber;
        private decimal? _bet;
        private decimal? _minimalPrice;
        private decimal? _contractAmount;
        private decimal? _reserveContractAmount;
        private bool? _isUnitPrice;
        private DateTime? _protocolDate;
        private RejectionReason? _rejectionReason;
        private decimal? _competitorSum;
        private int? _shipmentPlanId;
        private bool? _waitingList;
        private bool? _calculating;
        private bool? _purchase;
        private int? _executionStateId;
        private decimal? _executionPrice;
        private DateTime? _executionDate;
        private int? _warrantyStateId;
        private decimal? _warrantyPrice;
        private DateTime? _warrantyDate;
        private DateTime? _signingDeadline;
        private DateTime? _signingDate;
        private DateTime? _conclusionDate;
        private DateTime? _actualDeliveryDate;
        private DateTime? _departureDate;
        private DateTime? _deliveryDate;
        private DateTime? _maxAcceptanceDate;
        private DateTime? _correctionDate;
        private DateTime? _actDate;
        private DateTime? _maxDueDate;
        private DateTime? _closingDate;
        private DateTime? _realDueDate;
        private decimal? _amount;
        private int? _signedOriginalId;
        private bool? _judgment;
        private bool? _fas;
        private bool? _claimWorks;
        private int? _procurementStateId;
        private decimal? _calculatingAmount;
        private decimal? _purchaseAmount;
        private string? _passportOfMonitor;
        private string? _passportOfPc;
        private string? _passportOfMonoblock;
        private string? _passportOfNotebook;
        private string? _passportOfAw;
        private string? _passportOfUps;
        private bool? _isProcurementBlocked;
        private bool? _isPurchaseBlocked;
        private bool? _isCalculationBlocked;
        private int? _procurementUserId;
        private int? _purchaseUserId;
        private int? _calculatingUserId;
        private int? _parentProcurementId;

        private ICollection<ComponentCalculation> _componentCalculations = new List<ComponentCalculation>();
        private ObservableCollection<ComponentStateCount> _componentStates = new ObservableCollection<ComponentStateCount>();
        private CommisioningWork? _commissioningWorks;
        private ExecutionState? _executionState;
        private City? _city;
        private Law? _law;
        private LegalEntity? _legalEntity;
        private Method? _method;
        private Minopttorg? _minopttorg;
        private Organization? _organization;
        private Platform? _platform;
        private ProcurementState? _procurementState;
        private Region? _region;
        private RepresentativeType? _representativeType;
        private ShipmentPlan? _shipmentPlan;
        private SignedOriginal? _signedOriginal;
        private TimeZone? _timeZone;
        private WarrantyState? _warrantyState;

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }
        public int? DisplayId
        {
            get => _displayId;
            set { _displayId = value; OnPropertyChanged(); }
        }
        public string RequestUri
        {
            get => _requestUri;
            set { _requestUri = value; OnPropertyChanged(); }
        }
        public string Number
        {
            get => _number;
            set { _number = value; OnPropertyChanged(); }
        }
        public int LawId
        {
            get => _lawId;
            set { _lawId = value; OnPropertyChanged(); }
        }
        public string Object
        {
            get => _object;
            set { _object = value; OnPropertyChanged(); }
        }
        public decimal InitialPrice
        {
            get => _initialPrice;
            set { _initialPrice = value; OnPropertyChanged(); }
        }
        public int OrganizationId
        {
            get => _organizationId;
            set { _organizationId = value; OnPropertyChanged(); }
        }
        public int? MethodId
        {
            get => _methodId;
            set { _methodId = value; OnPropertyChanged(); }
        }
        public int? PlatformId
        {
            get => _platformId;
            set { _platformId = value; OnPropertyChanged(); }
        }
        public string? Location
        {
            get => _location;
            set { _location = value; OnPropertyChanged(); }
        }
        public DateTime? PostingDate
        {
            get => _postingDate;
            set { _postingDate = value; OnPropertyChanged(); }
        }
        public DateTime? StartDate
        {
            get => _startDate;
            set { _startDate = value; OnPropertyChanged(); }
        }
        public DateTime? Deadline
        {
            get => _deadline;
            set { _deadline = value; OnPropertyChanged(); }
        }
        public DateTime? ResultDate
        {
            get => _resultDate;
            set { _resultDate = value; OnPropertyChanged(); }
        }
        public int? TimeZoneId
        {
            get => _timeZoneId;
            set { _timeZoneId = value; OnPropertyChanged(); }
        }
        public string? Securing
        {
            get => _securing;
            set { _securing = value; OnPropertyChanged(); }
        }
        public string? Enforcement
        {
            get => _enforcement;
            set { _enforcement = value; OnPropertyChanged(); }
        }
        public string? Warranty
        {
            get => _warranty;
            set { _warranty = value; OnPropertyChanged(); }
        }
        public int? RegionId
        {
            get => _regionId;
            set { _regionId = value; OnPropertyChanged(); }
        }
        public int? CityId
        {
            get => _cityId;
            set { _cityId = value; OnPropertyChanged(); }
        }
        public int? Distance
        {
            get => _distance;
            set { _distance = value; OnPropertyChanged(); }
        }
        public string? OrganizationContractName
        {
            get => _organizationContractName;
            set { _organizationContractName = value; OnPropertyChanged(); }
        }
        public string? OrganizationContractPostalAddress
        {
            get => _organizationContractPostalAddress;
            set { _organizationContractPostalAddress = value; OnPropertyChanged(); }
        }
        public string? ContactPerson
        {
            get => _contactPerson;
            set { _contactPerson = value; OnPropertyChanged(); }
        }
        public string? ContactPhone
        {
            get => _contactPhone;
            set { _contactPhone = value; OnPropertyChanged(); }
        }
        public string? OrganizationEmail
        {
            get => _organizationEmail;
            set { _organizationEmail = value; OnPropertyChanged(); }
        }
        public string? HeadOfAcceptance
        {
            get => _headOfAcceptance;
            set { _headOfAcceptance = value; OnPropertyChanged(); }
        }
        public string? DeliveryDetails
        {
            get => _deliveryDetails;
            set { _deliveryDetails = value; OnPropertyChanged(); }
        }
        public string? DeadlineAndType
        {
            get => _deadlineAndType;
            set { _deadlineAndType = value; OnPropertyChanged(); }
        }
        public string? DeliveryDeadline
        {
            get => _deliveryDeadline;
            set { _deliveryDeadline = value; OnPropertyChanged(); }
        }
        public string? AcceptanceDeadline
        {
            get => _acceptanceDeadline;
            set { _acceptanceDeadline = value; OnPropertyChanged(); }
        }
        public string? ContractDeadline
        {
            get => _contractDeadline;
            set { _contractDeadline = value; OnPropertyChanged(); }
        }
        public string? DeadlineAndOrder
        {
            get => _deadlineAndOrder;
            set { _deadlineAndOrder = value; OnPropertyChanged(); }
        }
        public int? RepresentativeTypeId
        {
            get => _representativeTypeId;
            set { _representativeTypeId = value; OnPropertyChanged(); }
        }
        public int? CommissioningWorksId
        {
            get => _commissioningWorksId;
            set { _commissioningWorksId = value; OnPropertyChanged(); }
        }
        public int? PlaceCount
        {
            get => _placeCount;
            set { _placeCount = value; OnPropertyChanged(); }
        }
        public string? FinesAndPennies
        {
            get => _finesAndPennies;
            set { _finesAndPennies = value; OnPropertyChanged(); }
        }
        public string? PenniesPerDay
        {
            get => _penniesPerDay;
            set { _penniesPerDay = value; OnPropertyChanged(); }
        }
        public string? TerminationConditions
        {
            get => _terminationConditions;
            set { _terminationConditions = value; OnPropertyChanged(); }
        }
        public string? EliminationDeadline
        {
            get => _eliminationDeadline;
            set { _eliminationDeadline = value; OnPropertyChanged(); }
        }
        public string? GuaranteePeriod
        {
            get => _guaranteePeriod;
            set { _guaranteePeriod = value; OnPropertyChanged(); }
        }
        public string? Inn
        {
            get => _inn;
            set { _inn = value; OnPropertyChanged(); }
        }
        public string? ContractNumber
        {
            get => _contractNumber;
            set { _contractNumber = value; OnPropertyChanged(); }
        }
        public int? EmployeeId
        {
            get => _employeeId;
            set { _employeeId = value; OnPropertyChanged(); }
        }
        public bool? AssemblyNeed
        {
            get => _assemblyNeed;
            set { _assemblyNeed = value; OnPropertyChanged(); }
        }
        public int? MinopttorgId
        {
            get => _minopttorgId;
            set { _minopttorgId = value; OnPropertyChanged(); }
        }
        public int? LegalEntityId
        {
            get => _legalEntityId;
            set { _legalEntityId = value; OnPropertyChanged(); }
        }
        public bool? Applications
        {
            get => _applications;
            set { _applications = value; OnPropertyChanged(); }
        }
        public int? ApplicationNumber
        {
            get => _applicationNumber;
            set { _applicationNumber = value; OnPropertyChanged(); }
        }
        public decimal? Bet
        {
            get => _bet;
            set { _bet = value; OnPropertyChanged(); }
        }
        public decimal? MinimalPrice
        {
            get => _minimalPrice;
            set { _minimalPrice = value; OnPropertyChanged(); }
        }
        public decimal? ContractAmount
        {
            get => _contractAmount;
            set { _contractAmount = value; OnPropertyChanged(); }
        }
        public decimal? ReserveContractAmount
        {
            get => _reserveContractAmount;
            set { _reserveContractAmount = value; OnPropertyChanged(); }
        }
        public bool? IsUnitPrice
        {
            get => _isUnitPrice;
            set { _isUnitPrice = value; OnPropertyChanged(); }
        }
        public DateTime? ProtocolDate
        {
            get => _protocolDate;
            set { _protocolDate = value; OnPropertyChanged(); }
        }
        public RejectionReason? RejectionReason
        {
            get => _rejectionReason;
            set { _rejectionReason = value; OnPropertyChanged(); }
        }
        public decimal? CompetitorSum
        {
            get => _competitorSum;
            set { _competitorSum = value; OnPropertyChanged(); }
        }
        public int? ShipmentPlanId
        {
            get => _shipmentPlanId;
            set { _shipmentPlanId = value; OnPropertyChanged(); }
        }
        public bool? WaitingList
        {
            get => _waitingList;
            set { _waitingList = value; OnPropertyChanged(); }
        }
        public bool? Calculating
        {
            get => _calculating;
            set { _calculating = value; OnPropertyChanged(); }
        }
        public bool? Purchase
        {
            get => _purchase;
            set { _purchase = value; OnPropertyChanged(); }
        }
        public int? ExecutionStateId
        {
            get => _executionStateId;
            set { _executionStateId = value; OnPropertyChanged(); }
        }
        public decimal? ExecutionPrice
        {
            get => _executionPrice;
            set { _executionPrice = value; OnPropertyChanged(); }
        }
        public DateTime? ExecutionDate
        {
            get => _executionDate;
            set { _executionDate = value; OnPropertyChanged(); }
        }
        public int? WarrantyStateId
        {
            get => _warrantyStateId;
            set { _warrantyStateId = value; OnPropertyChanged(); }
        }
        public decimal? WarrantyPrice
        {
            get => _warrantyPrice;
            set { _warrantyPrice = value; OnPropertyChanged(); }
        }
        public DateTime? WarrantyDate
        {
            get => _warrantyDate;
            set { _warrantyDate = value; OnPropertyChanged(); }
        }
        public DateTime? SigningDeadline
        {
            get => _signingDeadline;
            set { _signingDeadline = value; OnPropertyChanged(); }
        }
        public DateTime? SigningDate
        {
            get => _signingDate;
            set { _signingDate = value; OnPropertyChanged(); }
        }
        public DateTime? ConclusionDate
        {
            get => _conclusionDate;
            set { _conclusionDate = value; OnPropertyChanged(); }
        }
        public DateTime? ActualDeliveryDate
        {
            get => _actualDeliveryDate;
            set { _actualDeliveryDate = value; OnPropertyChanged(); }
        }
        public DateTime? DepartureDate
        {
            get => _departureDate;
            set { _departureDate = value; OnPropertyChanged(); }
        }
        public DateTime? DeliveryDate
        {
            get => _deliveryDate;
            set { _deliveryDate = value; OnPropertyChanged(); }
        }
        public DateTime? MaxAcceptanceDate
        {
            get => _maxAcceptanceDate;
            set { _maxAcceptanceDate = value; OnPropertyChanged(); }
        }
        public DateTime? CorrectionDate
        {
            get => _correctionDate;
            set { _correctionDate = value; OnPropertyChanged(); }
        }
        public DateTime? ActDate
        {
            get => _actDate;
            set { _actDate = value; OnPropertyChanged(); }
        }
        public DateTime? MaxDueDate
        {
            get => _maxDueDate;
            set { _maxDueDate = value; OnPropertyChanged(); }
        }
        public DateTime? ClosingDate
        {
            get => _closingDate;
            set { _closingDate = value; OnPropertyChanged(); }
        }
        public DateTime? RealDueDate
        {
            get => _realDueDate;
            set { _realDueDate = value; OnPropertyChanged(); }
        }
        public decimal? Amount
        {
            get => _amount;
            set { _amount = value; OnPropertyChanged(); }
        }
        public int? SignedOriginalId
        {
            get => _signedOriginalId;
            set { _signedOriginalId = value; OnPropertyChanged(); }
        }
        public bool? Judgment
        {
            get => _judgment;
            set { _judgment = value; OnPropertyChanged(); }
        }
        public bool? Fas
        {
            get => _fas;
            set { _fas = value; OnPropertyChanged(); }
        }
        public bool? ClaimWorks
        {
            get => _claimWorks;
            set { _claimWorks = value; OnPropertyChanged(); }
        }
        public int? ProcurementStateId
        {
            get => _procurementStateId;
            set { _procurementStateId = value; OnPropertyChanged(); }
        }
        public decimal? CalculatingAmount
        {
            get => _calculatingAmount;
            set { _calculatingAmount = value; OnPropertyChanged(); }
        }
        public decimal? PurchaseAmount
        {
            get => _purchaseAmount;
            set { _purchaseAmount = value; OnPropertyChanged(); }
        }
        public string? PassportOfMonitor
        {
            get => _passportOfMonitor;
            set { _passportOfMonitor = value; OnPropertyChanged(); }
        }
        public string? PassportOfPc
        {
            get => _passportOfPc;
            set { _passportOfPc = value; OnPropertyChanged(); }
        }
        public string? PassportOfMonoblock
        {
            get => _passportOfMonoblock;
            set
            {
                _passportOfMonoblock = value; OnPropertyChanged();
            }
        }
        public string? PassportOfNotebook
        {
            get => _passportOfNotebook;
            set { _passportOfNotebook = value; OnPropertyChanged(); }
        }
        public string? PassportOfAw
        {
            get => _passportOfAw;
            set { _passportOfAw = value; OnPropertyChanged(); }
        }
        public string? PassportOfUps
        {
            get => _passportOfUps;
            set { _passportOfUps = value; OnPropertyChanged(); }
        }
        public bool? IsProcurementBlocked
        {
            get => _isProcurementBlocked;
            set { _isProcurementBlocked = value; OnPropertyChanged(); }
        }
        public bool? IsPurchaseBlocked
        {
            get => _isPurchaseBlocked;
            set { _isPurchaseBlocked = value; OnPropertyChanged(); }
        }
        public bool? IsCalculationBlocked
        {
            get => _isCalculationBlocked;
            set { _isCalculationBlocked = value; OnPropertyChanged(); }
        }
        public int? ProcurementUserId
        {
            get => _procurementUserId;
            set { _procurementUserId = value; OnPropertyChanged(); }
        }
        public int? PurchaseUserId
        {
            get => _purchaseUserId;
            set { _purchaseUserId = value; OnPropertyChanged(); }
        }
        public int? CalculatingUserId
        {
            get => _calculatingUserId;
            set { _calculatingUserId = value; OnPropertyChanged(); }
        }
        public int? ParentProcurementId
        {
            get => _parentProcurementId;
            set { _parentProcurementId = value; OnPropertyChanged(); }
        }

        public virtual ICollection<ComponentCalculation> ComponentCalculations
        {
            get => _componentCalculations;
            set { _componentCalculations = value; OnPropertyChanged(); }
        }

        [NotMapped]
        public ObservableCollection<ComponentStateCount> ComponentStates
        {
            get => _componentStates;
            set { _componentStates = value; OnPropertyChanged(); }
        }

        public virtual CommisioningWork? CommissioningWorks
        {
            get => _commissioningWorks;
            set { _commissioningWorks = value; OnPropertyChanged(); }
        }
        public virtual City? City
        {
            get => _city;
            set { _city = value; OnPropertyChanged(); }
        }
        public virtual ExecutionState? ExecutionState
        {
            get => _executionState;
            set { _executionState = value; OnPropertyChanged(); }
        }
        public virtual Law? Law
        {
            get => _law;
            set { _law = value; OnPropertyChanged(); }
        }
        public virtual LegalEntity? LegalEntity
        {
            get => _legalEntity;
            set { _legalEntity = value; OnPropertyChanged(); }
        }
        public virtual Method? Method
        {
            get => _method;
            set { _method = value; OnPropertyChanged(); }
        }
        public virtual Minopttorg? Minopttorg
        {
            get => _minopttorg;
            set { _minopttorg = value; OnPropertyChanged(); }
        }
        public virtual Organization? Organization
        {
            get => _organization;
            set { _organization = value; OnPropertyChanged(); }
        }
        public virtual Platform? Platform
        {
            get => _platform;
            set { _platform = value; OnPropertyChanged(); }
        }
        public virtual ProcurementState? ProcurementState
        {
            get => _procurementState;
            set { _procurementState = value; OnPropertyChanged(); }
        }
        public virtual Region? Region
        {
            get => _region;
            set { _region = value; OnPropertyChanged(); }
        }
        public virtual RepresentativeType? RepresentativeType
        {
            get => _representativeType;
            set { _representativeType = value; OnPropertyChanged(); }
        }
        public virtual ShipmentPlan? ShipmentPlan
        {
            get => _shipmentPlan;
            set { _shipmentPlan = value; OnPropertyChanged(); }
        }
        public virtual SignedOriginal? SignedOriginal
        {
            get => _signedOriginal;
            set { _signedOriginal = value; OnPropertyChanged(); }
        }
        public virtual TimeZone? TimeZone
        {
            get => _timeZone;
            set { _timeZone = value; OnPropertyChanged(); }
        }
        public virtual WarrantyState? WarrantyState
        {
            get => _warrantyState;
            set { _warrantyState = value; OnPropertyChanged(); }
        }


        // Event handler for property changes

        // Event handler for property changes
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string ToInsert()
        {
            return $"{RequestUri}, '{Number}', {LawId}, '{Object}', {InitialPrice}, {OrganizationId}, {(MethodId != null ? $"{MethodId}" : "null")}, {(PlatformId != null ? $"{PlatformId}" : "null")}, {(Location != null ? $"'{Location}'" : "null")}, {(PostingDate != null ? $"'{PostingDate}'" : "null")}, {(StartDate != null ? $"'{StartDate}'" : "null")}, {(Deadline != null ? $"'{Deadline}'" : "null")}, {(TimeZoneId != null ? $"{TimeZoneId}" : "null")}, {(Securing != null ? $"'{Securing}'" : "null")}, {(Enforcement != null ? $"'{Enforcement}'" : "null")}, {(Warranty != null ? $"'{Warranty}'" : "null")}, {(RegionId != null ? $"{RegionId}" : "null")}";
        }

        public string ToUpdate()
        {
            return $"\"RequestUri\" = {RequestUri}, \"Number\" = '{Number}', \"LawId\" = {LawId}, \"Object\" = '{Object}', \"InitialPrice\" = {InitialPrice}, \"OrganizationId\" = {OrganizationId}, \"MethodId\" = {(MethodId != null ? $"{MethodId}" : "null")}, \"PlatformId\" = {(PlatformId != null ? $"{PlatformId}" : "null")}, \"Location\" = {(Location != null ? $"'{Location}'" : "null")}, \"PostingDate\" = {(PostingDate != null ? $"'{PostingDate}'" : "null")}, \"StartDate\" = {(StartDate != null ? $"'{StartDate}'" : "null")}, \"Deadline\" = {(Deadline != null ? $"'{Deadline}'" : "null")}, \"TimeZoneId\" = {(TimeZoneId != null ? $"{TimeZoneId}" : "null")}, \"Securing\" = {(Securing != null ? $"'{Securing}'" : "null")}, \"Enforcement\" = {(Enforcement != null ? $"'{Enforcement}'" : "null")}, \"Warranty\" = {(Warranty != null ? $"'{Warranty}'" : "null")}, \"RegionId\" = {(RegionId != null ? $"{RegionId}" : "null")}";
        }

        public decimal GetFinalAmount()
        {
            if (ReserveContractAmount.HasValue && ReserveContractAmount.Value != 0)
            {
                return ReserveContractAmount.Value;
            }
            else if (ContractAmount.HasValue && ContractAmount.Value != 0)
            {
                return ContractAmount.Value;
            }
            else { return 0; }
        }
    }
    public class ComponentStateCount
    {
        public string? State { get; set; }
        public int Count { get; set; }
    }


    public enum RejectionReason
    {
        [Description("Расчет")]
        Calculation,

        [Description("Подача")]
        Submission,

        [Description("Реестр")]
        Registry
    }
}
