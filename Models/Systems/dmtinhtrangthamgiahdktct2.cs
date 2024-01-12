using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class dmtinhtrangthamgiahdktct2
    {
        [Key]
        public long id { get; set; }
        public string manhom2 { get; set; } = null!;
        public string madmtgktct2 { get; set; } = null!;
        public string tentgktct2 { get; set; } = null!;
        public string trangthai { get; set; } = null!;
        public string? mota { get; set; }
        public int stt { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
