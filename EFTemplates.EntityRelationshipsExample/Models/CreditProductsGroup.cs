using System.Collections.Generic;

namespace EFTemplates.EntityRelationshipsExample.Models
{
    class CreditProductsGroup
    {
        public long Id { get; set; }
        public List<CreditProduct> CreditProducts { get; set; }
    }
}
