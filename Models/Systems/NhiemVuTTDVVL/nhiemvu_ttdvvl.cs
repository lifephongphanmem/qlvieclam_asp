using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems.NhiemVuTTDVVL
{
    public class nhiemvu_ttdvvl
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? manv { get; set; }
        public string? magoc { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

    }
}
