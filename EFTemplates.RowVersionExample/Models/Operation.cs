using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTemplates.RowVersionExample.Models
{
    class Operation
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public decimal Amount { get; set; }
    }
}
