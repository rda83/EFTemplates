using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTemplates.EntityRelationshipsExample.Models
{
    class AccountOwnerSecurityIncident
    {
        public long AccountOwnerId { get; set; }
        public long SecurityIncidentId { get; set; }
        public DateTime DateOfIncident { get; set; }
    }
}
