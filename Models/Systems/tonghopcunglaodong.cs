using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class tonghopcunglaodong
    {
        [Key]
        public int id { get; set; }
        public string? kydieutra { get; set; }
        public string? madv { get; set; }
        public string? tendv { get; set; }
        public string? ldtren15 { get; set; }
        public string? ldcovieclam { get; set; }
        public string? ldthatnghiep { get; set; }
        public string? ldkhongthamgia { get; set; }
        public string? thanhthi { get; set; }
        public string? nongthon { get; set; }
        public string? nam { get; set; }
        public string? nu { get; set; }
        public string? capdo { get; set; }
        public string? trongnuoc { get; set; }
        public string? nuocngoai { get; set; }
        public string? hocnghe { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime deleted_at { get; set; }
    }
}
