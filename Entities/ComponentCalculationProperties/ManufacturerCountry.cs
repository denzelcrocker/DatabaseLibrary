using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.Entities.ComponentCalculationProperties;

public partial class ManufacturerCountry
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<Manufacturer> Manufacturers { get; } = new List<Manufacturer>();
}
