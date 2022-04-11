using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BanXe.Context;

namespace BanXe.Models
{
    public class HomeModel
    {
        public List<SanPham> ListSanPham { get; set; }
        public List<LoaiSanPham> ListLoaiSanPham { get; set; }

    }
}