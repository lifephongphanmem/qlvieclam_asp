using Microsoft.AspNetCore.Mvc;
using QLVL_Binh.Database;
using QLVL_Binh.Models;
using System.Diagnostics;
using QLVL_Binh.Helper;

namespace QLVL_Binh.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly QLVL_BinhContext _db;

		public HomeController(ILogger<HomeController> logger, QLVL_BinhContext db)
		{
			_logger = logger;
			_db = db;
		}

		public IActionResult Index()
		{
			var Sessions = HttpContext.Session.GetString("SsAdmin");
			if (string.IsNullOrEmpty(Sessions))
			{
				ViewData["Title"] = "Đăng nhập hệ thống";
				return RedirectToAction("Login", "Login");
			}
			else
			{
				var yearNow = DateTime.Now.Year.ToString();
				ViewData["year"] = yearNow;

				//khi doc data nho doc ky dieu tra voi yearNow
				var tong = _db.nhankhau.Count();
				var nguoicovieclam = _db.nhankhau.Where(x => x.nguoicovieclam == "1").Count();
				var thatnghiep = _db.nhankhau.Where(x => x.thatnghiep == "1").Count();
				var khongthamgiahdkt = _db.nhankhau.Where(x => x.khongthamgiahdkt == "1").Count();
				
				ViewData["nguoicovieclam"] = nguoicovieclam;
				ViewData["thatnghiep"] = thatnghiep;
				ViewData["khongthamgiahdkt"] = khongthamgiahdkt;

				ViewData["nguoicovieclam_percent"] = Helpers.Percent(nguoicovieclam,tong);
				ViewData["thatnghiep_percent"] = Helpers.Percent(thatnghiep, tong);
				ViewData["khongthamgiahdkt_percent"] = Helpers.Percent(khongthamgiahdkt, tong);
				
				ViewData["tong"] = tong;
				ViewData["Title"] = "Trang chủ";
				ViewData["MenuLv1"] = "menu_home";

				var tongDn = _db.company.Count();
				var activeDn = _db.company.Where(x=>x.Public==1).Count();
				var tong_nguoilaodong = _db.nguoilaodong.Count();
				var active_nguoilaodong = _db.nguoilaodong.Where(x=>x.state==1).Count();

				ViewData["tongDn"] = tongDn;
				ViewData["activeDn"] = activeDn;
				ViewData["tong_nguoilaodong"] = tong_nguoilaodong;
				ViewData["active_nguoilaodong"] = active_nguoilaodong;
				ViewData["tintd"] = _db.tuyendung.Count();
				ViewData["total_vitrituyendung"] = _db.vitrituyendung.Sum(x=>x.soluong);

				ViewData["activeDn_percent"] = Helpers.Percent(activeDn, tongDn);
				ViewData["active_nguoilaodong_percent"] = Helpers.Percent(active_nguoilaodong, tong_nguoilaodong);
				ViewData["TenDonViCapBanQuyen"] = "Công ty TNHH phát triển phần mềm Cuộc Sống.";
				return View("Views/Home/Index.cshtml");
			}
		}


		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}