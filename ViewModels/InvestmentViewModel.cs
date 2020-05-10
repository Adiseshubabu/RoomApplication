using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class InvestmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } // Invester name
        public string InvestmentPurpose { get; set; }
        public Decimal Amount { get; set; }
        public DateTime Date { get; set; }

    }
}
