using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanXe.Context;

namespace BanXe.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {   
        
        // GET: Admin/Products
        MyDataDataContext data = new MyDataDataContext();   
        public ActionResult Index()
         {   

            var lstProduct = data.SanPhams.ToList();
             return View(lstProduct);
     
        
        
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SanPham s)
        {
            var E_TenSP = collection["TenSP"];
            var E_MoTa1 = collection["MoTa1"];
            var E_MoTa2 = collection["MoTa2"];
            var E_Hinh = collection["Hinh"];
            var E_GiaBan = Convert.ToInt32(collection["GiaBan"]);
            var E_NgayCapNhat = Convert.ToDateTime(collection["NgayCapNhat"]);
            var E_SoLanMua = Convert.ToInt32(collection["SoLanMua"]);
            var E_TrangThai = Convert.ToBoolean(collection["TrangThai"]);
            var E_TonKho = Convert.ToInt32(collection["TonKho"]);
            var E_SPMoi = Convert.ToInt32(collection["SPMoi"]);
            var E_MaLoaiSP = Convert.ToInt32(collection["MaLoaiSP"]);
            var E_MaNCC = Convert.ToInt32(collection["MaNCC"]);
            if (string.IsNullOrEmpty(E_TenSP))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.TenSP = E_TenSP.ToString();
                s.MoTa1 = E_MoTa1.ToString();
                s.MoTa2 = E_MoTa2.ToString();
                s.Hinh = E_Hinh.ToString();
                s.GiaBan = E_GiaBan;
                s.NgayCapNhat = E_NgayCapNhat;
                s.SolanMua = E_SoLanMua;
                s.TrangThai=E_TrangThai;
                s.TonKho = E_TonKho;
                s.SPMoi = E_SPMoi;
                s.MaLoaiSP = E_MaLoaiSP;
                s.MaNCC = E_MaNCC;
                data.SanPhams.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/assets/images/" + file.FileName));
            return "/Content/assets/images/" + file.FileName;
        }








    }
}