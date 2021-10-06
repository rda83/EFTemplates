using System.Collections.Generic;

namespace EFTemplates.EntityRelationshipsExample.Models
{
    class ServiceEngineer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<ATMMachine> ATMMachines { get; set; }
    }
}
