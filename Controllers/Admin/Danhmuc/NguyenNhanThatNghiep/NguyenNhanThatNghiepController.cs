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

namespace QLVL_Binh.Controllers.Admin.Danhmuc.NguyenNhanThatNghiep
{
    public class NguyenNhanThatNghiepController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public NguyenNhanThatNghiepController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("NguyenNhanThatNghiep")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.nguyennhanthatnghiep;
            var lastRecord = _db.nguyennhanthatnghiep.OrderByDescending(e => e.id).FirstOrDefault();
            ViewData["stt"] = lastRecord != null ? lastRecord.stt : 1;
            return View("Views/Admin/Danhmuc/NguyenNhanThatNghiep/Index.cshtml", model);
        }
        [Route("NguyenNhanThatNghiep/Store")]
        [HttpPost]
        public IActionResult Store(string tennn_create, int stt_create)
        {
            var model = new nguyennhanthatnghiep
            {
                tennn = tennn_create,
                stt = stt_create.ToString(),
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            _db.nguyennhanthatnghiep.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "NguyenNhanThatNghiep");
        }
        [Route("NguyenNhanThatNghiep/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.nguyennhanthatnghiep.FirstOrDefault(p => p.id == id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row text-left'>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Số thứ tự</b></label>";
                result += "<input type='text' id='stt_edit' name='stt_edit' value='" + model.stt + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên nguyên nhân</b></label>";
                result += "<input type='text' id='tennn_edit' name='tennn_edit' value='" + model.tennn + "' class='form-control'/>";
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
        [Route("NguyenNhanThatNghiep/Update")]
        [HttpPost]
        public IActionResult Update(string tennn_edit,  int id_edit)
        {
            var model = _db.nguyennhanthatnghiep.FirstOrDefault(t => t.id == id_edit);
            if (model != null)
            {
                model.tennn = tennn_edit;
                model.updated_at = DateTime.Now;
                _db.nguyennhanthatnghiep.Update(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "NguyenNhanThatNghiep");
        }
        [Route("NguyenNhanThatNghiep/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.nguyennhanthatnghiep.FirstOrDefault(t => t.id == id_delete);
            if (model != null)
            {
                _db.nguyennhanthatnghiep.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "NguyenNhanThatNghiep");
        }
    }
}
