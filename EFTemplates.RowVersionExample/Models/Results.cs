using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTemplates.RowVersionExample.Models
{
    class Results
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public decimal TotalAmount { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
