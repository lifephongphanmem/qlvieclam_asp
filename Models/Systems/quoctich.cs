using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLVL_Binh.Models.Systems
{
    public class quoctich
    {
        [Key]
        public long id { get; set; }
        public string? maqg { get; set; }
        public string? tenqg { get; set; }
        public string? mota { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}