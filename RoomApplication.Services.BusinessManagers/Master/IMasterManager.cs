using RoomApplication.Services.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomApplication.Services.BusinessManagers.Master
{
   public interface IMasterManager
    {
        int SaveInvestment(Investment investment);
    }
}
