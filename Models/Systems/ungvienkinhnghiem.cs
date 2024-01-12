using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class ungvienkinhnghiem
    {
        [Key]
        public int id { get; set; }
        public string? user { get; set; }
        public string? congty { get; set; }
        public string? quymo { get; set; }
        public string? linhvuc { get; set; }
        public string? chucdanh { get; set; }
        public string? ngayvao { get; set; }
        public string? ngaynghi { get; set; }
        public string? mota { get; set; }
        public string? chitiet { get; set; }
        public string? lydo { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
