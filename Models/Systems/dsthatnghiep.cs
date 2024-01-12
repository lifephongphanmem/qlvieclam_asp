using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class dsthatnghiep
    {
        [Key]
        public int id { get; set; }
        public string? kydieutra { get; set; }
        public string? hoten { get; set; }
        public string? ngaysinh { get; set; }
        public string? gioitinh { get; set; }
        public string? cccd { get; set; }
        public string? bhxh { get; set; }
        public string? diachi { get; set; }
        public string? xa { get; set; }
        public string? huyen { get; set; }
        public string? nguyennhan { get; set; }
        public string? trinhdocmkt { get; set; }
        public string? nghenghiep { get; set; }
        public string? nghecongviec { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
