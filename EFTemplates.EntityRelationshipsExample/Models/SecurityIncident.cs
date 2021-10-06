using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTemplates.EntityRelationshipsExample.Models
{
    class SecurityIncident
    {
        public long Id { get; set; }
        public List<AccountOwner> AccountOwners { get; set; }
    }
}
