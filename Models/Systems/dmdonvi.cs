using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLVL_Binh.Models.Systems
{
    public class dmdonvi
    {
        [Key]
        public long id { get; set; }
        public string? madv { get; set; }
        public string? email { get; set; }
        public string? maxa { get; set; }
        public string? mahuyen { get; set; }
        public string? matinh { get; set; }
        public string? tendv { get; set; }
        public string? diachi { get; set; }
        public string phanloaitaikhoan { get; set; } = null!;
        public string? caphanhchinh { get; set; }
        public string? madvcq { get; set; }
        public string? diadanh { get; set; }
        public string? chucvuky { get; set; }
        public string? nguoiky { get; set; }
        public string? ttlienhe { get; set; }
        public string? tendvhienthi { get; set; }
        public string? madiaban { get; set; }
        public string? madvbc { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        [NotMapped]
        public string? khuvuchanhchinh { get; set; }
    }
}
