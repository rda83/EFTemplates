
using System.Collections.Generic;

namespace EFTemplates.EntityRelationshipsExample.Models
{
    class AccountOwner
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }
        public List<SecurityOfficer> SecurityOfficers { get; set; }
        public List<SecurityIncident> SecurityIncidents { get; set; }
        public SecurityKey SecurityKey { get; set; }
    }
}
