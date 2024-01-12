using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class ungvienhocvan
    {
        [Key]
        public int id { get; set; }
        public string? user { get; set; }
        public string? chuyennganh { get; set; }
        public string? truong { get; set; }
        public string? bangcap { get; set; }
        public string? tungay { get; set; }
        public string? denngay { get; set; }
        public string? thanhtuu { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
