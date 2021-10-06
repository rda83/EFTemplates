using System.Collections.Generic;

namespace EFTemplates.EntityRelationshipsExample.Models
{
    class BankCellsStorage
    {
        public long Id { get; set; }
        public List<BankDepositBox> BankDepositBoxes { get; set; }
        public string Addres { get; set; }
    }
}
