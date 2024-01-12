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
using Microsoft.EntityFrameworkCore.Storage;

namespace QLVL_Binh.Controllers.Admin.Danhmuc.VeSinhAnToanLD
{
    public class CacYtCoHaiController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public CacYtCoHaiController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("CacYeuToCoHai")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.cacytcohai;
            int stt_goc = 1;
            int stt = 1;
            var newlist = new List<cacytcohai>();
            foreach (var goc in model.Where(x => x.phanloai == "00"))
            {
                newlist.Add(new cacytcohai
                {
                    tenyeuto = goc.tenyeuto,
                    phanloai = goc.phanloai,
                    stt = Helpers.ConvertIntToRoman(stt_goc),
                });
                stt_goc++;
                foreach (var item in model.Where(x => x.phanloai == goc.mayt))
                {
                    newlist.Add(new cacytcohai
                    {
                        tenyeuto = item.tenyeuto,
                        phanloai=item.phanloai,
                        stt = stt.ToString()
                    });
                    stt++;
                }
            }
            return View("Views/Admin/Danhmuc/VeSinhAnToanLD/CacYtCoHai/Index.cshtml", newlist);
        }
    }
}
