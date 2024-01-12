using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class dmnganhsxkd
    {
        [Key]
        public int id { get; set; }
        public string madmsxkd { get; set; } = null!;
        [Required(ErrorMessage ="Tên ngành sản xuất kinh doanh không được để trống!!!")]
        public string tensxkd { get; set; } = null!;
        public string? trangthai { get; set; }
        public string? mota { get; set; }
        public int stt { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
