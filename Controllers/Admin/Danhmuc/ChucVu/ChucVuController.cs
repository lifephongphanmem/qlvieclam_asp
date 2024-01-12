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

namespace QLVL_Binh.Controllers.Admin.Danhmuc.ChucVu
{
    public class ChucVuController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public ChucVuController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("ChucVu")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.dmchucvu;
            var lastRecord = _db.dmchucvu.OrderByDescending(e => e.id).FirstOrDefault();
            ViewData["stt"] = lastRecord != null ? lastRecord.stt : 1;
            return View("Views/Admin/Danhmuc/ChucVu/Index.cshtml", model);
        }
        [Route("ChucVu/Store")]
        [HttpPost]
        public IActionResult Store(string tencv_create,string mota_create,int stt_create)
        {
            var model = new dmchucvu
            {
                tencv = tencv_create,
                mota=mota_create,
                stt=stt_create.ToString(),
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            _db.dmchucvu.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "ChucVu");
        }
        [Route("ChucVu/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.dmchucvu.FirstOrDefault(p => p.id == id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row text-left'>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Số thứ tự</b></label>";
                result += "<input type='number' id='stt_edit' name='stt_edit' value='" + model.stt + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên chức vụ</b></label>";
                result += "<input type='text' id='tencv_edit' name='tencv_edit' value='" + model.tencv + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mô tả</b></label>";
                result += "<textarea type='text' id='mota_edit' name='mota_edit' cols='12' rows='3' class='form-control'>" + model.mota + "</textarea>";
                result += "</div>";
                result += "</div>";
                result += "</div>";

                result += "<input hidden type='text' id='id_edit' name='id_edit' value='" + model.id + "'/>";
                result += "</div>";

                var data = new { status = "success", message = result };
                return Json(data);
            }
            else
            {
                var data = new { status = "error", message = "Không tìm thấy thông tin cần chỉnh sửa!!!" };
                return Json(data);
            }
        }
        [Route("ChucVu/Update")]
        [HttpPost]
        public IActionResult Update(string tencv_edit, string mota_edit,int id_edit,int stt_edit)
        {
            var model = _db.dmchucvu.FirstOrDefault(t => t.id == id_edit);
            if(model != null) {
                model.tencv = tencv_edit;
                model.mota = mota_edit;
                model.stt = stt_edit.ToString();
                model.updated_at = DateTime.Now;
                _db.dmchucvu.Update(model);
                _db.SaveChanges();
            }
            
            return RedirectToAction("Index", "ChucVu");
        }
        [Route("ChucVu/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.dmchucvu.FirstOrDefault(t => t.id == id_delete);
            if(model != null) {
                _db.dmchucvu.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "ChucVu");
        }
    }
}
