using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class dmtrinhdogdpt
    {
        [Key]
        public int id { get; set; }
        public string madmgdpt { get; set; } = null!;
        [Required(ErrorMessage ="Tên trình độ giáo dục phổ thông không được để trống!!!")]
        public string tengdpt { get; set; }= null!;
        public string? trangthai { get; set; }
        public string? stt { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
