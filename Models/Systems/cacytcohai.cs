using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLVL_Binh.Models.Systems
{
    public class cacytcohai
    {
        [Key]
        public long id { get; set; }
        public string? phanloai { get; set; }
        public string? mayt { get; set; }
        public string? tenyeuto { get; set; }
        public string? mota { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        [NotMapped]
        public string? stt { get; set; }
    }
}
