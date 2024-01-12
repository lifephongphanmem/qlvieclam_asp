using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLVL_Binh.Models.Systems
{
    public class chucnangs
    {
        [Key]
        public long id { get; set; }
        public string? maso { get; set; }
        public string? tencn { get; set; }
        public int? parent { get; set; }
        public int? capdo { get; set; }
        public string? trangthai { get; set; }
        public string? machucnang_goc { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        [NotMapped]
        public string? stt { get; set; }
    }
}
