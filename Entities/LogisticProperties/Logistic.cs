namespace DatabaseLibrary.Entities.LogisticProperties;

public partial class Logistic
{
    public int Id { get; set; }

    public int ProcurementId { get; set; }

    public string? Readliness { get; set; }

    public string? ArrivalComponents { get; set; }

    public decimal? ComputerAssemblyTime { get; set; }

    public string? ComputerAssemblyState { get; set; }

    public decimal? MonitorAssemblyTime { get; set; }

    public string? MonitorAssemplyState { get; set; }

    public string? AssemblyInfo { get; set; }

    public string? MonitorModelInfo { get; set; }

    public int? AmountPc { get; set; }

    public int? AmountComponent { get; set; }

    public int? AmountInstallingWindows { get; set; }

    public int? AmountInstallingLinux { get; set; }

    public int? ReplacementOrInstallationCmponents { get; set; }

    public int? AmountRegluing { get; set; }

    public int? AmountMonoblock { get; set; }

    public int? AmountMilling { get; set; }

    public int? AmountReworking { get; set; }

    public int? AmountRegluingOrSawing { get; set; }

    public int? AmountRegluingKeyboardOrMouse { get; set; }

    public string? CommentText { get; set; }

    public string? AdditionalWorks { get; set; }

    public decimal? AdditionalWorkTime { get; set; }
}
