using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomApplication.UI.ViewModels
{
    public class InvestmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InvestmentPurpose { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Test { get; set; }

        public dynamic investment()
        {
            return new
            {
                Id = Id,
            };
        }
    }

   
}
