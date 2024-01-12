using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class dmchucvu
    {
        [Key]
        public long id { get; set; }
        [Required(ErrorMessage ="Tên chức vụ không được để trống !!!")]
        public string tencv { get; set; } = null!;
        public string?  mota { get; set; }
        public string? stt { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set;}
    }
}
