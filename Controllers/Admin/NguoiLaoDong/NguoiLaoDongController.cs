using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using QLVL_Binh.Database;
using System.Security.Cryptography;
using QLVL_Binh.Helper;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLVL_Binh.Models.Systems;
using Azure.Core;
using QLVL_Binh.ViewModels.Systems;

namespace QLVL_Binh.Controllers.Admin.NguoiLaoDong
{
    public class NguoiLaoDongController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public NguoiLaoDongController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("NguoiLaoDong")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.nguoilaodong;
            return View("Views/Admin/Doanhnghiep/NguoiLaoDong/Index.cshtml", model);

        }

        [Route("NguoiLaoDong/DoanhNghiep")]
        [HttpGet]
        public IActionResult DoanhNghiep()
        {
            var model = (from nguoild in _db.nguoilaodong
                         join dn in _db.company
                         on nguoild.company equals dn.id
                         select new nguoilaodong
                         {
                             hoten = nguoild.hoten,
                             ccnd = nguoild.ccnd,
                             ngaysinh = nguoild.ngaysinh,
                             tinh = nguoild.tinh,
                             tendn = dn.name!,
                         });
            return View("Views/Admin/Doanhnghiep/NguoiLaoDong/Index.cshtml", model);

        }

        [Route("NguoiLaoDong/NguoiNuocNgoai")]
        [HttpGet]
        public IActionResult NguoiNuocNgoai()
        {
            var model = (from nguoild in _db.nguoilaodong.Where(x=>x.nation!="VN")
                         join dn in _db.company
                         on nguoild.company equals dn.id
                         select new nguoilaodong
                         {
                             hoten = nguoild.hoten,
                             ccnd = nguoild.ccnd,
                             ngaysinh = nguoild.ngaysinh,
                             tinh = nguoild.tinh,
                             tendn = dn.name!,
                         });
            return View("Views/Admin/Doanhnghiep/NguoiLaoDong/Index.cshtml", model);

        }

        [Route("NguoiLaoDong/LamViecNuocNgoai")]
        [HttpGet]
        public IActionResult LamViecNuocNgoai()
        {
            var model = (from nguoild in _db.nguoilaodong.Where(x => x.nation != "VN")
                         join dn in _db.company
                         on nguoild.company equals dn.id
                         select new nguoilaodong
                         {
                             hoten = nguoild.hoten,
                             ccnd = nguoild.ccnd,
                             ngaysinh = nguoild.ngaysinh,
                             tinh = nguoild.tinh,
                             tendn = dn.name!,
                         });
            return View("Views/Admin/Doanhnghiep/NguoiLaoDong/Index.cshtml", model);

        }

        /*public IActionResult Index(string quoctich)
        {
            var nld = _db.nguoilaodong.AsQueryable();
            if (quoctich != null && quoctich != "")
            {
                nld = nld.Where(x => x.nation == "VN");
                ViewData["title"] = "NGƯỜI LAO ĐỘNG";
            }
            else
            {
                nld = nld.Where(x => x.nation != "VN");

                ViewData["title"] = "NGƯỜI LAO ĐỘNG NƯỚC NGOÀI";
            }
            var model = (from nguoild in nld
                         join dn in _db.company
                         on nguoild.company equals dn.id
                         select new nguoilaodong
                         {
                             hoten = nguoild.hoten,
                             ccnd = nguoild.ccnd,
                             ngaysinh = nguoild.ngaysinh,
                             tinh = nguoild.tinh,
                             tendn = dn.name!,
                         });

            return View("Views/Admin/Doanhnghiep/NguoiLaoDong/Index.cshtml", model);

        }*/
        /*
         need build additional a column "abroad" for identify type a worker insite another nation or in Vietnam 
        compare model "dsthatnghiep" with "nguoilaodong" has state "Dang that nghiep"
         */
    }
}
