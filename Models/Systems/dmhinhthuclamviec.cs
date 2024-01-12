using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class dmhinhthuclamviec
    {
        [Key]
        public int id { get; set; }
        public string tendm { get; set; } = null!;
        public string? stt { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
