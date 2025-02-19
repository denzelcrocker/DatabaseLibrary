using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.Entities.NoRelationship
{
    public partial class AppVersion
    {
        public int Id { get; set; }
        public string VersionNumber { get; set; } = null!;
        public bool IsMandatory { get; set; } 
        public DateTime ReleaseDate { get; set; }
    }
}
