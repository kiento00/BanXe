using BanXe.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanXe.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Details(int id)
        {      var lstSanPham =data.SanPhams.Where(n=>n.MaSP==id).FirstOrDefault();
            return View(lstSanPham);
        }



        
    }
}