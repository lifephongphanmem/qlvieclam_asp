using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class ungvien
    {
        [Key]
        public int id { get; set; }
        public string? user { get; set; }
        public string? avatar { get; set; }
        public string? hoten { get; set; }
        public string? gioitinh { get; set; }
        public string? ngaysinh { get; set; }
        public string? phone { get; set; }
        public string? tinh { get; set; }
        public string? huyen { get; set; }
        public string? xa { get; set; }
        public string? address { get; set; }
        public string? capbac { get; set; }
        public string? honnhan { get; set; }
        public string? hinhthuclv { get; set; }
        public string? luong { get; set; }
        public string? trinhdocmkt { get; set; }
        public string? word { get; set; }
        public string? excel { get; set; }
        public string? powerpoint { get; set; }
        public string? gioithieu { get; set; }
        public string? muctieu { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
