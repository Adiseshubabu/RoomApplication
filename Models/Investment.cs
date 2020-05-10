using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Investment
    {
        public int Id { get; set; }
        public string Name { get; set; } // Invester name
        public string InvestmentPurpose { get; set; }
        public Decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
