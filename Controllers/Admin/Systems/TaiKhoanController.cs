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
using System.Text.RegularExpressions;

namespace QLVL_Binh.Controllers.Admin.Systems.TaiKhoan
{
    public class TaiKhoanController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public TaiKhoanController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("TaiKhoan")]
        [HttpGet]
        public IActionResult Index(string type)
        {
            var models = _db.Users.AsQueryable();
            if (string.IsNullOrEmpty(type)) {
                //models = models.Where(x =>x.phanloaitk==2);
            }
            else
            {
                //models = models.Where(x => x.phanloaitk == int.Parse(type));
            }
            /*var models = from us in _db.Users
                         join dv in _db.dmdonvi on us.madv equals dv.madv
                         select new Users
                         {
                             Id = us.Id,
                             name = us.name,
                             DonViQuanLy = dv.tendv,
                             username = us.username,
                             status = us.status,
                         };*/
            ViewData["DonViQuanLy"] = _db.dmdonvi;
            ViewData["DonViBaoCao"] = _db.dmdonvi.Where(x => x.phanloaitaikhoan != "TH");
            ViewData["DSNhomTaiKhoan"] = _db.dsnhomtaikhoan;

            return View("Views/Admin/Systems/TaiKhoan/Index.cshtml", models);
        }
        [Route("TaiKhoan/Store")]
        [HttpPost]
        public IActionResult Store(string madv_create, string madvbc_create, string name_create, string username_create,string LoaitaiKhoan_create,string capdo_create,
            string password_create, string manhomchucnang_create)
        {
            var checkusername = _db.Users.FirstOrDefault(x => x.username == username_create);
            if (checkusername == null)
            {
                Regex regex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20}$");
                if (regex.IsMatch(password_create))
                {
                    string PassMD5 = "";
                    using (MD5 md5Hash = MD5.Create())
                    {
                        PassMD5 = Helpers.GetMd5Hash(md5Hash, password_create);

                    }
                    password_create = PassMD5;
                    var model = new Users()
                    {
                        madv = madv_create,
                        madvbc = madvbc_create,
                        name = name_create,
                        username = username_create,
                        password = password_create,
                        manhomchucnang = manhomchucnang_create,
                        created_at = DateTime.Now,
                        status = 1,
                    };
                    _db.Users.Add(model);
                    _db.SaveChanges();
                }
            }
           
            return RedirectToAction("Index", "TaiKhoan");
        }
        
        [Route("TaiKhoan/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.Users.FirstOrDefault(p => p.Id == id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row text-left'>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Đơn vị quản lý</b></label>";
                result += "<select type='text; id='parent_edit' name='parent_edit' class='form-control'>";
                foreach (var item in _db.dmdonvi)
                {
                    result += "<option value='" + item.madv + "'";
                    if (item.madv == model.madv)
                    {
                        result += " selected='selected'";
                    }
                    result += ">" + item.tendv + "</option>";
                }
                result += "</select>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Đơn vị báo cáo</b></label>";
                result += "<select type='text; id='parent_edit' name='parent_edit' class='form-control'>";
                foreach (var item in _db.dmdonvi.Where(x => x.phanloaitaikhoan != "TH"))
                {
                    result += "<option value='" + item.madv + "'";
                    if (item.madv == model.madv)
                    {
                        result += " selected='selected'";
                    }
                    result += ">" + item.tendv + "</option>";
                }
                result += "</select>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên tài khoản</b></label>";
                result += "<input type='number' id='name_edit' name='name_edit' value='" + model.name + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
               
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tài khoản truy cập</b></label>";
                result += "<input type='number' id='username_edit' name='username_edit' value='" + model.username + "' class='form-control'/>";
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
                result += "<label><b>Đơn vị báo cáo</b></label>";
                result += "<select type='text; id='parent_edit' name='parent_edit' class='form-control'>";
                result += "<option value='T'>Tài khoản cấp tỉnh</option>";
                result += "<option value='H'>Tài khoản cấp huyện</option>";
                result += "<option value='X'>Tài khoản cấp xã</option>";
                result += "</select>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Email</b></label>";
                result += "<input type='password' id='password_edit' name='password_edit' value='" + model.password + "' class='form-control'/>";
                result += "<span class='error errorpass text-danger'></span>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Nhóm chức năng</b></label>";
                result += "<select type='text; id='parent_edit' name='parent_edit' class='form-control'>";
                foreach (var item in _db.dsnhomtaikhoan)
                {
                    result += "<option value='" + item.manhomchucnang + "'";
                    if (item.manhomchucnang == model.manhomchucnang)
                    {
                        result += " selected='selected'";
                    }
                    result += ">" + item.tennhomchucnang + "</option>";
                }
                result += "</select>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Đơn vị báo cáo</b></label>";
                result += "<select type='text; id='parent_edit' name='parent_edit' class='form-control'>";
                result += "<option value='1'>Kích hoạt</option>";
                result += "<option value='2'>Khóa</option>";
                result += "<option value='0'>Chưa kích hoạt</option>";
                result += "</select>";
                result += "</div>";
                result += "</div>";
                result += "<input hidden type='text' id='id_edit' name='id_edit' value='" + model.Id + "'/>";
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
        
        [Route("TaiKhoan/Update")]
        [HttpPost]
        public IActionResult Update(string madv_edit, string madvbc_edit, string name_edit, string username_edit, string LoaitaiKhoan_edit, 
            string capdo_edit,string password_edit, string manhomchucnang_edit,int id_edit)
        {
            var model = _db.Users.FirstOrDefault(t => t.Id == id_edit);
            if (model != null)
            {
                Regex regex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20}$");
                if (regex.IsMatch(password_edit))
                {
                    string PassMD5 = "";
                    using (MD5 md5Hash = MD5.Create())
                    {
                        PassMD5 = Helpers.GetMd5Hash(md5Hash, password_edit);

                    }
                    password_edit = PassMD5;
                    model.madv = madv_edit;
                    model.madvbc = madvbc_edit;
                    model.name = name_edit;
                    model.username = username_edit;
                    model.LoaitaiKhoan = LoaitaiKhoan_edit;
                    model.capdo = capdo_edit;
                    model.password = password_edit;
                    model.manhomchucnang = manhomchucnang_edit;
                    model.updated_at = DateTime.Now;
                    _db.Users.Update(model);
                    _db.SaveChanges();
                }
            }

            return RedirectToAction("Index", "TaiKhoan");
        }
        [Route("TaiKhoan/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.Users.FirstOrDefault(t => t.Id == id_delete);
            if (model != null)
            {
                _db.Users.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "TaiKhoan");
        }
    }
}
