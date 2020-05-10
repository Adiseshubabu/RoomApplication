using RoomApplication.Services.BusinessEntities;
using RoomApplication.Services.BusinessManagers.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RoomApplication.Services.WebAPI.Controllers
{
    [RoutePrefix("Master")]
    public class MasterApiController : RoomApplicationApiController
    {
        [HttpPost]
        [Route("SaveInvestment")]
        public IHttpActionResult SaveInvestment(Investment investment)
        {
            return Ok(MasterManager.SaveInvestment(investment));
        }
    }
}
