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

namespace QLVL_Binh.Controllers.Admin.Systems.ChucNang
{
    public class ChucNangController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public ChucNangController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("ChucNang")]
        [HttpGet]
        public IActionResult Index()
        {

            var model = _db.chucnangs;
            int stt = 1;
            int stt_cap1 = 1;
            int stt_cap2 = 1;
            var newList = new List<chucnangs>();

            foreach (var item in model.Where(t => t.capdo == 1))
            {
                newList.Add(new chucnangs
                {
                    id = item.id,
                    stt = Helpers.ConvertIntToRoman(stt),
                    maso = item.maso,
                    tencn = item.tencn,
                    capdo = item.capdo,
                    parent = item.parent,
                    trangthai = item.trangthai,
                    machucnang_goc = item.machucnang_goc,
                });
                stt += 1;

                foreach (var cap1 in model.Where(t => t.capdo == 2 && t.machucnang_goc == item.maso))
                {
                    newList.Add(new chucnangs
                    {
                        id = cap1.id,
                        stt = Helpers.ConvertIntToRoman(stt) + "--" + (stt_cap1).ToString(),
                        maso = cap1.maso,
                        tencn = cap1.tencn,
                        capdo = cap1.capdo,
                        parent = cap1.parent,
                        trangthai = cap1.trangthai,
                        machucnang_goc = cap1.machucnang_goc,
                    });
                    stt_cap1 += 1;

                    foreach (var cap2 in model.Where(t => t.capdo == 3 && t.machucnang_goc == cap1.maso))
                    {
                        newList.Add(new chucnangs
                        {
                            id=cap2.id,
                            stt = Helpers.ConvertIntToRoman(stt) + "--" + (stt_cap1).ToString() + "--" + (stt_cap2).ToString(),
                            maso = cap2.maso,
                            tencn = cap2.tencn,
                            capdo = cap2.capdo,
                            parent = cap2.parent,
                            trangthai = cap2.trangthai,
                            machucnang_goc = cap2.machucnang_goc,
                        });
                        stt_cap2 += 1;
                    }
                    stt_cap2 = 1;
                }
            }

            ViewData["chucnangs"] = model;

            return View("Views/Admin/Systems/ChucNang/Index.cshtml", newList);
        }

        [HttpGet]
        public IActionResult GetCapdo(int level)
        {
            var chucnangs = _db.chucnangs.Where(x=>x.capdo==level);
            return Json(chucnangs);
        }
        [Route("ChucNang/Store")]
        [HttpPost]
        public IActionResult Store(string maso_create, string tencn_create, string machucnang_goc_create, string trangthai_create, int capdo_create)
        {
            var model = new chucnangs
            {
                maso = maso_create,
                tencn = tencn_create,
                capdo = capdo_create,
                machucnang_goc = machucnang_goc_create,
                trangthai = trangthai_create,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            _db.chucnangs.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "ChucNang");
        }
        [Route("ChucNang/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.chucnangs.FirstOrDefault(p => p.id == id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row text-left'>";
                result += "<div class='col-xl-3'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã số</b></label>";
                result += "<input type='text' id='maso_edit' name='maso_edit' value='" + model.maso + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-9'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên chức năng</b></label>";
                result += "<input type='text' id='tencn_edit' name='tencn_edit' value='" + model.tencn + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Cấp độ</b></label>";
                result += "<select type='text' id='capdo_edit' name='capdo_edit' class='form-control' onchange='changeCapdoEdit()'>";

                if (model.capdo == 1){result += "<option value='1' selected>Cấp 1</option>"; }
                else { result += "<option value='1'>Cấp 1</option>"; }

                if (model.capdo == 2) { result += "<option value='2' selected>Cấp 2</option>"; }
                else { result += "<option value='2'>Cấp 2</option>"; }

                if (model.capdo == 3) { result += "<option value='3' selected>Cấp 3</option>"; }
                else { result += "<option value='3'>Cấp 3</option>"; }

                result += "</select>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Chức năng gốc</b></label>";
                result += "<select type='text' id='machucnang_goc_edit' name='machucnang_goc_edit' class='form-control'>";
                foreach (var item in _db.chucnangs)
                {
                    result += "<option value='" + item.maso + "'";
                    if (item.parent == model.parent)
                    {
                        result += " selected='selected'";
                    }
                    result += ">" + item.tencn + "</option>";
                }
                result += "</select>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Trạng thái</b></label>";
                result += "<select type='text' id='trangthai_edit' name='trangthai_edit' class='form-control'>";
                if (model.trangthai == "1")
                {
                    result += "<option value='1' selected>Kích hoạt</option>";
                    result += "<option value='0'>Không kích hoạt</option>";
                }
                else
                {
                    result += "<option value='0' selected>Không kích hoạt</option>";
                    result += "<option value='1'>Kích hoạt</option>";
                }
                result += "</select>";
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

        [Route("ChucNang/Update")]
        [HttpPost]
        public IActionResult Update(string maso_edit, string tencn_edit, string machucnang_goc_edit, int id_edit, string trangthai_edit, int capdo_edit)
        {
            var model = _db.chucnangs.FirstOrDefault(t => t.id == id_edit);
            if (model != null)
            {
                model.maso = maso_edit;
                model.tencn = tencn_edit;
                model.capdo = capdo_edit;
                model.machucnang_goc = machucnang_goc_edit;
                model.trangthai = trangthai_edit;
                model.updated_at = DateTime.Now;
                _db.chucnangs.Update(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "ChucNang");
        }
        [Route("ChucNang/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.chucnangs.FirstOrDefault(t => t.id == id_delete);
            if (model != null)
            {
                _db.chucnangs.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "ChucNang");
        }

        [Route("ChucNang/Add")]
        [HttpPost]
        public JsonResult Add(int id)
        {
            var model = _db.chucnangs.FirstOrDefault(p => p.id == id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='add_thongtin'>";

                result += "<div class='row text-left'>";
                result += "<div class='col-xl-3'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã số</b></label>";
                result += "<input type='text' id='maso_add' name='maso_add' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-9'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên chức năng</b></label>";
                result += "<input type='text' id='tencn_add' name='tencn_add' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Cấp độ</b></label>";
                result += "<input type='text' id='capdo_add' name='capdo_add' readonly value='" + (model.capdo+1) + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Chức năng gốc</b></label>";
                result += "<input type='text' id='machucnang_goc_add' name='machucnang_goc_add' readonly value='" + model.maso + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Trạng thái</b></label>";
                result += "<select type='text' id='trangthai_add' name='trangthai_add' class='form-control'>";
                if (model.trangthai == "1")
                {
                    result += "<option value='1' selected>Kích hoạt</option>";
                    result += "<option value='0'>Không kích hoạt</option>";
                }
                else
                {
                    result += "<option value='0' selected>Không kích hoạt</option>";
                    result += "<option value='1'>Kích hoạt</option>";
                }
                result += "</select>";
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

        [Route("ChucNang/Save")]
        [HttpPost]
        public IActionResult Save(string maso_add, string tencn_add, string machucnang_goc_add, string trangthai_add, int capdo_add)
        {
            var model = new chucnangs
            {
                maso = maso_add,
                tencn = tencn_add,
                capdo = capdo_add,
                machucnang_goc = machucnang_goc_add,
                trangthai = trangthai_add,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            _db.chucnangs.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "ChucNang");
        }
    }
}
