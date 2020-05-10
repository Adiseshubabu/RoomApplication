using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomApplication.Services.BusinessEntities
{
    public class Investment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InvestmentPurpose { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
