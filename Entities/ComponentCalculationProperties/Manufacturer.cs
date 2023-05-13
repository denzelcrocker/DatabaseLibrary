namespace DatabaseLibrary.Entities.ComponentCalculationProperties;

public partial class Manufacturer
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<ComponentCalculation> ComponentCalculations { get; } = new List<ComponentCalculation>();
}