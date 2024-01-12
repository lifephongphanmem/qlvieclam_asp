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

namespace QLVL_Binh.Controllers.Admin.Danhmuc.NgheCongViec
{
    public class NgheCongViecController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public NgheCongViecController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("NgheCongViec")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.nghecongviec;
            var lastRecord = _db.nghecongviec.OrderByDescending(e => e.id).FirstOrDefault();
            ViewData["stt"] = lastRecord != null ? lastRecord.stt : 1;
            return View("Views/Admin/Danhmuc/NgheCongViec/Index.cshtml", model);
        }
        [Route("NgheCongViec/Store")]
        [HttpPost]
        public IActionResult Store(string tendm_create, int stt_create)
        {
            var model = new nghecongviec
            {
                tendm = tendm_create,
                stt=stt_create.ToString(),
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            _db.nghecongviec.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "NgheCongViec");
        }
        [Route("NgheCongViec/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.nghecongviec.FirstOrDefault(p => p.id == id);

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
                result += "<label><b>Tên nghề công việc</b></label>";
                result += "<input type='text' id='tendm_edit' name='tendm_edit' value='" + model.tendm + "' class='form-control'/>";
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
        [Route("NgheCongViec/Update")]
        [HttpPost]
        public IActionResult Update(string tendm_edit, int stt_edit,int id_edit)
        {
            var model = _db.nghecongviec.FirstOrDefault(t => t.id == id_edit);
            if (model != null)
            {
                model.tendm = tendm_edit;
                model.stt = stt_edit.ToString();
                model.updated_at = DateTime.Now;
                _db.nghecongviec.Update(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "NgheCongViec");
        }
        [Route("NgheCongViec/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.nghecongviec.FirstOrDefault(t => t.id == id_delete);
            if (model != null)
            {
                _db.nghecongviec.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "NgheCongViec");
        }
    }
}
