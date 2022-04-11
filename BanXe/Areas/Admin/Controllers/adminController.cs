using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanXe.Context;

namespace BanXe.Areas.Admin.Controllers
{
    public class adminController : Controller
    {
        // GET: Admin/Home
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index()
        {
            return View();


        }


    }
}