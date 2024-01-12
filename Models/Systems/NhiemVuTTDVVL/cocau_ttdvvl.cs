using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLVL_Binh.Models.Systems.NhiemVuTTDVVL
{
    public class cocau_ttdvvl
    {
        [Key]
        public int id { get; set; }
        public string? hoten { get; set; }
        public string? gioitinh { get; set; }
        public string? ngaysinh { get; set; }
        public string? cccd { get; set; }
        public string? bhxh { get; set; }
        public string? thuongtru { get; set; }
        public string? diachi { get; set; }
        public string? uutien { get; set; }
        public string? dantoc { get; set; }
        public string? trinhdogiaoduc { get; set; }
        public string? chuyenmonkythuat { get; set; }
        public string? chuyennganh { get; set; }
        public string? tinhtranghdkt { get; set; }
        public string? congvieccuthe { get; set; }
        public string? thamgiabhxh { get; set; }
        public string? hdld { get; set; }
        public string? noilamviec { get; set; }
        public string? loaihinhnoilamviec { get; set; }
        public string? diachinoilamviec { get; set; }
        public string? madv { get; set; }
        public string? sdt { get; set; }
        //ma trong niem vu tt
        public int nhiemvu_id { get; set; }
        public string? name { get; set; }
        public string? manv { get; set; }
        public string? magoc { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        [NotMapped]
        public string? daihoc { get; set; }
        [NotMapped]
        public string? caodang { get; set; }
        [NotMapped]
        public string? khac { get; set; }
    }
}
