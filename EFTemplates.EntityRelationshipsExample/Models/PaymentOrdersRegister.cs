using System.Collections.Generic;

namespace EFTemplates.EntityRelationshipsExample.Models
{
    class PaymentOrdersRegister
    {
        public long Id { get; set; }
        public List<PaymentOrder> PaymentOrders { get; set; }
    }
}
