using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class capbac
    {
        [Key]
        public int id { get; set; }
        public string? madm { get; set; }
        public string? tendm { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
