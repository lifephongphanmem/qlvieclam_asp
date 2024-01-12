using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class dsnhomtaikhoan_phanquyen
    {
        [Key]
        public int id { get; set; }
        public string? manhomchucnang { get; set; }
        public string? machucnang { get; set; }
        public bool phanquyen { get; set; }
        public bool danhsach { get; set; }
        public bool thaydoi { get; set; }
        public bool hoanthanh { get; set; }
        public string? ghichu { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public bool DeleteRecordTrash { get; set; }
    }
}
