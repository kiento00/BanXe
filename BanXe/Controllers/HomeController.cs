using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanXe.Context;
using BanXe.Models;

namespace BanXe.Controllers
{
    public class HomeController : Controller
    {   
        MyDataDataContext data = new MyDataDataContext();
        
        
        public ActionResult Index()
        {
            HomeModel model = new HomeModel();
            model.ListLoaiSanPham =data.LoaiSanPhams.ToList();
            model.ListSanPham = data.SanPhams.ToList();
            return View(model);
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
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, TaiKhoan kh)
        {
           
            var SDT = collection["SDT"];
            var email = collection["Email"];
            var matkhau = collection["MatKhau"];
            var MatKhauXacNhan = collection["MatKhauXacNhan"];
            var HoTen = collection["HoTen"];
           var NgayTao = String.Format("{0:MM/dd/yyyy}", collection["NgayTao"]);
           
            if (String.IsNullOrEmpty(MatKhauXacNhan))
            {
                ViewData["NhapMKXN"] = "Phải nhập mật khẩu xác nhận";
            }
            else
            {
                if (!matkhau.Equals(MatKhauXacNhan))
                {
                    ViewData["MatKhauGiongNhau"] = "Mật khẩu và mật khẩu xác nhận giống nhau";
                }
                else
                {
                    
                    kh.SDT = SDT;
                    kh.Email = email;
                    kh.MatKhau = matkhau;
                    
                    kh.HoTen = HoTen;
                    kh.NgayTao = DateTime.Parse(NgayTao);
                    data.TaiKhoans.InsertOnSubmit(kh);
                    data.SubmitChanges();
                    return RedirectToAction("DangNhap");
                }
            }
            return this.DangKy();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var Email = collection["Email"];
            var MatKhau = collection["MatKhau"];
            TaiKhoan kh = data.TaiKhoans.SingleOrDefault(n => n.Email == Email && n.MatKhau == MatKhau);
            if (kh != null)
            {
                ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                Session["TaiKhoan"] = kh;
            }
            else
            {
                ViewBag.ThongBao = "Email hoặc mật khẩu không đúng";
            }
            return RedirectToAction("Index", "Home");
        }

        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("DangNhap");
        }




    }



}