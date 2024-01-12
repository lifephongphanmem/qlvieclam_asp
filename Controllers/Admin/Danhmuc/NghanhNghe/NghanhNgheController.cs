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

namespace QLVL_Binh.Controllers.Admin.Danhmuc.NghanhNghe
{
    public class NghanhNgheController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public NghanhNgheController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("NghanhNghe")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.dmnganhnghe;
            var lastRecord = _db.dmnganhnghe.OrderByDescending(e => e.id).FirstOrDefault();
            ViewData["stt"] = lastRecord != null ? lastRecord.stt : 1;
            return View("Views/Admin/Danhmuc/NghanhNghe/Index.cshtml", model);
        }
        [Route("NghanhNghe/Store")]
        [HttpPost]
        public IActionResult Store(string madm_create, string tendm_create, int stt_create)
        {
            var model = new dmnganhnghe
            {
                madm = madm_create,
                tendm = tendm_create,
                stt = stt_create,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            _db.dmnganhnghe.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "NghanhNghe");
        }
        [Route("NghanhNghe/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.dmnganhnghe.FirstOrDefault(p => p.id == id);

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
                result += "<label><b>Mã nghành nghề</b></label>";
                result += "<input type='text' id='madm_edit' name='madm_edit' value='" + model.madm + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên nghành nghề</b></label>";
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
        [Route("NghanhNghe/Update")]
        [HttpPost]
        public IActionResult Update(string madm_edit, string tendm_edit, int id_edit, int stt_edit)
        {
            var model = _db.dmnganhnghe.FirstOrDefault(t => t.id == id_edit);
            if (model != null)
            {
                model.madm = madm_edit;
                model.tendm = tendm_edit;
                model.stt = stt_edit;
                model.updated_at = DateTime.Now;
                _db.dmnganhnghe.Update(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "NghanhNghe");
        }
        [Route("NghanhNghe/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.dmnganhnghe.FirstOrDefault(t => t.id == id_delete);
            if (model != null)
            {
                _db.dmnganhnghe.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "NghanhNghe");
        }
    }
}
