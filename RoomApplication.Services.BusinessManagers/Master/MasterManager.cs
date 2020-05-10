using RoomApplication.Services.BusinessEntities;
using RoomApplication.Services.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomApplication.Services.BusinessManagers.Master
{
   public class MasterManager : IMasterManager
    {
        public IDynamicRepository DynamicRepository { get;  set; }

        public int SaveInvestment(Investment investment)
        {
            return DynamicRepository.Add<Investment>("USP_SaveInvestments", investment);
        }
    }
}
