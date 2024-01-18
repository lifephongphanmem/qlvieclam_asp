using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class dmtrinhdokythuat
    {
        [Key]
        public long id { get; set; }
        public string madmtdkt { get; set; } = null!;
        [Required(ErrorMessage ="Tên trình độ kỹ thuật không được để trống!!!")]
        public string tentdkt { get; set; } = null!;
        public string trangthai { get; set; } = null!;
        public string? mota { get; set; }
        public int stt { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
