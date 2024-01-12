using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class report
    {
        [Key]
        public int id { get; set; }
        public string? type { get; set; }
        public short? result { get; set; }
        public string? datatable { get; set; }
        public string? lastid { get; set; }
        public DateTime time { get; set; }
        public int user { get; set; }
        public string? note { get; set; }   
        public string? iprequest { get; set; }
        public string? kydieutra { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
