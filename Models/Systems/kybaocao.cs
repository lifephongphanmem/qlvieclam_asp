using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLVL_Binh.Models.Systems
{
    public class kybaocao
    {
        [Key]
        public int id { get; set; }
        public string? kydieutra { get; set; }
        public string? noidung { get; set; }
        public string? madv_x { get; set; }
        public string? cqtiepnhan_x { get; set; }
        public string? trangthai_x { get; set; }
        public string? thoidiem_x { get; set; }
        public string? lydo_x { get; set; }
        public string? madv_h { get; set; }
        public string? cqtiepnhan_h { get; set; }
        public string? trangthai_h { get; set; }
        public string? thoidiem_h { get; set; }
        public string? lydo_h { get; set; }
        public string? madv_t { get; set; }
        public string? trangthai_t { get; set; }
        public string? thoidiem_t { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        [NotMapped] 
        public string? donvi { get; set;}
    }
}
