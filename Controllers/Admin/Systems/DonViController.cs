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
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json.Linq;

namespace QLVL_Binh.Controllers.Admin.Systems.DonVi
{
    public class DonViController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public DonViController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("DonVi")]
        [HttpGet]
        public IActionResult Index()
        {
            var models = from dv in _db.dmdonvi
                         join dmhc in _db.danhmuchanhchinh on dv.madiaban equals dmhc.maquocgia
                         select new dmdonvi
                         {
                             id = dv.id,
                             tendv = dv.tendv,
                             madv = dv.madv,
                             khuvuchanhchinh = dmhc.name,
                             phanloaitaikhoan = dv.phanloaitaikhoan,
                         };
            ViewData["DonViChuQuan"] = _db.dmdonvi;
            ViewData["DmHanhChinh"] = _db.danhmuchanhchinh;
            return View("Views/Admin/Systems/DonVi/Index.cshtml", models);
        }
        [Route("DonVi/Store")]
        [HttpPost]
        public IActionResult Store(string madv_create, string tendv_create, string tendvhienthi_create, string email_create,string madvcq_create,string madiaban_create)
        {
            var model = new dmdonvi
            {
                madv = madv_create,
                tendv = tendv_create,
                tendvhienthi = tendvhienthi_create,
                email = email_create,
                madvcq = madvcq_create,
                madiaban = madiaban_create,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            _db.dmdonvi.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "DonVi");
        }
        [Route("DonVi/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.dmdonvi.FirstOrDefault(p => p.id == id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row text-left'>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã đơn vị:</b></label>";
                result += "<input type='number' id='madv_edit' name='madv_edit' value='" + model.madv + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên đơn vị:</b></label>";
                result += "<input type='number' id='tendv_edit' name='tendv_edit' value='" + model.tendv + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên đơn vị hiển thị báo cáo:</b></label>";
                result += "<input type='number' id='tendvhienthi_edit' name='tendvhienthi_edit' value='" + model.tendvhienthi + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Email</b></label>";
                result += "<input type='number' id='email_edit' name='email_edit' value='" + model.email + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên đơn vị cấp trên:</b></label>";
                result += "<select type='text; id='madvcq_edit' name='madvcq_edit' class='form-control'>";
                
                foreach (var item in _db.dmdonvi)
                {
                    result += "<option value='" + item.madv + "'";
                    if (item.madv == model.madvcq)
                    {
                        result += " selected='selected'";
                    }
                    result += ">" + item.tendv + "</option>";
                }
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Khu vực hành chính:</b></label>";
                result += "<select type='text; id='madiaban_edit' name='madiaban_edit' class='form-control'>";

                foreach (var item in _db.danhmuchanhchinh)
                {
                    result += "<option value='" + item.maquocgia + "'";
                    if (item.maquocgia == model.madiaban)
                    {
                        result += " selected='selected'";
                    }
                    result += ">" + item.name + "</option>";
                }
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

        [Route("DonVi/Update")]
        [HttpPost]
        public IActionResult Update(string madv_edit, string tendv_edit, string tendvhienthi_edit, int id_edit, string email_edit,string madvcq_edit,string madiaban_edit)
        {
            var model = _db.dmdonvi.FirstOrDefault(t => t.id == id_edit);
            if (model != null)
            {
                model.madv = madv_edit;
                model.tendv = tendv_edit;
                model.tendvhienthi = tendvhienthi_edit;
                model.email = email_edit;
                model.madvcq = madvcq_edit;
                model.madiaban = madiaban_edit;
                model.updated_at = DateTime.Now;
                _db.dmdonvi.Update(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "DonVi");
        }
        [Route("DonVi/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.dmdonvi.FirstOrDefault(t => t.id == id_delete);
            if (model != null)
            {
                _db.dmdonvi.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "DonVi");
        }
    }
}
