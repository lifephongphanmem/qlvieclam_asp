using static System.Net.Mime.MediaTypeNames;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLVL_Binh.Models.Systems
{
    public enum Status
    {
        Chưa_kích_hoạt = 0,
        Đã_kích_hoạt= 1,
        Đang_bị_khóa =2,
    }
    public enum PhanLoaitk
    {
        Đơn_vị=1,
        Doanh_nghiệp=2,
    }
    public class Users
    {
        [Key]
        public long Id { get; set; }
        public string name { get; set; } = null!;
        [EmailAddress(ErrorMessage ="Địa chỉ email không hợp lệ")]
        public string? email { get; set; }        
        public string password { get; set; }=null!;
        public short? level { get; set; }
        public string? remember_token { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public short Public { get; set; }
        public string? image { get; set; }
        public short? category { get; set; }
        public string madv { get; set; } = null!;
        public string? maxa { get; set; }
        public string? mahuyen { get; set; }
        public string? matinh { get; set; } 
        [Required(ErrorMessage ="Thông tin không được để trống")]           
        public string username { get; set; } = null!;
        public PhanLoaitk phanloaitk { get; set; }
        public int status { get; set; }
        public string? sadmin { get; set; }
        public int solandn { get; set; }
        public string? manhomchucnang { get; set; }
        public bool nhaplieu { get; set; }
        public bool tonghop { get; set; }
        public bool hethong { get; set; }
        public bool chucnangkhac { get; set; }
        public string? capdo { get; set; }
        public string? madvbc { get; set; }
        [NotMapped]
        public string? DonViQuanLy { get; set; }
        [NotMapped]
        public string? LoaitaiKhoan { get; set; }
    }
}
