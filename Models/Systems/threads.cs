using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class threads
    {
        [Key]
        public long id { get; set; }
        public string? subject { get; set; }
        public string? attach { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime deleted_at { get; set; }
    }
}
