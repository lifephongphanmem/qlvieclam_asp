using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class dmloaihinhhdkt
    {
        [Key]
        public long id { get; set; }
        public string madmlhkt { get; set; } = null!;
        [Required(ErrorMessage = "Tên loại hoạt động kinh tế không được để trống!!!")]
        public string tenlhkt { get; set; } = null!;
        public string? trangthai { get; set; }
        public string? mota { get; set; }
        public int stt { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
