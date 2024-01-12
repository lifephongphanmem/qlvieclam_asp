using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems.PhienGiaoDichVL
{
    public class phiengiaodichvl
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? magd { get; set; }
        public string? huyen { get; set; }
        public string? xa { get; set; }
        public int? nguoilaodong { get; set; }
        public string? trangthai { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
