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
using System.Text.RegularExpressions;

namespace Coolant.Controllers
{
    public class HomeController : Controller
    {
        private static log4net.ILog Log { get; set; }
        public static readonly ILog log2 = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        ILog log = log4net.LogManager.GetLogger(typeof(HomeController));
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);

        private readonly LeanWorkCenterContext _leanworkcenterContext;
        //private readonly string _currentUserBadge = HttpContext.Current.User.Identity.Name;
        //private CurrentUserContext _currentUserContext;
        public LeanWorkCenterVM leanWorkCenter = new LeanWorkCenterVM();
        public UsersVM user = new UsersVM();
        private object LWC;


        public HomeController()
        {
            _leanworkcenterContext = new LeanWorkCenterContext();
        }

        public ActionResult Index()
        {
            try
            {
                _leanworkcenterContext.GetAllLeanWorkCenter();

                //int a = 3;
                //int b = 0;
                //int c = a / b;

                //user = _currentUserContext.GetCurrentUser();
                user.Name = "Martin Serrano";
                if (HttpContext.Request.Url != null)
                {
                    // Generate the correct path for services to call
                    string url = HttpContext.Request.Url.AbsolutePath;

                    //if (!user.isAllowed)
                    //{
                    //    return RedirectToAction("Unauthorized", "Home");
                    //}

                    if (url.Last() != '/')
                    {
                        url += "/";
                    }

                    //If URL contains path, redirect to same action again to remove path on URL
                    if (url.ToLower().EndsWith("home/index/", StringComparison.Ordinal))
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    ViewBag.Url = url;
                    ViewBag.user = user;
                    ViewBag.PicturePath = "https://pictures.cat.com/private/pictures/";
                }

                return View();
            }
            catch (Exception exception)
            {
                log.Error(exception);
                Logger.Error(exception);
            }
            return View();
        }



        [HttpPost]
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

            return Json(LWC, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult SearchEmployees(string query)
        {
            var test = EmployeesRepository.SearchEmployees(query);

            return Json(test);
        }

        public ActionResult Test()
        {
            Thread.Sleep(10000);
            return null;
        }

        public ActionResult Angular()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.LoggedUser = EmployeesRepository.GetEmployeeByBadge(User.Identity.Name);
            }

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}