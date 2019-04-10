using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using SolarApp.DataAccess.Repositories;
using SolarApp.Context;
using System.Threading;
using Coolant.BLL.Contexts;
using Coolant.BLL.ViewModels;
using Newtonsoft.Json;

namespace Coolant.Controllers
{
    public class LeanWorkCenterController : Controller
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);

        private readonly LeanWorkCenterContext _leanworkcenterContext;
        public LeanWorkCenterVM leanWorkCenter = new LeanWorkCenterVM();
        private object LWC;

        public LeanWorkCenterController()
        {
            _leanworkcenterContext = new LeanWorkCenterContext();
        }


        public ActionResult LeanWorkCenterPage()
        {


            //return View();
            //return Json(_leanworkcenterContext.GetAllLeanWorkCenter());
            //return Content(JsonConvert.SerializeObject(_leanworkcenterContext.GetAllLeanWorkCenter()), "application/json");

            //return Json(LWC, JsonRequestBehavior.AllowGet);

            return View();
        }

        public ActionResult GetAllLWC()
        {
            try
            {
                LWC = _leanworkcenterContext.GetAllLeanWorkCenter();
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
            }

            return Json(LWC, JsonRequestBehavior.AllowGet);

        }


        public ActionResult Index()
        {

            try
            {
                LWC = _leanworkcenterContext.GetAllLeanWorkCenter();
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
            }

            return Json(LWC, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLeanWorkCenter()
        {
            try
            {
                LWC = _leanworkcenterContext.GetAllLeanWorkCenter();
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
            }

            //return View();
            //return Json(_leanworkcenterContext.GetAllLeanWorkCenter());
            //return Content(JsonConvert.SerializeObject(_leanworkcenterContext.GetAllLeanWorkCenter()), "application/json");

            return Json(LWC, JsonRequestBehavior.AllowGet);
        }


    }
}