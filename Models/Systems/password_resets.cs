using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class password_resets
    {
        [Key]
        public int id { get; set; }
        public string? email { get; set; }
        public string? token { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
