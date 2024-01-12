using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class dmloailaodong
    {
        [Key]
        public int id { get; set; }
        public string madmlld { get; set; } = null!;
        [Required(ErrorMessage ="Tên loại lao động không được để trống!!!")]
        public string tenlld { get; set; } = null!;
        public string? trangthai { get; set; }
        public int stt { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
