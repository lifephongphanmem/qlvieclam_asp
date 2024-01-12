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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace QLVL_Binh.Controllers.Admin.TuyenDung
{
    public class TuyenDungController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public TuyenDungController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("TuyenDung")]
        [HttpGet]
        public IActionResult Index(int user)
        {
            var model = (from td in _db.tuyendung.Where(x => x.user == user)
                         join vt in _db.vitrituyendung
                         on td.id equals vt.idtuyendung
                         select new VM_TuyenDung
                         {
                             id = td.id,
                             noidung = td.noidung!,
                             name = vt.name!,
                             soluong = vt.soluong,
                             datuyen = td.datuyen,
                             datuyentutt = td.datuyentutt,
                             state = td.state,
                             thoihan = td.thoihan
                         });
            //var model = _db.tuyendung.Where(x => x.user == user);

            /*Luồng xử lý tuyendung+vitrituyendung
                Sẽ ko dự a vào id hay mã gì cả mà thay vào đó là state
                Khi tạo mới store trong vttd thì state là CXD
                Và đọc table ra sẽ dựa theo state đó
                Nếu tạo mới store trong td mới chuyển XD
                Đọc trong index td nếu có vttd có state là CXD thì xóa


            ***nhưng vẫn có xung đột,vì nếu 2 user cùng tạo vttd thì 1 trong 2 người xóa data=>lỗi
            *cho cai idtuyendung la 1 ma datetime xog update thi lay id của tuyendung
            =>nhưng vẫn chưa tối ưu,vẫn có thể bị người tạo trước tạo data=>sai id
            ==> sử dụng matuyendung thay vì...

            NHƯNG VẪN KO GIẢI QUYẾT ĐC CÁI DELETE CXD KHI KHÔNG TẠO HỒ SƠ TUYỂN DỤNG    
            */

            //var vttd = _db.vitrituyendung.Where(x => x.state == "CXD");
            var vttd = _db.vitrituyendung.Where(x => x.state == "CXD");
            if(vttd != null) { _db.vitrituyendung.RemoveRange(vttd); }
            
            _db.SaveChanges();

            ViewData["doanhnghiep"] = _db.company.Where(x => x.user == user).FirstOrDefault()!.name;
            ViewData["user"] = user;
            return View("Views/Admin/Doanhnghiep/TuyenDung/Index.cshtml", model);

        }
        [Route("TuyenDung/Xetduyet")]
        [HttpPost]
        public IActionResult Xetduyet(int id_Xetduyet, int user_Xetduyet)
        {
            var model = _db.tuyendung.Where(x => x.id == id_Xetduyet).FirstOrDefault();
            model!.state = 1;
            _db.tuyendung.Update(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "TuyenDung", new { user_Xetduyet });

        }

        [Route("TuyenDung/Baocao")]
        [HttpPost]
        public IActionResult Baocao(int id_Baocao, int user_Baocao)
        {
            var model = _db.tuyendung.Where(x => x.id == id_Baocao).FirstOrDefault();
            model!.state = 2;
            _db.tuyendung.Update(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "TuyenDung", new { user_Baocao });

        }
        [Route("TuyenDung/Create")]
        [HttpGet]
        public IActionResult Create()
        {
            //ViewData["idtuyendung"] = _db.tuyendung.OrderByDescending(x => x.id).FirstOrDefault()!.id + 1;
            ViewData["idtuyendung"] = DateTime.Now.ToString("yyMMddssmmHH");
            return View("Views/Admin/Doanhnghiep/TuyenDung/Create.cshtml");
        }
        [Route("TuyenDung/Store")]
        [HttpPost]
        public IActionResult Store(string name, string noidung, DateTime thoihan, string contact, string phonetd, string emailtd, string chucvutd, string yeucau, int soluong, int user,int idtuyendung)
        {
            var model = new tuyendung
            {
                noidung = noidung,
                thoihan = thoihan,
                contact = contact,
                phonetd = phonetd,
                emailtd = emailtd,
                chucvutd = chucvutd,
                yeucau = yeucau,
                user = user,
                state = 0,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            _db.tuyendung.Add(model);
            var vttd = _db.vitrituyendung.Where(x => x.idtuyendung == idtuyendung);
            if (vttd != null)
            {
                foreach (var item in vttd)
                {
                    item.idtuyendung = _db.tuyendung.OrderByDescending(x => x.id).FirstOrDefault()!.id;
                    item.state = "XD";
                }
            }
            _db.vitrituyendung.UpdateRange(vttd!);
            _db.SaveChanges();
            return RedirectToAction("Index", "TuyenDung", new { user });
        }
        /*
         need build additional a column "abroad" for identify type a worker insite another nation or in Vietnam 
        compare model "dsthatnghiep" with "TuyenDung" has state "Dang that nghiep"
         */
    }
}
