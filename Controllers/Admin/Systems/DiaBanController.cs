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

namespace QLVL_Binh.Controllers.Admin.Systems.DiaBan
{
    public class DiaBanController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public DiaBanController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("DiaBan")]
        [HttpGet]
        public IActionResult Index()
        {

            ViewData["DmHanhChinh"] = _db.danhmuchanhchinh;
            var model = _db.danhmuchanhchinh;
            int stt = 1;
            int stt_h = 1;
            int stt_x = 1;
            var newList = new List<danhmuchanhchinh>();

            foreach(var item in model.Where(t => string.IsNullOrEmpty(t.parent) || t.parent == "0")){
                var dmhanhchinhhuyen = model.Where(h => h.parent == item.maquocgia);
                newList.Add(new danhmuchanhchinh
                {
                    stt = stt++,
                    name = item.name,
                    capdo = item.capdo,
                    parent = item.parent,
                    maquocgia = item.maquocgia,
                });
                foreach (var dbhuyen in dmhanhchinhhuyen)
                {
                    var dmhanhchinhxa = model.Where(x => x.parent == dbhuyen.maquocgia);
                    newList.Add(new danhmuchanhchinh
                    {
                        stt = stt_h++,
                        name = dbhuyen.name,
                        capdo = dbhuyen.capdo,
                        parent = dbhuyen.parent,
                        maquocgia = dbhuyen.maquocgia,
                    });
                    foreach (var dbxa in dmhanhchinhxa)
                    {
                        newList.Add(new danhmuchanhchinh
                        {
                            stt = stt_x++,
                            name = dbxa.name,
                            capdo = dbxa.capdo,
                            parent = dbxa.parent,
                            maquocgia = dbxa.maquocgia,
                        });
                    }
                    stt_x = 1;
                }
            }
            //return Ok(newList);

            return View("Views/Admin/Systems/DiaBan/Index.cshtml", newList);
        }
        [Route("DiaBan/Store")]
        [HttpPost]
        public IActionResult Store(string name_create, string madb_create, string level_create, string parent_create)
        {
            var model = new danhmuchanhchinh
            {
                name = name_create,
                madb = madb_create,
                level = level_create,
                parent = parent_create,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            _db.danhmuchanhchinh.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "DiaBan");
        }
        [Route("DiaBan/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.danhmuchanhchinh.FirstOrDefault(p => p.id == id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row text-left'>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã địa bàn</b></label>";
                result += "<input type='number' id='madb_edit' name='madb_edit' value='" + model.madb + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên địa bàn</b></label>";
                result += "<input type='number' id='name_edit' name='name_edit' value='" + model.name + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên chức vụ</b></label>";
                result += "<select type='text; id='level_edit' name='level_edit' class='form-control'>";
                foreach (var item in Helpers.phanLoaiDb())
                {
                    result += "<option value='" + item + "'";
                    if (item == model.level)
                    {
                        result += " selected='selected'";
                    }
                    result += ">"+item+ "</option>";
                }
                result += "</select>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Trực thuộc địa bàn</b></label>";
                result += "<select type='text; id='parent_edit' name='parent_edit' class='form-control'>";
                foreach (var item in _db.danhmuchanhchinh)
                {
                    result += "<option value='" + item.maquocgia + "'";
                    if (item.parent == model.parent)
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
        
        [Route("DiaBan/Update")]
        [HttpPost]
        public IActionResult Update(string name_edit, string madb_edit, string level_edit, int id_edit,string parent_edit)
        {
            var model = _db.danhmuchanhchinh.FirstOrDefault(t => t.id == id_edit);
            if (model != null)
            {
                model.name = name_edit;
                model.madb = madb_edit;
                model.level = level_edit;
                model.parent = parent_edit;
                model.updated_at = DateTime.Now;
                _db.danhmuchanhchinh.Update(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "DiaBan");
        }
        [Route("DiaBan/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.danhmuchanhchinh.FirstOrDefault(t => t.id == id_delete);
            if (model != null)
            {
                _db.danhmuchanhchinh.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "DiaBan");
        }
    }
}
