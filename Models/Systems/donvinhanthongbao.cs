using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class donvinhanthongbao
    {
        [Key]
        public int id { get; set; }
        public string? madv { get; set; }
        public string? mahopthu { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
