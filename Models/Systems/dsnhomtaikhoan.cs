using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLVL_Binh.Models.Systems
{
    public class dsnhomtaikhoan
    {
        public long id { get; set; }
        public int stt { get; set; }
        [Required(ErrorMessage ="Mã nhóm chức năng không được để trống")]
        public string manhomchucnang { get; set; } = null!;
        [Required(ErrorMessage = "Tên nhóm không được để trống")]
        public string tennhomchucnang { get; set; }=null!;
        public string? ghichu { get; set; }
        [NotMapped]
        public string? danhsachnhomchucnang { get; set; } 
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
