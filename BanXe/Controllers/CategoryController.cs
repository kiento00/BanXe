using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanXe.Context;

namespace BanXe.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index()
        {

            var lstCategory = data.LoaiSanPhams.ToList();
            return View(lstCategory);
        }


        public ActionResult LSP (int id)
        {  var lstSanpham=data.SanPhams.Where(n=>n.MaLoaiSP== id).ToList();
            return View(lstSanpham);

        }
    }
}