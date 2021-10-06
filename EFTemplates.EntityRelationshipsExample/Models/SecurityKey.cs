using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTemplates.EntityRelationshipsExample.Models
{
    class SecurityKey
    {
        public long Id { get; set; }
        public long AccountOwner { get; set; }
    }
}
