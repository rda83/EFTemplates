
namespace EFTemplates.EntityRelationshipsExample.Models
{
    class PaymentOrder
    {
        public long Id { get; set; }
        public PaymentOrdersRegister PaymentOrdersRegister { get; set; }
        public long RegisterCode { get; set; }
    }
}
