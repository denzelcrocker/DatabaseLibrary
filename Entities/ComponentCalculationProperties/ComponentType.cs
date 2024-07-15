namespace DatabaseLibrary.Entities.ComponentCalculationProperties;

public partial class ComponentType
{
    public int Id { get; set; }
    public string Kind { get; set; } = null!;

    public virtual ICollection<ComponentCalculation> ComponentCalculations { get; } = new List<ComponentCalculation>();
    public virtual ICollection<PredefinedComponent> PredefinedComponent { get; } = new List<PredefinedComponent>();
}