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

namespace QLVL_Binh.Controllers.Admin.CungLaoDong
{
    public class BaoCaoController : Controller
    {
        private readonly QLVL_BinhContext _db;

        public BaoCaoController(QLVL_BinhContext db)
        {
            _db = db;
        }

        

        [Route("BaoCaoCungLaoDong")]
        [HttpGet]
        public IActionResult BaoCaoCungLaoDong()
        {
            return View("Views/Admin/CungLaoDong/BaoCao/CungLD_Report.cshtml");
        }
    }
}

