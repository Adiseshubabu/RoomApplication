using DAL.Repositories;
using Models;
using Room.Common.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class MasterManager : IMasterManager
    {
        [SimpleIoCPropertyInject]
        public IDynamicRepository DynamicRepository { get; set; }

        public int SaveOrUpdate(Investment investment)
        {
            return DynamicRepository.AddOrUpdateDynamic("USP_SaveRoomInvestments", investment);
        }
    }
}
