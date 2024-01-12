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

namespace QLVL_Binh.Controllers.Admin.Danhmuc.DoiTuongUuTien
{
    public class DoiTuongUuTienController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public DoiTuongUuTienController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("DoiTuongUuTien")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.dmdoituonguutiens;
            return View("Views/Admin/Danhmuc/DoiTuongUuTien/Index.cshtml", model);
        }
        [Route("DoiTuongUuTien/Store")]
        [HttpPost]
        public IActionResult Store(string tendoituong_create)
        {
            var model = new dmdoituonguutiens
            {
                tendoituong = tendoituong_create,
                madmdt = DateTime.Now.ToString("yyMMddssmmHH"),
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            _db.dmdoituonguutiens.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "DoiTuongUuTien");
        }
        [Route("DoiTuongUuTien/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.dmdoituonguutiens.FirstOrDefault(p => p.id == id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row text-left'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên chức vụ</b></label>";
                result += "<input type='text' id='tencv_edit' name='tencv_edit' value='" + model.tendoituong + "' class='form-control' />";
                result += "</ div > ";
                result += " </ div > ";
                result += " </ div > ";

                result += "<input hidden type='text' id='id_edit' name='id_edit' value='" + model.id + "' />";
                result += " </ div > ";

                var data = new { status = "success", message = result };
                return Json(data);
            }
            else
            {
                var data = new { status = "error", message = "Không tìm thấy thông tin cần chỉnh sửa!!!" };
                return Json(data);
            }
        }
        [Route("DoiTuongUuTien/Update")]
        [HttpPost]
        public IActionResult Update(string tencv_edit, int id_edit)
        {
            var model = _db.dmdoituonguutiens.FirstOrDefault(t => t.id == id_edit);
            if (model != null)
            {
                model.tendoituong = tencv_edit;
                model.updated_at = DateTime.Now;
                _db.dmdoituonguutiens.Update(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "DoiTuongUuTien");
        }
        [Route("DoiTuongUuTien/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.dmdoituonguutiens.FirstOrDefault(t => t.id == id_delete);
            if (model != null)
            {
                _db.dmdoituonguutiens.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "DoiTuongUuTien");
        }
    }
}
