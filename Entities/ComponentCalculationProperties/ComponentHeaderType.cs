
namespace DatabaseLibrary.Entities.ComponentCalculationProperties
{
    public partial class ComponentHeaderType
    {
        public int Id { get; set; }
        public string Kind { get; set; } = null!;

        public virtual ICollection<ComponentCalculation> ComponentCalculations { get; } = new List<ComponentCalculation>();
    }
}
