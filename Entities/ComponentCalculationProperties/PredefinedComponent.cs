using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.Entities.ComponentCalculationProperties;
public partial class PredefinedComponent
{
    public int Id { get; set; }
    public string ComponentName { get; set; }
    public int ManufacturerId { get; set; }
    public int ComponentTypeId { get; set; }
    public decimal Price { get; set; }


    public virtual Manufacturer Manufacturer { get; set; } = null!;
    public virtual ComponentType ComponentType { get; set; } = null!;

}
