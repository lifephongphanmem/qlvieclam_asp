using QLVL_Binh.Models.Systems;
using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class tuyendung
    {
        [Key]
        public int id { get; set; }
        public string? noidung { get; set; }
        public string? type { get; set; }
        public string? contact { get; set; }
        public string? phonetd { get; set; }
        public string? emailtd { get; set; }
        public string? chucvutd { get; set; }
        public string? contacttype { get; set; }
        public string? yeucau { get; set; }
        public short? state { get; set; }
        public short? datuyen { get; set; }
        public short? datuyentutt { get; set; }
        public int? user { get; set; }
        public DateTime thoihan { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        //public List<vitrituyendung>? vitrituyendung { get;}
    }
}
