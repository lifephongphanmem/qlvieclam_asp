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
using QLVL_Binh.ViewModels.Systems;

namespace QLVL_Binh.Controllers.Admin.ViTriTuyenDung
{
    public class ViTriTuyenDungController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public ViTriTuyenDungController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("ViTriTuyenDung")]
        [HttpGet]
        public IActionResult Index(int id)
        {
            var model = _db.vitrituyendung.Where(x => x.idtuyendung == id);
            return View("Views/Admin/Doanhnghiep/ViTriTuyenDung/Index.cshtml", model);

        }
        public string GetData(int idtuyendung)
        {
            var model = _db.vitrituyendung.Where(t => t.idtuyendung == idtuyendung).ToList();

            int record = 1;
            string result = "<div class='card-body' id='frm_data'>";
            result += "<table class='table table-striped table-bordered table-hover table-responsive' id='datatable_4'>";
            result += "<thead>";
            result += "<tr style='text-align:center'>";
            result += "<th>STT</th>";
            result += "<th>Tên vị trí tuyển dụng</th>";
            result += "<th>Số lượng</th>";
            result += "<th>Yêu cầu kinh nghiệm</th>";
            result += "<th>Hình thức làm việc</th>";
            result += "<th>Mức lương</th>";
            result += "<th>Thao tác</th>";
            result += "</tr>";
            result += "</thead>";
            result += "<tbody>";

            foreach (var item in model)
            {
                result += "<tr>";
                result += "<td style='text-align:center'>" + record++ + "</td>";
                result += "<td class='active'>" + item.name + "</td>";
                result += "<td>" + item.soluong + "</td>";
                result += "<td>" + item.yeucaukn + "</td>";
                result += "<td>" + item.hinhthuclv + "</td>";
                result += "<td>" + item.mucluong + "</td>";
                result += "<td>";
                result += "<button type='button' class='btn btn-sm btn-clean btn-icon' title='Chỉnh sửa'";
                result += " data-target='#Edit_Modal' data-toggle='modal' onclick='SetEdit(`" + item.id + "`)'>";
                result += "<i class='icon-lg la la-edit text-primary'></i>";
                result += "</button>";
                result += "<button type='button' class='btn btn-sm btn-clean btn-icon' title='Xóa'";
                result += " data-target='#Delete_Modal' data-toggle='modal' onclick='GetDelete(`" + item.id + "`)'>";
                result += "<i class='icon-lg la la-trash text-danger'></i>";
                result += "</button>";
                result += "</td>";
                result += "</tr>";
            }
            result += "</tbody>";
            result += "</table>";
            result += "</div>";

            return result;

        }
        [Route("ViTriTuyenDung/Store")]
        [HttpPost]
        public JsonResult Store(string name, short soluong, string description, string tdgd, string tdcmkt, string chuyennganh, string loaithvp,
            string diadiem,string tinhockhac, string kynangmem, string yeucaukn, string hinhthuclv, string phucloi, string hotroan,
            string mucluong, string mucdichlv,int idtuyendung)
        {
            var model = new vitrituyendung
            {
                idtuyendung= idtuyendung,
                name = name,
                soluong = soluong,
                description = description,
                tdgd = tdgd,
                tdcmkt = tdcmkt,
                chuyennganh = chuyennganh,
                mucdichlv = mucdichlv,
                loaithvp = loaithvp,
                diadiem = diadiem,
                tinhockhac = tinhockhac,
                kynangmem = kynangmem,
                yeucaukn = yeucaukn,
                hinhthuclv = hinhthuclv,
                phucloi = phucloi,
                hotroan = hotroan,
                mucluong = mucluong,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
                state="CXD"
            };
            _db.vitrituyendung.Add(model);
            _db.SaveChanges();
            string result = GetData(idtuyendung);
            var data = new { status = "success", message = result };
            return Json(data);
        }


        [Route("ViTriTuyenDung/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.vitrituyendung.FirstOrDefault(p => p.id == id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row text-left'>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên vị trí công việc</b></label>";
                result += "<input type='text' id='name_edit' name='name_edit' value='" + model.name + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Số lượng</b></label>";
                result += "<input type='text' id='soluong_edit' name='soluong_edit' value='" + model.soluong + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mô tả công việc</b></label>";
                result += "<textarea type='text' id='description_edit' name='description_edit' cols='12' rows='3' class='form-control'>" + model.description + "</textarea>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Trình độ giáo dục yêu cầu</b></label>";
                result += "<input type='text' id='tdgd_edit' name='tdgd_edit' value='" + model.tdgd + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Trình độ chuyên môn kỹ thuật yêu cầu</b></label>";
                result += "<input type='text' id='tdcmkt_edit' name='tdcmkt_edit' value='" + model.tdcmkt + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Chuyên nghành công việc</b></label>";
                result += "<input type='text' id='chuyennganh_edit' name='chuyennganh_edit' value='" + model.chuyennganh + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Trình độ tin học văn phòng yêu cầu</b></label>";
                result += "<input type='text' id='loaithvp_edit' name='loaithvp_edit' value='" + model.loaithvp + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Trình độ tin học yêu cầu khác</b></label>";
                result += "<textarea type='text' id='tinhockhac_edit' name='tinhockhac_edit' cols='12' rows='3' class='form-control'>" + model.tinhockhac + "</textarea>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Kỹ năng mềm</b></label>";
                result += "<textarea type='text' id='kynangmem_edit' name='kynangmem_edit' cols='12' rows='3' class='form-control'>" + model.kynangmem + "</textarea>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Kinh nghiệm yêu cầu</b></label>";
                result += "<input type='text' id='yeucaukn_edit' name='yeucaukn_edit' value='" + model.yeucaukn + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Hình thức làm việc</b></label>";
                result += "<input type='text' id='hinhthuclv_edit' name='hinhthuclv_edit' value='" + model.hinhthuclv + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Địa điểm</b></label>";
                result += "<textarea type='text' id='diadiem_edit' name='diadiem_edit' cols='12' rows='3' class='form-control'>" + model.diadiem + "</textarea>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mục đích làm việc</b></label>";
                result += "<textarea type='text' id='mucdichlv_edit' name='mucdichlv_edit' cols='12' rows='3' class='form-control'>" + model.mucdichlv + "</textarea>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mức lương</b></label>";
                result += "<input type='text' id='mucluong_edit' name='mucluong_edit' value='" + model.mucluong + "' class='form-control money'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Hỗ trợ ăn</b></label>";
                result += "<input type='text' id='hotroan_edit' name='hotroan_edit' value='" + model.hotroan + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Phúc lợi</b></label>";
                result += "<textarea type='text' id='phucloi_edit' name='phucloi_edit' cols='12' rows='3' class='form-control'>" + model.phucloi + "</textarea>";
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
        [Route("ViTriTuyenDung/Update")]
        [HttpPost]
        public JsonResult Update(string name, short soluong, string description, string tdgd, string tdcmkt, string chuyennganh, string loaithvp,
            string diadiem, string tinhockhac, string kynangmem, string yeucaukn, string hinhthuclv, string phucloi, string hotroan,
            string mucluong, string mucdichlv,int id_edit)
        {
            var model = _db.vitrituyendung.FirstOrDefault(t => t.id == id_edit);
            if (model != null)
            {
                model.name = name;
                model.soluong = soluong;
                model.description = description;
                model.tdgd = tdgd;
                model.tdcmkt = tdcmkt;
                model.chuyennganh = chuyennganh;
                model.loaithvp = loaithvp;
                model.diadiem = diadiem;
                model.tinhockhac = tinhockhac;
                model.kynangmem = kynangmem;
                model.yeucaukn = yeucaukn;
                model.hinhthuclv = hinhthuclv;
                model.phucloi = phucloi;
                model.hotroan = hotroan;
                model.mucluong = mucluong;
                model.mucdichlv = mucdichlv;
                model.updated_at = DateTime.Now;

            }
            _db.vitrituyendung.Update(model!);
            _db.SaveChanges();
            string result = GetData(model!.idtuyendung);
            var data = new { status = "success", message = result };
            return Json(data);
        }
        [Route("ViTriTuyenDung/Delete")]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var model = _db.vitrituyendung.FirstOrDefault(t => t.id == id);
            _db.vitrituyendung.Remove(model!);
            _db.SaveChanges();
            string result = GetData(model!.idtuyendung);
            var data = new { status = "success", message = result };
            return Json(data);
        }

        /*
         need build additional a column "abroad" for identify type a worker insite another nation or in Vietnam 
        compare model "dsthatnghiep" with "ViTriTuyenDung" has state "Dang that nghiep"
         */
    }
}
