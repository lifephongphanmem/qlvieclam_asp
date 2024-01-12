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

namespace QLVL_Binh.Controllers.Admin.Danhmuc.LoaiHinhHDKT
{
    public class LoaiHinhHDKTController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public LoaiHinhHDKTController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("LoaiHinhHDKT")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.dmloaihinhhdkt;
            var lastRecord = _db.dmloaihinhhdkt.OrderByDescending(e => e.id).FirstOrDefault();
            ViewData["stt"] = lastRecord != null ? lastRecord.stt : 1;
            return View("Views/Admin/Danhmuc/LoaiHinhHDKT/Index.cshtml", model);
        }
        [Route("LoaiHinhHDKT/Store")]
        [HttpPost]
        public IActionResult Store( string tenlhkt_create, string mota_create, string trangthai_create, int stt_create)
        {
            var model = new dmloaihinhhdkt
            {
                tenlhkt = tenlhkt_create,
                mota = mota_create,
                trangthai = trangthai_create,
                stt = stt_create,
                madmlhkt = DateTime.Now.ToString("yyMMddssmmHH"),
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            _db.dmloaihinhhdkt.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "LoaiHinhHDKT");
        }
        [Route("LoaiHinhHDKT/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.dmloaihinhhdkt.FirstOrDefault(p => p.id == id);

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
                result += "<label><b>Tên loại hình kinh tế</b></label>";
                result += "<input type='text' id='tenlhkt_edit' name='tenlhkt_edit' value='" + model.tenlhkt + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mô tả</b></label>";
                result += "<textarea type='text' id='mota_edit' name='mota_edit' cols='12' rows='3' class='form-control'>" + model.mota + "</textarea>";
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
        [Route("LoaiHinhHDKT/Update")]
        [HttpPost]
        public IActionResult Update(string tenlhkt_edit, string mota_edit, int id_edit, string trangthai_edit)
        {
            var model = _db.dmloaihinhhdkt.FirstOrDefault(t => t.id == id_edit);
            if (model != null)
            {
                model.tenlhkt = tenlhkt_edit;
                model.mota = mota_edit;
                model.stt = id_edit;
                model.trangthai = trangthai_edit;
                model.updated_at = DateTime.Now;
                _db.dmloaihinhhdkt.Update(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "LoaiHinhHDKT");
        }
        [Route("LoaiHinhHDKT/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.dmloaihinhhdkt.FirstOrDefault(t => t.id == id_delete);
            if (model != null)
            {
                _db.dmloaihinhhdkt.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "LoaiHinhHDKT");
        }
    }
}
