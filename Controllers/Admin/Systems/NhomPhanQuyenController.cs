using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLVL_Binh.Models.Systems;
using Azure.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json.Linq;
using QLVL_Binh.Database;
using QLVL_Binh.ViewModels.Systems;
using QLVL_Binh.Helper;

namespace QLVL_Binh.Controllers.Admin.Systems.NhomPhanQuyen
{
    public class NhomPhanQuyenController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public NhomPhanQuyenController(QLVL_BinhContext db)
        {
            _db = db;
        }
        [Route("NhomPhanQuyen")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.dsnhomtaikhoan;
            var lastRecord = _db.dsnhomtaikhoan.OrderByDescending(e => e.id).FirstOrDefault();
            ViewData["stt"] = lastRecord != null ? lastRecord.stt : 1;
            return View("Views/Admin/Systems/NhomPhanQuyen/Index.cshtml", model);
        }

        [Route("NhomPhanQuyen/Store")]
        [HttpPost]
        public IActionResult Store(string manhomchucnang_create, string tennhomchucnang_create, int stt_create)
        {
            var model = new dsnhomtaikhoan
            {
                manhomchucnang = manhomchucnang_create,
                tennhomchucnang = tennhomchucnang_create,
                stt = stt_create,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            _db.dsnhomtaikhoan.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "NhomPhanQuyen");
        }
        [Route("NhomPhanQuyen/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.dsnhomtaikhoan.FirstOrDefault(p => p.id == id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row text-left'>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã số</b></label>";
                result += "<input type='text' id='manhomchucnang_edit' name='manhomchucnang_edit' value='" + model.manhomchucnang + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên nhóm chức năng</b></label>";
                result += "<input type='text' id='tennhomchucnang_edit' name='tennhomchucnang_edit' value='" + model.tennhomchucnang + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Số thứ tự</b></label>";
                result += "<input type='text' id='stt_edit' name='stt_edit' value='" + model.stt + "' class='form-control'/>";
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
        [Route("NhomPhanQuyen/Update")]
        [HttpPost]
        public IActionResult Update(string manhomchucnang_edit, int id_edit, string tennhomchucnang_edit,string stt_edit)
        {
            var model = _db.dsnhomtaikhoan.FirstOrDefault(t => t.id == id_edit);
            if (model != null)
            {
                model.manhomchucnang = manhomchucnang_edit;
                model.tennhomchucnang = tennhomchucnang_edit;
                model.stt = id_edit;
                model.updated_at = DateTime.Now;
                _db.dsnhomtaikhoan.Update(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "NhomPhanQuyen");
        }
        [Route("NhomPhanQuyen/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.dsnhomtaikhoan.FirstOrDefault(t => t.id == id_delete);
            if (model != null)
            {
                _db.dsnhomtaikhoan.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "NhomPhanQuyen");
        }

        private List<VM_DsNhomTaiKhoan_PhanQuyen> GetVM_DsNhomTaiKhoan_PhanQuyen(int id)
        {
            var dsnhomtaikhoan_phanquyen = (from nhomtk in _db.dsnhomtaikhoan.Where(t => t.id == id)
                                            join phanquyen in _db.dsnhomtaikhoan_phanquyen
                                            on nhomtk.manhomchucnang equals phanquyen.manhomchucnang
                                            select new VM_DsNhomTaiKhoan_PhanQuyen
                                            {
                                                id = phanquyen.id,
                                                machucnang = phanquyen.machucnang,
                                                tennhomchucnang = nhomtk.tennhomchucnang,
                                                phanquyen = phanquyen.phanquyen,
                                                danhsach = phanquyen.danhsach,
                                                thaydoi = phanquyen.thaydoi,
                                                hoanthanh = phanquyen.hoanthanh,
                                            }).ToList();
            var model = (from vm in dsnhomtaikhoan_phanquyen
                         join chucnang in _db.chucnangs
                         on vm.machucnang equals chucnang.maso
                         select new VM_DsNhomTaiKhoan_PhanQuyen
                         {
                             id = vm.id,
                             machucnang = vm.machucnang,
                             tennhomchucnang = vm.tennhomchucnang,
                             phanquyen = vm.phanquyen,
                             danhsach = vm.danhsach,
                             thaydoi = vm.thaydoi,
                             hoanthanh = vm.hoanthanh,
                             tencn = chucnang.tencn,
                             capdo = chucnang.capdo,
                             parent = chucnang.parent,
                             machucnang_goc = chucnang.machucnang_goc,
                         }).ToList();

            return model;
        }
        [Route("NhomPhanQuyen/PhanQuyenNhom")]
        [HttpGet]
        public IActionResult PhanQuyenNhom(int id)
        {
            var model=GetVM_DsNhomTaiKhoan_PhanQuyen(id);

            int stt = 1;
            int stt_cap1 = 1;
            int stt_cap2 = 1;
            var newList = new List<VM_DsNhomTaiKhoan_PhanQuyen>();

            foreach (var item in model.Where(t => t.capdo == 1))
            {
                newList.Add(new VM_DsNhomTaiKhoan_PhanQuyen
                {
                    id = item.id,
                    stt = Helpers.ConvertIntToRoman(stt),
                    machucnang = item.machucnang,
                    tencn = item.tencn,
                    capdo = item.capdo,
                    parent = item.parent,
                    machucnang_goc = item.machucnang_goc,
                    phanquyen = item.phanquyen,
                    danhsach = item.danhsach,
                    thaydoi = item.thaydoi,
                    hoanthanh = item.hoanthanh,
                });
                stt += 1;

                foreach (var cap1 in model.Where(t => t.capdo == 2 && t.machucnang_goc == item.machucnang))
                {
                    newList.Add(new VM_DsNhomTaiKhoan_PhanQuyen
                    {
                        id = cap1.id,
                        stt = Helpers.ConvertIntToRoman(stt) + "--" + (stt_cap1).ToString(),
                        machucnang = cap1.machucnang,
                        tencn = cap1.tencn,
                        capdo = cap1.capdo,
                        parent = cap1.parent,
                        machucnang_goc = cap1.machucnang_goc,
                        phanquyen = cap1.phanquyen,
                        danhsach = cap1.danhsach,
                        thaydoi = cap1.thaydoi,
                        hoanthanh = cap1.hoanthanh,
                    });
                    stt_cap1 += 1;

                    foreach (var cap2 in model.Where(t => t.capdo == 3 && t.machucnang_goc == cap1.machucnang))
                    {
                        newList.Add(new VM_DsNhomTaiKhoan_PhanQuyen
                        {
                            id = cap2.id,
                            stt = Helpers.ConvertIntToRoman(stt) + "--" + (stt_cap1).ToString() + "--" + (stt_cap2).ToString(),
                            machucnang = cap2.machucnang,
                            tencn = cap2.tencn,
                            capdo = cap2.capdo,
                            parent = cap2.parent,
                            machucnang_goc = cap2.machucnang_goc,
                            phanquyen = cap2.phanquyen,
                            danhsach = cap2.danhsach,
                            thaydoi = cap2.thaydoi,
                            hoanthanh = cap2.hoanthanh,
                        });
                        stt_cap2 += 1;
                    }
                    stt_cap2 = 1;
                }
            }
            ViewData["id_nhom"] = id;
            return View("Views/Admin/Systems/NhomPhanQuyen/PhanQuyenNhom.cshtml", newList);
        }

        [Route("NhomPhanQuyen/PhanQuyenNhom/Edit")]
        [HttpPost]
        public JsonResult PhanQuyenNhom_Edit(int id,int id_nhom)
        {
            var model = GetVM_DsNhomTaiKhoan_PhanQuyen(id_nhom);

            var info = model.Where(x => x.id == id).FirstOrDefault();

            if (info != null)
            {
                string result = "<div class='modal-body' id='PhanQuyenNhom_Update'>";

                result += "<div class='row text-left'>";
                result += "<div class='col-xl-9'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên chức năng</b></label>";
                result += "<input type='text' id='tencn_edit' name='tencn_edit' value='" + info.tencn + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Phân quyền chức năng</b></label>";
                result += "<div class='checkbox-inline'>";
                result += "<label class='checkbox checkbox-outline checkbox-success'>";
                result += "<input type='checkbox' name='danhsach_edit' id='danhsach_edit' ";
                if (info.danhsach == true) { result += "checked>"; } else { result += ">"; }
                result += "<span></span>Danh sách";
                result += "</label>";
                result += "<label class='checkbox checkbox-outline checkbox-success'>";
                result += "<input type='checkbox' name='thaydoi_edit' id='thaydoi_edit' ";
                if (info.thaydoi == true) { result += "checked>"; } else { result += ">"; }
                result += "<span></span>Thay đổi";
                result += "</label>";
                result += "<label class='checkbox checkbox-outline checkbox-success'>";
                result += "<input type='checkbox' name='hoanthanh_edit' id='hoanthanh_edit' ";
                if(info.hoanthanh==true) { result += "checked>"; } else { result += ">"; }
                result += "<span></span>Hoàn thành";
                result += "</label>";
                result += "</div>";
                result += "</div>";
                result += "</div>";
                result += "</div>";

                result += "<input hidden type='text' id='id_edit' name='id_edit' value='" + info.id + "'/>";
                result += "<input hidden type='text' id='id_nhom' name='id_nhom' value='" + id_nhom + "'/>";
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
        [Route("NhomPhanQuyen/PhanQuyenNhom/Update")]
        [HttpPost]
        public IActionResult PhanQuyenNhom_Update(string tencn_edit, int id_edit, int id_nhom, bool danhsach_edit, bool thaydoi_edit,bool hoanthanh_edit)
        {
            var model = _db.dsnhomtaikhoan_phanquyen.Where(x => x.id == id_edit).FirstOrDefault();
            if (model != null)
            {
                model.danhsach=danhsach_edit;
                model.thaydoi=thaydoi_edit;
                model.hoanthanh=hoanthanh_edit;
                model.updated_at=DateTime.Now;
                _db.dsnhomtaikhoan_phanquyen.Update(model);
                _db.SaveChanges();
            }
            var chucnang=_db.chucnangs.Where(x=>x.maso==model.machucnang).FirstOrDefault();
            if (chucnang != null)
            {
                chucnang.tencn = tencn_edit;
                chucnang.updated_at = DateTime.Now;
                _db.chucnangs.Update(chucnang);
                _db.SaveChanges();
            }
            return RedirectToAction("PhanQuyenNhom", "NhomPhanQuyen");
        }
    }
}
