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
using QLVL_Binh.ViewModels.Systems.VM_DoanhNghiep;
using Azure.Core;

namespace QLVL_Binh.Controllers.Admin.DoanhnghiepDN
{
    public class DanhsachDNController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public DanhsachDNController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("DanhsachDN")]
        [HttpGet]
        public IActionResult Index(string huyen, string xa)
        {
           if (huyen == null|| huyen=="")
            {
                huyen = _db.danhmuchanhchinh.Where(x => x.capdo == "H").FirstOrDefault()!.name;
            }

            var parent = _db.danhmuchanhchinh.Where(x => x.capdo == "H" && x.name == huyen).FirstOrDefault()!.maquocgia;

            if (string.IsNullOrEmpty(xa))
            {
                xa = _db.danhmuchanhchinh.Where(x => x.capdo == "X" && x.parent== parent).FirstOrDefault()!.name;
            }
            var model = _db.company.Where(x=>x.xa==xa);
            ViewData["tenhuyen"] = huyen;
            ViewData["tenxa"] = xa;
            //ViewData["Tinh"] = _db.danhmuchanhchinh.Where(t => string.IsNullOrEmpty(t.parent) || t.parent == "0");
            ViewData["Huyen"] = _db.danhmuchanhchinh.Where(t => t.capdo == "H");
            ViewData["Xa"] = _db.danhmuchanhchinh.Where(t => t.capdo == "X" && t.parent == parent);
            ViewData["Tinh"] = _db.danhmuchanhchinh.Where(t => string.IsNullOrEmpty(t.parent) || t.parent == "0");
            ViewData["dvhcsn"] = _db.donvihanhchinhsunghiep;
            return View("Views/Admin/Doanhnghiep/Danhsach/Index.cshtml", model);

        }
        [HttpGet]
        public IActionResult GetXa(string mahuyen)
        {
            var xa = _db.danhmuchanhchinh.Where(x => x.parent == mahuyen);
            return Json(xa);
        }
        [Route("DanhsachDN/Store")]
        [HttpPost]
        public IActionResult Store(string dkkd_create, string name_create, string quymo_create, int Public_create, string phone_create, string fax_create, string website_create, string email_create,
            string tinh_create, string huyen_create, string xa_create, int khuvuc_create, string address_create, string khucn_create, string loaihinh_create, string nghanhnghe_create)
        {
            var model = new company
            {
                dkkd = dkkd_create,
                name = name_create,
                quymo = quymo_create,
                Public = Public_create,
                phone = phone_create,
                fax = fax_create,
                website = website_create,
                email = email_create,
                tinh = tinh_create,
                huyen = huyen_create,
                xa = xa_create,
                khuvuc = khuvuc_create,
                address = address_create,
                khucn = khucn_create,
                loaihinh = loaihinh_create,
                nganhnghe = nghanhnghe_create,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            _db.company.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "DanhsachDN");
        }
        /*[Route("DanhsachDN/NhuCauTd_Print")]
        [HttpPost]
        public IActionResult NhuCauTd_Print(int id_print1)
        {
            var tuyendung = _db.tuyendung.FirstOrDefault(x => x.id == id_print1);
            var doanhnghiep = _db.company.FirstOrDefault(x => x.user == tuyendung!.user);

            ViewData["name"] = doanhnghiep!.name;
            ViewData["address"] = doanhnghiep.address;
            ViewData["phone"] = doanhnghiep.phone;
            ViewData["fax"] = doanhnghiep.fax;
            ViewData["email"] = doanhnghiep.email;
            ViewData["dkkd"] = doanhnghiep.dkkd;
            ViewData["dmloaihinhhdkt"] = _db.dmloaihinhhdkt;

            var nn = Helpers.NganhNgheKinhDoanh();
            var tennn = "";
            foreach (var n in nn)
            {
                if (n.MaNghanhNghe == doanhnghiep.nganhnghe)
                {
                    tennn = n.TenNghanhNghe;
                    break;
                }
            }
            ViewData["tennn"] = tennn;
            return View("Views/Admin/Doanhnghiep/TuyenDung/NhuCauTd_Print.cshtml");
        }

        [Route("DanhsachDN/DangKyVL_Print")]
        [HttpPost]
        public IActionResult DangKyVL(int id_print2)
        {
            //id cua tuyen dung
            var model=_db.vitrituyendung.Where(x=>x.idtuyendung==id_print2);
            return View("Views/Admin/Doanhnghiep/TuyenDung/DangKyVL_Print.cshtml",model);
        }*/

        [Route("DanhsachDN/Detail")]
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var model = _db.company.Where(x => x.id == id).FirstOrDefault();
            var nguoilaodong = _db.nguoilaodong.Where(x => x.company == id).AsEnumerable();
            var thongtinkhac = new List<VM_Thongtin_DoanhNghiep>();
            thongtinkhac.Add(new VM_Thongtin_DoanhNghiep
            {
                Mota = "Tổng số lao động(tổng/nữ)",
                Soluong=nguoilaodong.Count().ToString()+'/'+ nguoilaodong.Where(x => x.gioitinh == "Nữ").Count().ToString(),
            });

            ViewData["name"] = model!.name;
            ViewData["model"] = model;
            ViewData["Tinh"] = _db.danhmuchanhchinh.Where(t => string.IsNullOrEmpty(t.parent) || t.parent == "0");
            ViewData["Huyen"] = _db.danhmuchanhchinh.Where(t => t.capdo == "H");
            ViewData["Xa"] = _db.danhmuchanhchinh.Where(t => t.capdo == "X");
            ViewData["dvhcsn"] = _db.donvihanhchinhsunghiep;
            
            //doc ra thong tin nguoilaodong
            thongtinkhac.Add(new VM_Thongtin_DoanhNghiep
            {
                Mota= "Số lao động ngoại tỉnh",
                Soluong= nguoilaodong.Where(x => x.tinh != "Quảng Bình").Count().ToString(),
            });

            //Không có HĐLĐ
            var loaihdld = nguoilaodong.Where(x => x.loaihdld != "Không có HĐLĐ");
            thongtinkhac.Add(new VM_Thongtin_DoanhNghiep
            {
                Mota = "Số lao động đã ký HĐLĐ (tổng/nữ)",
                Soluong = loaihdld.Count().ToString()+'/'+ loaihdld.Where(x=>x.gioitinh == "Nữ").Count().ToString(),
            });
            //nước ngoài
            var nation = nguoilaodong.Where(x => x.nation != "VN");
            thongtinkhac.Add(new VM_Thongtin_DoanhNghiep
            {
                Mota = "Số lao động nước ngoài (tổng/nữ)",
                Soluong = nation.Count().ToString() + '/' + nation.Where(x => x.gioitinh == "Nữ").Count().ToString(),
            });
            //tốt nghiệp phổ thông
            var trinhdogiaoduc = nguoilaodong.Where(x => x.trinhdogiaoduc == "Tốt nghiệp THPT");
            thongtinkhac.Add(new VM_Thongtin_DoanhNghiep
            {
                Mota = "Số lao động đã tốt nghiệp phổ thông",
                Soluong = trinhdogiaoduc.Count().ToString(),
            });
            //luong
            var luong = new List<VM_Luong_NguoiLaoDong>();
            var average = nguoilaodong.Average(x => int.Parse(x.luong));
            luong.Add(new VM_Luong_NguoiLaoDong
            {
                Mota = "Lương bình quân",
                Luong = average.ToString()
            });
            luong.Add(new VM_Luong_NguoiLaoDong
            {
                Mota = "Lương thấp nhất",
                Luong = nguoilaodong.Min(x => x.luong),
            });
            luong.Add(new VM_Luong_NguoiLaoDong
            {
                Mota = "Lương cao nhất",
                Luong = nguoilaodong.Max(x => x.luong),
            });
            ViewData["luong"] = luong;

            //doc ra so luong cac loai cmkt
            var trinhdocmkt = nguoilaodong
                .GroupBy(x => x.trinhdocmkt)
                .Select(group => new VM_Count_Chucnang
                {
                    Mota = group.Key,
                    Count = group.Count()
                });
            ViewData["trinhdocmkt"] = trinhdocmkt;

            //doc ra so luong cac loai linh vuc daotao
            var linhvucdaotao = nguoilaodong
                .GroupBy(x => x.linhvucdaotao)
                .Select(group => new VM_Count_Chucnang
                {
                    Mota = group.Key,
                    Count = group.Count()
                });
            ViewData["linhvucdaotao"] = linhvucdaotao;

            //doc ra so luong cua cac nghenghiep
            var nghenghiep = nguoilaodong
                .GroupBy(x => x.nghenghiep)
                .Select(group => new VM_Count_Chucnang
                {
                    Mota = group.Key,
                    Count = group.Count()
                });
            ViewData["nghenghiep"] = nghenghiep;
            ViewData["thongtinkhac"] = thongtinkhac;
            return View("Views/Admin/Doanhnghiep/Danhsach/Detail.cshtml", model);

        }
    }
}

