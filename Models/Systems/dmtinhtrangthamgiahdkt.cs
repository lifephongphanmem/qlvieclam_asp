using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLVL_Binh.Models.Systems
{
    public class dmtinhtrangthamgiahdkt
    {
        [Key]
        public long id { get; set; }
        public string madmtgkt { get; set; } = null!;
        [Required(ErrorMessage = "Tên tình trạng tham gia hoạt động kinh tế không được để trống!!!")]
        public string tentgkt { get; set; } = null!;
        public string? trangthai { get; set; }
        public string? mota { get; set; }
        public int stt { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        [NotMapped]
        public int CoutCt { get; set; }
    }
}
