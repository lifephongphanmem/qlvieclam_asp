using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class vitrituyendung
    {
        [Key]
        public int id { get; set; }
        public int idtuyendung { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public short? soluong { get; set; }
        public string? manghe { get; set; }
        public string? capbac { get; set; }
        public string? chucvu { get; set; }
        public string? tdgd { get; set; }
        public string? tdcmkt { get; set; }
        public string? chuyennganh { get; set; }
        public string? trinhdonghe { get; set; }
        public short? bacnge { get; set; }
        public string? ngoaingu1 { get; set; }
        public string? chungchinn1 { get; set; }
        public string? xeploainn1 { get; set; }
        public string? ngoaingu2 { get; set; }
        public string? chungchinn2 { get; set; }
        public string? xeploainn2 { get; set; }
        public string? loaithvp { get; set; }
        public string? tinhockhac { get; set; }
        public string? loaithk { get; set; }
        public string? kynangmem { get; set; }
        public string? yeucaukn { get; set; }
        public string? diadiem { get; set; }
        public string? loaihopdong { get; set; }
        public string? yeucauthem { get; set; }
        public string? hinhthuclv { get; set; }
        public string? mucdichlv { get; set; }
        public string? mucluong { get; set; }
        public string? hotroan { get; set; }
        public string? phucloi { get; set; }
        public string? noilamviec { get; set; }
        public string? trongluongnang { get; set; }
        public string? dungvadilai { get; set; }
        public string? nghenoi { get; set; }
        public string? thiluc { get; set; }
        public string? thaotactay { get; set; }
        public string? dungtay { get; set; }
        public string? uutien { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        [DefaultValue("CXD")]
        public string? state { get; set; }
    }
}
