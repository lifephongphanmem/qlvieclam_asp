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
        public IActionResult Index(string loai,string huyen,string xa,string kydieutra)
        {
            var Madv = "";
            if(string.IsNullOrEmpty(xa) ) { 
                Madv = _db.dmdonvi.FirstOrDefault()!.madv!;
            }
            else
            {
                Madv= _db.dmdonvi.Where(x=>x.madiaban== xa).FirstOrDefault()!.madv!;
            }

            kydieutra = (string.IsNullOrEmpty(kydieutra)) ? "2022" : kydieutra;
            var model = _db.nhankhau.Where(x=>x.madv==Madv && x.kydieutra==kydieutra).AsQueryable();
            
            if (loai == "vieclam")
            {
                model = model.Where(x => x.nguoicovieclam == "1");
            }
            if(loai== "thatnghiep")
            {
                model = model.Where(x => x.thatnghiep == "1");
            }
            if(loai== "hdkt")
            {
                model = model.Where(x => x.khongthamgiahdkt == "1");
            }
            /*if (loai == null)
            {
                model = model.Where(x => x.nguoicovieclam == "1");
            }*/
            ViewData["loai"] = loai;
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
    }
}

