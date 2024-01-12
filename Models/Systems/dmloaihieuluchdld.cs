using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class dmloaihieuluchdld
    {
        [Key]
        public int id { get; set; }
        public string madmlhl { get; set; } = null!;
        [Required(ErrorMessage = "Tên loại hiệu lực hợp đồng lao động không được để trống!!!")]
        public string tenlhl { get; set; } = null!;
        public string? trangthai { get; set; }
        public string? mota { get; set; }
        public int stt { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
