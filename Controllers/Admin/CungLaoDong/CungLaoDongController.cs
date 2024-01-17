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
using QLVL_Binh.ViewModels.Systems.VM_DoanhNghiep;
using Azure.Core;

namespace QLVL_Binh.Controllers.Admin.CungLaoDong
{
    public class CungLaoDongController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public CungLaoDongController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("CungLaoDong")]
        [HttpGet]
        public IActionResult Index(string tinhtrang, string huyen, string xa, string kydieutra)
        {
            var Madv = "";
            if (string.IsNullOrEmpty(xa))
            {
                Madv = _db.dmdonvi.FirstOrDefault()!.madv!;
            }
            else
            {
                Madv = _db.dmdonvi.Where(x => x.madiaban == xa).FirstOrDefault()!.madv!;
            }

            kydieutra = (string.IsNullOrEmpty(kydieutra)) ? "2022" : kydieutra;
            var model = _db.nhankhau.Where(x => x.madv == Madv && x.kydieutra == kydieutra).AsQueryable();
            if (string.IsNullOrEmpty(tinhtrang))
            {
                if (tinhtrang == "1")
                {
                    model = model.Where(x => x.tinhtranghdkt == "1");
                }
                if (tinhtrang == "2")
                {
                    model = model.Where(x => x.tinhtranghdkt == "2");
                }
                if (tinhtrang == "3")
                {
                    model = model.Where(x => x.tinhtranghdkt == "3");
                }
            }
            /*if (loai == null)
            {
                model = model.Where(x => x.nguoicovieclam == "1");
            }*/
            ViewData["tinhtrang"] = tinhtrang;
            ViewData["mahuyen"] = huyen;
            ViewData["maxa"] = xa;
            ViewData["kydieutra"] = kydieutra;
            //ViewData["Tinh"] = _db.danhmuchanhchinh.Where(t => string.IsNullOrEmpty(t.parent) || t.parent == "0");
            ViewData["Huyen"] = _db.danhmuchanhchinh.Where(t => t.capdo == "H");
            if (string.IsNullOrEmpty(xa))
            {
                ViewData["Xa"] = _db.danhmuchanhchinh.Where(t => t.capdo == "X");
            }
            else
            {
                ViewData["Xa"] = _db.danhmuchanhchinh.Where(t => t.capdo == "X" && t.parent == huyen);
            }
            return View("Views/Admin/CungLaoDong/Index.cshtml", model);

        }

        [Route("CungLaoDong/ThongTin_Print")]
        [HttpGet]
        public ActionResult ThongTin_Print(long id,long xa) {
            var model=_db.nhankhau.FirstOrDefault(x=>x.id== id);
            ViewData["hoten"] = model!.hoten;
            ViewData["ngaysinh"] = model!.ngaysinh;
            ViewData["cccd"] = model!.cccd;
            ViewData["gioitinh"] = model!.gioitinh;
            ViewData["thuongtru"] = model!.thuongtru;
            ViewData["trinhdogiaoduc"] = model!.trinhdogiaoduc;
            ViewData["chuyenmonkythuat"] = model!.chuyenmonkythuat;
            ViewData["chuyennganh"] = model!.chuyennganh;
            ViewData["doituongtimvieclam"] = model!.doituongtimvieclam;
            ViewData["vieclammongmuon"] = model!.vieclammongmuon;
            ViewData["trinhdochuyenmonmuonhoc"] = model!.trinhdochuyenmonmuonhoc;
            var xaId= _db.danhmuchanhchinh.FirstOrDefault(x => x.id == xa);
            ViewData["xa"] = xaId!.name;
            ViewData["huyen"] = _db.danhmuchanhchinh.FirstOrDefault(x=>x.maquocgia==xaId.parent)!.name;
            return View("Views/Admin/CungLaoDong/ThongTin_Print.cshtml");
        }

        [Route("CungLaoDong/NguoiTimViec")]
        [HttpGet]
        public IActionResult NguoiTimViec(string huyen, string xa, string kydieutra)
        {
            var Madv = "";
            if (string.IsNullOrEmpty(xa))
            {
                Madv = _db.dmdonvi.FirstOrDefault()!.madv!;
            }
            else
            {
                Madv = _db.dmdonvi.Where(x => x.madiaban == xa).FirstOrDefault()!.madv!;
            }

            kydieutra = (string.IsNullOrEmpty(kydieutra)) ? "2022" : kydieutra;
            var model = _db.nhankhau.Where(x => x.madv == Madv && x.kydieutra == kydieutra).AsQueryable();
            /*if (loai == null)
            {
                model = model.Where(x => x.nguoicovieclam == "1");
            }*/
            ViewData["mahuyen"] = huyen;
            ViewData["maxa"] = xa;
            ViewData["kydieutra"] = kydieutra;
            //ViewData["Tinh"] = _db.danhmuchanhchinh.Where(t => string.IsNullOrEmpty(t.parent) || t.parent == "0");
            ViewData["Huyen"] = _db.danhmuchanhchinh.Where(t => t.capdo == "H");
            if (string.IsNullOrEmpty(xa))
            {
                ViewData["Xa"] = _db.danhmuchanhchinh.Where(t => t.capdo == "X");
            }
            else
            {
                ViewData["Xa"] = _db.danhmuchanhchinh.Where(t => t.capdo == "X" && t.parent == huyen);
            }
            return View("Views/Admin/CungLaoDong/Index.cshtml", model);

        }

        [Route("CungLaoDong/Test")]
        [HttpGet]
        public IActionResult Test()
        {
            return View("Views/Admin/CungLaoDong/ThongTin_NguoiTimViec_Print.cshtml");
        }

        [Route("CungLaoDong/DanhSachDieuTra")]
        [HttpGet]
        public IActionResult DanhSachDieuTra(string huyen, string xa)
        {
            var Madv = "";
            if (string.IsNullOrEmpty(xa))
            {
                Madv = _db.dmdonvi.FirstOrDefault()!.madv!;
            }
            else
            {
                Madv = _db.dmdonvi.Where(x => x.madiaban == xa).FirstOrDefault()!.madv!;
            }
            var model = (from kbc in _db.kybaocao
                         join dv in _db.dmdonvi
                         on kbc.madv_x equals dv.madv
                         select new kybaocao
                         {
                             donvi=dv.tendv,
                             noidung=kbc.noidung,
                             kydieutra=kbc.kydieutra,
                         });

            ViewData["mahuyen"] = huyen;
            ViewData["maxa"] = xa;
            ViewData["Huyen"] = _db.danhmuchanhchinh.Where(t => t.capdo == "H");
            if (string.IsNullOrEmpty(xa))
            {
                ViewData["Xa"] = _db.danhmuchanhchinh.Where(t => t.capdo == "X");
            }
            else
            {
                ViewData["Xa"] = _db.danhmuchanhchinh.Where(t => t.capdo == "X" && t.parent == huyen);
            }
            return View("Views/Admin/CungLaoDong/DanhSachDieuTra.cshtml",model);
        }

        [Route("CungLaoDong/DanhSachDieuTra_Create")]
        [HttpGet]
        public IActionResult DanhSachDieuTra_Create()
        {
            return View("Views/Admin/CungLaoDong/TuyenDung/DanhSachDieuTra_Create.cshtml");
        }
        [Route("CungLaoDong/DanhSachDieuTra_Store")]
        [HttpPost]
        public async Task<IActionResult> DanhSachDieuTra_Store()
        {
            return View("Views/Admin/CungLaoDong/TuyenDung/DanhSachDieuTra_Create.cshtml");
        }
    }
}

