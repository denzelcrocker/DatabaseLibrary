using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.Entities.ProcurementProperties
{
    public partial class DeletedProcurement
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime DeleteDate { get; set; }
    }
}
