using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLVL_Binh.Models.Systems
{
    public class danhmuchanhchinh
    {
        [Key]
        public long id { get; set; }
        public short Public { get; set; }
        public string? kv { get; set; }
        [Required(ErrorMessage = "Tên khu vực hành chính không được để trống ")]
        public string name { get; set; } = null!;
        public string? description { get; set; }
        public string? level { get; set; }
        public string? parent { get; set; }
        public string? maquocgia { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string? madvql { get; set; }
        public string? madb { get; set; }
        public string? capdo { get; set; }
        [NotMapped]
        public int stt { get; set; }
    }
}
