using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class danhsach
    {
        [Key]
        public int id { get; set; }
        public int xa { get; set; }
        public int huyen { get; set; }
        public int tinh { get; set; }
        public int soluong { get; set; }
        public int soho { get; set; }
        public string? kydieutra { get; set; }
        public string? user_id { get; set; }
        public string? ghichu { get; set; }
        public string? donvinhap { get; set; }
        public int loi_cccd { get; set; }
        public int loi_hoten { get; set; }
        public int loi_ngaysinh { get; set; }
        public int loi_loai2 { get; set; }
        public int loi_loai3 { get; set; }
        public int loi_loai4 { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
