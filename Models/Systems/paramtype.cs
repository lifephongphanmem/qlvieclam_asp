using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class paramtype
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
