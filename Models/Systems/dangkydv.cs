using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class dangkydv
    {
        [Key]
        public int id { get; set; }
        public int user { get; set; } = 0!;
        public int dichvu { get; set; }
        public string? state { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
