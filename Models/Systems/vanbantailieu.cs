using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class vanbantailieu
    {
        [Key]
        public int id { get; set; }
        public string? tenvb { get; set; }
        public string? file { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
