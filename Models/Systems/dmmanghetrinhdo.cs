using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class dmmanghetrinhdo
    {
        [Key]
        public int id { get; set; }
        public string manghe { get; set; } = null!;
        public string madmmntd { get; set; } = null !;
        [Required(ErrorMessage ="Tên mã nghề trình độ không được để trống!!!")]
        public string tendmmntd { get; set; } = null!;
        public string? trangthai { get; set; }
        public string? mota { get; set; }
        public int stt { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
