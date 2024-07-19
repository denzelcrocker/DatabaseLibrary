using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.Entities.ProcurementProperties
{
    public partial class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Procurement> Procurements { get; } = new List<Procurement>();
    }
}
