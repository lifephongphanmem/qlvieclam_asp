using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class hopthu
    {
        [Key]
        public long id { get; set; }
        public string? tieude { get; set; }
        public string? noidung { get; set; }
        public string? file { get; set; }
        public string? madv { get; set; }
        public string? thoigiangui { get; set; }
        public string? mahuyen { get; set; }
        public string? trangthai { get; set; }
        public string? dvnhan { get; set; }
        public int? loaithu { get; set; }
        public string? matinh { get; set; }
        public string? lydo { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
