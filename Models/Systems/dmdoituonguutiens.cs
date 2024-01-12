using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class dmdoituonguutiens
    {
        [Key]
        public int id { get; set; }
        public string madmdt { get; set; } = null!;
        [Required(ErrorMessage ="Tên đối tượng không được để trống!!!")]
        public string tendoituong { get; set; }=null!;
        public string? trangthai { get; set; }
        public int stt { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set;}
    }
}
