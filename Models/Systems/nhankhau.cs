using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class nhankhau
    {
        [Key]
        public long id { get; set; }
        public int? danhsach_id { get; set; }
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
        public string? nguoicovieclam { get; set; }
        public string? congvieccuthe { get; set; }
        public string? thamgiabhxh { get; set; }
        public string? hdld { get; set; }
        public string? noilamviec { get; set; }
        public string? loaihinhnoilamviec { get; set; }
        public string? diachinoilamviec { get; set; }
        public string? thatnghiep { get; set; }
        public string? thoigianthatnghiep { get; set; }
        public string? khongthamgiahdkt { get; set; }
        public string? ho { get; set; }
        public string? mqh { get; set; }
        public string? maloi { get; set; }
        public string? maloailoi { get; set; }
        public string? madv { get; set; }
        public string? kydieutra { get; set; }
        public int? soluongtrung { get; set; }
        public int? loaibiendong { get; set; }
        public string? truongbiendong { get; set; }
        public int? doituongtimvieclam { get; set; }
        public int? vieclammongmuon { get; set; }
        public string? nganhnghemongmuon { get; set; }
        public string? nganhnghemuonhoc { get; set; }
        public string? trinhdochuyenmonmuonhoc { get; set; }
        public string? sdt { get; set; }
        public int? khuvuc { get; set; }
        public string? thitruonglamviec { get; set; }
        public string? lydo { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
