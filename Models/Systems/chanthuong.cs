using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLVL_Binh.Models.Systems
{
    public class chanthuong
    {
        [Key]
        public long id { get; set; }
        public string? maso { get; set; }
        public string? tenchanthuong { get; set; }
        public int? capdo { get; set; }
        public string? magoc { get; set; }
        public string? mota { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        [NotMapped] public string? stt { get; set; }
    }
}