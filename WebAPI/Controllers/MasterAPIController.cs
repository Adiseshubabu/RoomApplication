using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("Master")]
    public class MasterAPIController : RoomAPIController
    {
        [HttpPost]
        [Route("Save")]
        public IHttpActionResult Save(Investment investment)
        {
            return Ok(MasterManager.SaveOrUpdate(investment));
        }
    }
}
