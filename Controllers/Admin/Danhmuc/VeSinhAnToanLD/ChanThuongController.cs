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
    public class ChanThuongController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public ChanThuongController(QLVL_BinhContext db)
        {
            _db = db;
        }

        [Route("ChanThuong")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.chanthuong;
            var newlist = new List<chanthuong>();
            int stt_goc = 1;
            int stt = 1;
            foreach (var goc in model.Where(x => x.magoc ==null))
            {
                newlist.Add(new chanthuong
                {
                    tenchanthuong = goc.tenchanthuong,
                    magoc = goc.magoc,
                    stt = Helpers.ConvertIntToRoman(stt_goc),
                });
                stt_goc++;

                foreach (var item in model.Where(x => x.magoc == goc.maso))
                {
                    newlist.Add(new chanthuong
                    {
                        tenchanthuong = item.tenchanthuong,
                        magoc = item.magoc,
                        stt=stt.ToString()
                    });
                    stt++;
                }
            }
            return View("Views/Admin/Danhmuc/VeSinhAnToanLD/ChanThuong/Index.cshtml", newlist);
        }
    }
}
