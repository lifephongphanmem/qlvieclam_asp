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

namespace QLVL_Binh.Controllers.Admin.Danhmuc.TinhTrangThamGiaHDKT
{
    public class TinhTrangThamGiaHDKTController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public TinhTrangThamGiaHDKTController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("TinhTrangThamGiaHDKT")]
        [HttpGet]
        public IActionResult Index()
        {
            var data = _db.dmtinhtrangthamgiahdkt;
            var models = new List<dmtinhtrangthamgiahdkt>();
            foreach (var item in data)
            {
                var cout = _db.dmtinhtrangthamgiahdktct.Where(x => x.manhom == item.madmtgkt).Count();
                models.Add(new dmtinhtrangthamgiahdkt
                {
                    id = item.id,
                    tentgkt = item.tentgkt,
                    mota = item.mota,
                    trangthai = item.trangthai,
                    madmtgkt = item.madmtgkt,
                    CoutCt = cout,
                });
            }
            var lastRecord = _db.dmtinhtrangthamgiahdkt.OrderByDescending(x => x.id).FirstOrDefault();
            ViewData["stt"] = lastRecord != null ? lastRecord.stt : 1;
            return View("Views/Admin/Danhmuc/TinhTrangThamGiaHDKT/Index.cshtml", models);
        }
        [Route("TinhTrangThamGiaHDKT/Store")]
        [HttpPost]
        public IActionResult Store( string tentgkt_create, string mota_create, string trangthai_create, int stt_create)
        {
            var model = new dmtinhtrangthamgiahdkt
            {
                tentgkt = tentgkt_create,
                mota = mota_create,
                trangthai = trangthai_create,
                stt = stt_create,
                madmtgkt = DateTime.Now.ToString("yyMMddssmmHH"),
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            _db.dmtinhtrangthamgiahdkt.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "TinhTrangThamGiaHDKT");
        }
        [Route("TinhTrangThamGiaHDKT/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.dmtinhtrangthamgiahdkt.FirstOrDefault(p => p.id == id);

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
                result += "<label><b>Tên mã nghề-trình độ</b></label>";
                result += "<input type='text' id='tentgkt_edit' name='tentgkt_edit' value='" + model.tentgkt + "' class='form-control'/>";
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
        [Route("TinhTrangThamGiaHDKT/Update")]
        [HttpPost]
        public IActionResult Update(string tentgkt_edit, string mota_edit, int id_edit, string trangthai_edit)
        {
            var model = _db.dmtinhtrangthamgiahdkt.FirstOrDefault(t => t.id == id_edit);
            if (model != null)
            {
                model.tentgkt = tentgkt_edit;
                model.mota = mota_edit;
                model.stt = id_edit;
                model.trangthai = trangthai_edit;
                model.updated_at = DateTime.Now;
                _db.dmtinhtrangthamgiahdkt.Update(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "TinhTrangThamGiaHDKT");
        }
        [Route("TinhTrangThamGiaHDKT/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.dmtinhtrangthamgiahdkt.FirstOrDefault(t => t.id == id_delete);
            if (model != null)
            {
                _db.dmtinhtrangthamgiahdkt.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "TinhTrangThamGiaHDKT");
        }
    }
}
