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
using QLVL_Binh.ViewModels.Systems.VM_DoanhNghiep;
using QLVL_Binh.Models.Systems.PhienGiaoDichVL;
using QLVL_Binh.ViewModels.Systems.VM_PhienGiaoDich;
using static System.Net.Mime.MediaTypeNames;

namespace QLVL_Binh.Controllers.Admin.PhienGiaoDichVL
{
    public class PhienGiaoDichVLController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public PhienGiaoDichVLController(QLVL_BinhContext db)
        {
            _db = db;
        }
        /*tổng hợp chức năng phiên giao dịch việc làm:
         * 1.tạo phiên:tên,địa bàn,số lượng nld tham gia(có thể)-
         * 2.xóa phiên-
         * 3.sửa phiên:tên,địa bàn,số lượng nld tham gia(có thể)-
         * 4.tạo chi tiết cho phiên:thêm doanh nghiệp có thông tin tuyển dụng tại địa bàn vào(chức năng con trong tạo phiên hoặc sửa phiên)-
         * 5.xóa chi tiết của phiên:xóa phần tuyển dụng của doanh nghiệp(chức năng con trong tạo phiên hoặc sửa phiên)
         */
        /*
         [Route("Chitiet")]
        [HttpGet]
        public IActionResult Chitiet(string magd)
        {
            var model = _db.phiengiaodichvl_ct.Where(x => x.magd == magd)
                .GroupBy(c => c.name)
                .Select(g => new
                {
                    name = g.Key,
                    vitri = g.Select(c => c.vitri).Distinct().Count(),
                    soluong = g.Sum(c => c.soluong)
                });
            List<VM_TuyenDung> result = dnTuyendung.ToList();

            for (int i = 1; i < result.Count; i++)
            {
                if (result[i].user == result[i - 1].user)
                {
                    result[i].doanhnghiep = null;
                }

                if (result[i].idtuyendung == result[i - 1].idtuyendung)
                {
                    result[i].noidung = null;
                }
            }

            return View("Views/Admin/PhienGiaoDichVL/Index.cshtml", model);

        }
        */


        [Route("PhienGiaoDichVL")]
        [HttpGet]
        public IActionResult Index(string huyen, string xa)
        {
            if (huyen == null || huyen == "")
            {
                huyen = _db.danhmuchanhchinh.Where(x => x.capdo == "H").FirstOrDefault()!.name;
            }

            var parent = _db.danhmuchanhchinh.Where(x => x.capdo == "H" && x.name == huyen).FirstOrDefault()!.maquocgia;

            if (string.IsNullOrEmpty(xa))
            {
                xa = _db.danhmuchanhchinh.Where(x => x.capdo == "X" && x.parent == parent).FirstOrDefault()!.name;
            }

            var model_ct = _db.phiengiaodichvl_ct
                .GroupBy(c => c.magd)
                .Select(g => new phiengiaodichvl_ct
                {
                    magd = g.Key,
                    name = g.Select(c => c.name).Distinct().Count().ToString(),
                    vitri = g.Select(c => c.vitri).Distinct().Count().ToString(),
                    soluong = g.Sum(c => c.soluong)
                });

            //loc nhung phiengiaodichvl_ct chua duoc save
            foreach(var loc in _db.phiengiaodichvl.Where(x=>x.trangthai=="CXD"))
            {
                var filter_phiengiaodichvl_ct = _db.phiengiaodichvl_ct.Where(x=>x.magd==loc.magd);
                _db.phiengiaodichvl_ct.RemoveRange(filter_phiengiaodichvl_ct);
                _db.phiengiaodichvl.Remove(loc);
            }
            _db.SaveChanges();

            var result = (from model in _db.phiengiaodichvl.Where(x => x.xa == xa)
                          join ct in model_ct
                          on model.magd equals ct.magd
                          select new VM_PhienGiaoDich
                          {
                              name = model.name,
                              magd = ct.magd,
                              doanhnghiep = ct.name,
                              vitri = ct.vitri,
                              soluong = ct.soluong,
                              nguoilaodong = model.nguoilaodong,
                              huyen = model.huyen,
                              xa = model.xa,
                              trangthai = model.trangthai,
                          });
            ViewData["tenhuyen"] = huyen;
            ViewData["tenxa"] = xa;
            ViewData["Huyen"] = _db.danhmuchanhchinh.Where(t => t.capdo == "H");
            ViewData["Xa"] = _db.danhmuchanhchinh.Where(t => t.capdo == "X" && t.parent == parent);
            return View("Views/Admin/PhienGiaoDichVL/Index.cshtml", result);

        }

        public List<VM_TuyenDung> GetListDnTuyendung(string huyen, string xa)
        {
            if (huyen == null || huyen == "")
            {
                huyen = _db.danhmuchanhchinh.Where(x => x.capdo == "H").FirstOrDefault()!.name;
            }

            var parent = _db.danhmuchanhchinh.Where(x => x.capdo == "H" && x.name == huyen).FirstOrDefault()!.maquocgia;

            if (string.IsNullOrEmpty(xa))
            {
                xa = _db.danhmuchanhchinh.Where(x => x.capdo == "X" && x.parent == parent).FirstOrDefault()!.name;
            }
            var company = _db.company.Where(x => x.xa == xa);
            var dnTuyendung = (from dn in company
                               join td in _db.tuyendung
                                   on dn.id.ToString() equals td.user.ToString()
                               join vttd in _db.vitrituyendung
                               on td.id.ToString() equals vttd.idtuyendung.ToString()
                               select new VM_TuyenDung
                               {
                                   doanhnghiep = dn.name,
                                   user = td.user,
                                   noidung = td.noidung,
                                   soluong = vttd.soluong,
                                   vitri = vttd.name,
                                   idtuyendung = vttd.idtuyendung,
                               });

            return dnTuyendung.ToList();
        }

        [Route("PhienGiaoDichVL/Create")]
        [HttpGet]
        public IActionResult Create(string huyen, string xa)
        {
            var dnTuyendung = GetListDnTuyendung(huyen, xa);

            var model = new phiengiaodichvl
            {
                magd = DateTime.Now.ToString("yyMMddssmmHH"),
                trangthai = "CXD",
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            _db.phiengiaodichvl.Add(model);
            _db.SaveChanges();
            ViewData["magd"] = model.magd;
            ViewData["tenxa"] = xa;
            ViewData["tenhuyen"] = huyen;
            ViewData["dnTuyendung"] = dnTuyendung;
            ViewData["model_ct"] = _db.phiengiaodichvl_ct.Where(x=>x.magd== model.magd);
            return View("Views/Admin/PhienGiaoDichVL/Create.cshtml",model);
        }

        [Route("PhienGiaoDichVL/Store")]
        [HttpPost]
        public IActionResult Store(phiengiaodichvl request)
        {
            var model = _db.phiengiaodichvl.Where(x=>x.magd== request.magd).FirstOrDefault();
            model!.name=request.name;
            model.huyen=request.huyen;
            model.xa=request.xa;
            model.nguoilaodong=request.nguoilaodong;
            model.trangthai = "XD";
            model.updated_at = DateTime.Now;

            _db.phiengiaodichvl.Update(model);
            _db.SaveChanges();

            return RedirectToAction("Index", "PhienGiaoDichVL", new { request.huyen,request.xa });
        }

        [Route("PhienGiaoDichVL/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.phiengiaodichvl.FirstOrDefault(t => t.id == id_delete);
            var huyen = model!.huyen;
            var xa = model.xa;
            if (model != null)
            {
                _db.phiengiaodichvl.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "PhienGiaoDichVL", new { huyen, xa });
        }

        [Route("PhienGiaoDichVL/Edit")]
        [HttpGet]
        public IActionResult Edit(string magd)
        {
            var model = _db.phiengiaodichvl.FirstOrDefault(x=>x.magd == magd);
            var dnTuyendung = GetListDnTuyendung(model!.huyen!, model.xa!);
            _db.phiengiaodichvl.Add(model);
            _db.SaveChanges();
            ViewData["magd"] = model.magd;
            ViewData["tenxa"] = model!.huyen!;
            ViewData["tenhuyen"] = model.xa!;
            ViewData["dnTuyendung"] = dnTuyendung;
            ViewData["model_ct"] = _db.phiengiaodichvl_ct.Where(x => x.magd == model.magd);
            return View("Views/Admin/PhienGiaoDichVL/Edit.cshtml",model);
        }

        [Route("PhienGiaoDichVL/Update")]
        [HttpPost]
        public IActionResult Update(phiengiaodichvl request)
        {
            var model = _db.phiengiaodichvl.FirstOrDefault(t => t.magd == request.magd);
            model!.name = request.name;
            model.huyen = request.huyen;
            model.xa = request.xa;
            model.nguoilaodong = request.nguoilaodong;
            model.updated_at = DateTime.Now;

            _db.phiengiaodichvl.Update(model);
            _db.SaveChanges();

            return RedirectToAction("Index", "PhienGiaoDichVL", new { request.huyen, request.xa });
        }


        [Route("PhienGiaoDichVL/AddDetail")]
        [HttpPost]
        public JsonResult AddDetail(string doanhnghiep, string noidung, string vitri, string huyen, string xa, string magd,int user,int soluong)
        {
            var dnTuyendung = GetListDnTuyendung(huyen, xa);
            var model = dnTuyendung.Where(x => x.doanhnghiep != doanhnghiep || x.noidung != noidung || x.vitri != vitri);

            //luu chi tiet
            var chitiet = new phiengiaodichvl_ct
            {
                magd =magd,
                name=doanhnghiep,
                user=user,
                noidung=noidung,
                vitri=vitri,
                soluong=soluong,
                created_at=DateTime.Now,
                updated_at=DateTime.Now,
            };
            _db.phiengiaodichvl_ct.Add(chitiet);
            _db.SaveChanges();

            //doc trong phiengiaodichvl_ct da co ho so chua xog loc no qua dnTuyendung de loai truc tiep luon
            var check_ct = _db.phiengiaodichvl_ct.Where(x => x.magd == magd);
            if (check_ct != null)
            {
                foreach (var pgd in check_ct)
                {
                    foreach (var item in model)
                    {
                        if (pgd.name == item.doanhnghiep && pgd.noidung == item.noidung && pgd.vitri == item.vitri)
                        {
                            model = model.Where(x => x.doanhnghiep != pgd.name || x.noidung != pgd.noidung || x.vitri != pgd.vitri);
                        }
                    }
                }
            }
            if (model != null)
            {
                string result = "<table class='table table-striped table-bordered table-hover' id='add_detail_table'>";
                result += "<thead>";
                result += "<tr style='text-align:center'>";
                result += "<th>Doanh nghiệp</th>";
                result += "<th>Tin tuyển dụng</th>";
                result += "<th>Vị trí tuyển</th>";
                result += "<th>Số lượng tuyển</th>";
                result += "<th>Tác vụ</th>";
                result += "</tr>";
                result += "</thead>";
                result += "<tbody>";
                foreach (var item in model)
                {
                    result += "<tr>";
                    result += "<td>" + item.doanhnghiep + "</td>";
                    result += "<td>" + item.noidung + "</td>";
                    result += "<td>" + item.vitri + "</td>";
                    result += "<td>" + item.soluong + "</td>";
                    result += "<td><button type='button' class='btn btn-sm btn - clean btn - icon' title='Thêm chi tiết'";
                    result += "onclick='SetAddDetail(`" + item.doanhnghiep + "`,`" + item.noidung + "`,`" + item.vitri + "`,`" + xa + "`,`" + huyen + "`,`" + magd + "`,`" + item.user + "`,`" + item.soluong + "`)'>";
                    result += "<i class='icon-lg la la-plus text-success'></i>";
                    result += "</button></td>";
                    result += "</tr>";
                }
                result += "</tbody>";
                result += "</table>";

                var data = new { status = "success", message = result };
                return Json(data);
            }
            else
            {
                var data = new { status = "error", message = "Không tìm thấy thông tin cần chỉnh sửa!!!" };
                return Json(data);
            }
        }

        [Route("PhienGiaoDichVL/Chitiet")]
        [HttpPost]
        public JsonResult Chitiet(string magd)
        {
            string result = GetDetail(magd);
            var data = new { status = "success", message = result };
            return Json(data);
        }

        [Route("PhienGiaoDichVL/DeleteDetail")]
        [HttpPost]
        public IActionResult DeleteDetail(int id)
        {
            var model = _db.phiengiaodichvl_ct.FirstOrDefault(t => t.id == id);
            var magd = model!.magd;
            _db.phiengiaodichvl_ct.Remove(model!);
            _db.SaveChanges();
            string result = GetDetail(magd!);
            var data = new { status = "success", message = result };
            return Json(data);
        }

        public string GetDetail(string magd)
        {
            string result = "";
            var model = _db.phiengiaodichvl_ct.Where(t => t.magd == magd);
            int record = 1;
            result = "<div class='card-body' id='frm_data_chitiet'>";
            result += "<table class='table table-striped table-bordered table-hover' id='datatable_4'>";
            result += "<thead>";
            result += "<tr style='text-align:center'>";
            result += "<th>STT</th>";
            result += "<th>Tên doanh nghiệp</th>";
            result += "<th>Vị trí tuyển</th>";
            result += "<th>Số lượng</th>";
            result += "<th>Thao tác</th>";
            result += "</tr>";
            result += "</thead>";
            result += "<tbody>";
            foreach (var item in model)
            {
                result += "<tr>";
                result += "<td style='text-align:center'>" + record++ + "</td>";
                result += "<td class='active'>" + item.name + "</td>";
                result += "<td>" + item.vitri + "</td>";
                result += "<td>" + item.soluong + "</td>";
                result += "<td>";
                result += "<button type='button' class='btn btn-sm btn-clean btn-icon' title='Xóa chi tiết'";
                result += " data-target='#DeleteCt_Modal' data-toggle='modal' onclick='GetDeleteCt(`" + item.id + "`)'>";
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
    }
}
