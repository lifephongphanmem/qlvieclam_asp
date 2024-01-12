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

namespace QLVL_Binh.Controllers.Admin.Danhmuc.LoaiLaoDong
{
    public class LoaiLaoDongController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public LoaiLaoDongController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("LoaiLaoDong")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.dmloailaodong;
            var lastRecord = _db.dmloailaodong.OrderByDescending(e => e.id).FirstOrDefault();
            ViewData["stt"] = lastRecord != null ? lastRecord.stt : 1;
            return View("Views/Admin/Danhmuc/LoaiLaoDong/Index.cshtml", model);
        }
        [Route("LoaiLaoDong/Store")]
        [HttpPost]
        public IActionResult Store( string tenlld_create, string trangthai_create, int stt_create)
        {
            var model = new dmloailaodong
            {
                tenlld = tenlld_create,
                trangthai = trangthai_create,
                stt = stt_create,
                madmlld = DateTime.Now.ToString("yyMMddssmmHH"),
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            _db.dmloailaodong.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "LoaiLaoDong");
        }
        [Route("LoaiLaoDong/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.dmloailaodong.FirstOrDefault(p => p.id == id);

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
                result += "<label><b>Tên loại lao động</b></label>";
                result += "<input type='text' id='tenlld_edit' name='tenlld_edit' value='" + model.tenlld + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Trạng thái</b></label>";
                result += "<select class='form-control' id='trangthai_edit' name='trangthai_edit'>";
                if (model.trangthai == "kh")
                {
                    result += "<option value='kh' selected>Kích hoạt</option>";
                    result += "<option value='kkh'>Không kích hoạt</option>";
                }
                else
                {
                    result += "<option value='kkh' selected>Không kích hoạt</option>";
                    result += "<option value='kh'>Kích hoạt</option>";
                }
                result += "</select>";
                result += "</div></div>";
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
        [Route("LoaiLaoDong/Update")]
        [HttpPost]
        public IActionResult Update(string tenlld_edit, int id_edit, string trangthai_edit)
        {
            var model = _db.dmloailaodong.FirstOrDefault(t => t.id == id_edit);
            if (model != null)
            {
                model.tenlld = tenlld_edit;
                model.stt = id_edit;
                model.trangthai = trangthai_edit;
                model.updated_at = DateTime.Now;
                _db.dmloailaodong.Update(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "LoaiLaoDong");
        }
        [Route("LoaiLaoDong/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.dmloailaodong.FirstOrDefault(t => t.id == id_delete);
            if (model != null)
            {
                _db.dmloailaodong.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "LoaiLaoDong");
        }
    }
}
