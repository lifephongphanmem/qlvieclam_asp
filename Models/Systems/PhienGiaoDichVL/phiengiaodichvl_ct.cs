using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems.PhienGiaoDichVL
{
    public class phiengiaodichvl_ct
    {
        [Key]
        public int id { get; set; }
        public string? magd { get; set; }
        //doanh nghiep
        public string? name { get; set; }
        public int? user { get; set; }
        public string? noidung { get; set; }
        public string? vitri { get; set; }
        public int? soluong { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
