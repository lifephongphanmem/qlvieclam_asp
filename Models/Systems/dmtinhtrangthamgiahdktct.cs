using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLVL_Binh.Models.Systems
{
    public class dmtinhtrangthamgiahdktct
    {
        [Key]
        public long id { get; set; }
        public string manhom { get; set; } = null!;
        public string madmtgktct { get; set; } = null!;
        public string tentgktct { get; set; } = null!;
        public string trangthai { get; set; } = null!;
        public string? mota { get; set; }
        public int stt { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        [NotMapped]
        public int CoutCt { get; set; }
    }
}
