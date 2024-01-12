using Microsoft.AspNetCore.Mvc;
using QLVL_Binh.Database;
using QLVL_Binh.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CSDLGia_ASP.Controllers.Admin.Systems.Login
{
    public class LoginController : Controller
    {
        private readonly QLVL_BinhContext _db;
        public LoginController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("DangNhap")]
        [HttpGet]
        public IActionResult Login()
        {
            ViewData["Title"] = "Đăng nhập";
            return View("Views/Admin/Systems/Login/Login.cshtml");
        }

        [Route("SignIn")]
        [HttpPost]
        public IActionResult SignIn(string username, string password)
        {
            var serverName = Request.Host.Host;
            HttpContext.Session.SetString("ServerName", serverName);

            if (username != null && password != null)
            {
                var model = _db.Users.FirstOrDefault(u => u.username == username);

                if (model != null)
                {
                    string md5_password = "";
                    using (MD5 md5Hash = MD5.Create())
                    {
                        string change = Helpers.GetMd5Hash(md5Hash, password);
                        md5_password = change;
                    }
                    if (md5_password == model.password)
                    {
                        HttpContext.Session.SetString("SsAdmin", JsonConvert.SerializeObject(model));
                        return RedirectToAction("Index", "Home");
                        /*
                        if (model.status == 0)
                        {
                            ModelState.AddModelError("username", "Tài khoản bị khóa. Liên hệ với quản trị hệ thống !!!");
                            ViewData["username"] = username;
                            ViewData["password"] = password;
                            return View("Views/Admin/Systems/Auth/Login.cshtml");
                        }
                        else
                        {
                            HttpContext.Session.SetString("SsAdmin", JsonConvert.SerializeObject(model));
                            if (model.chucnangkhac == true)
                            {
                                var permissions = _db.Permissions.Where(p => p.Username == username);
                                HttpContext.Session.SetString("Permission", JsonConvert.SerializeObject(permissions));
                            }
                            else
                            {
                                var permissions = _db.Permissions.Where(p => p.Username == model.Chucnang);
                                HttpContext.Session.SetString("Permission", JsonConvert.SerializeObject(permissions));
                            }
                            return RedirectToAction("Index", "Home");
                        }*/
                    }
                    else
                    {
                        ModelState.AddModelError("password", "Mật khẩu truy cập không đúng !!!");
                        ViewData["username"] = username;
                        ViewData["Title"] = "Đăng nhập";
                        return View("Views/Admin/Systems/Login/Login.cshtml");
                    }
                }
                else
                {
                    ModelState.AddModelError("username", "Tài khoản truy cập không tồn tại !!!");
                    ViewData["Title"] = "Đăng nhập";
                    return View("Views/Admin/Systems/Login/Login.cshtml");
                }
            }
            else
            {
                ModelState.AddModelError("username", "Tài khoản truy cập không được để trống !!!");
                ModelState.AddModelError("password", "Mật khẩu truy cập không được để trống !!!");
                ViewData["Title"] = "Đăng nhập";
                return View("Views/Admin/Systems/Login/Login.cshtml");
            }
        }

        [Route("DangXuat")]
        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("Permission");
            HttpContext.Session.Remove("SsAdmin");
            return RedirectToAction("Login", "Login");
        }
    }
}
