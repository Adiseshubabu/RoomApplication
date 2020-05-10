using RoomApplication.Services.DAL.Repositories;
using RoomApplication.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RoomApplication.Services.DAL;
using Commons.Extensions;
using System.Data;

namespace RoomApplication.Controllers
{
    public class MasterController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Investments()
        {
            return View();
        }

        DynamicRepository DynamicRepository = new DynamicRepository();

        public JsonResult SaveInvestments(InvestmentViewModel investmentViewModel)
        {
            int result = SaveInvestment(investmentViewModel);
            return Json(new { success = true, result }, JsonRequestBehavior.AllowGet);
        }

        public int SaveInvestment(InvestmentViewModel investment)
        {
            return DynamicRepository.AddOrUpdateDynamic("USP_SaveInvestments", new { Id = investment.Id, Name = investment.Name });
        }

        public int Delete(List<int> ids)
        {
           return DynamicRepository.DeleteMultiple("USP_SaveInvestments_Delete", new { ids = CustomerDataTableExtensions.ToDataTable<int>(ids, "Id") });
        }
    }
}