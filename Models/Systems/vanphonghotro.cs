using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class vanphonghotro
    {
        [Key]
        public int id { get; set; }
        public string? maso { get; set; }
        public string? vanphong { get; set; }
        public string? hoten { get; set; }
        public string? chucvu { get; set; }
        public string? sdt { get; set; }
        public string? skype { get; set; }
        public string? facebook { get; set; }
        public int sapxep { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
