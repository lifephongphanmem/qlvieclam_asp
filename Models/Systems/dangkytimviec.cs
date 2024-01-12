using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class dangkytimviec
    {
        [Key]
        public int id { get; set; }
        public string? kydieutra { get; set; }
        public string? hoten { get; set; }
        public string? ngaysinh { get; set; }
        public string? gioitinh { get; set; }
        public string? cccd { get; set; }
        public string? phone { get; set; }
        public string? dantoc { get; set; }
        public string? thuongtru { get; set; }
        public string? tamtru { get; set; }
        public string? trinhdogiaoduc { get; set; }
        public string? trinhdocmkt { get; set; }
        public string? loaithvp { get; set; }
        public string? tinhockhac { get; set; }
        public string? loaithk { get; set; }
        public string? ngoaingu1 { get; set; }
        public string? chungchinn1 { get; set; }
        public string? xeploainn1 { get; set; }
        public string? ngoaingu2 { get; set; }
        public string? chungchinn2 { get; set; }
        public string? xeploainn2 { get; set; }
        public string? kynangmem { get; set; }
        public string? kinhnghiem { get; set; }
        public string? nguoikhuyettat { get; set; }
        public string? tencongviec { get; set; }
        public string? manghe { get; set; }
        public string? chucvu { get; set; }
        public string? loaihinhkt { get; set; }
        public string? loaihdld { get; set; }
        public string? khanangcongtac { get; set; }
        public string? hinhthuclv { get; set; }
        public string? mucdichlv { get; set; }
        public string? luong { get; set; }
        public string? hotroan { get; set; }
        public string? phucloi { get; set; }
        public string? maphien { get; set; }
        public string? phiengd { get; set; }
        public string? linhvuc { get; set; }
        public string? tendn { get; set; }
        public string? madkkd { get; set; }
        public string? thoidiem { get; set; }
        public string? datsotuyen { get; set; }
        public string? nhanduocviec { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
