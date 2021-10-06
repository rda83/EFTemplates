
namespace EFTemplates.EntityRelationshipsExample.Models
{
    class Account
    {
        public long Id { get; set; }
        public long AccountOwnerId { get; set; }
        public AccountOwner AccountOwner { get; set; }
        public string AccountNumber { get; set; }
    }
}
