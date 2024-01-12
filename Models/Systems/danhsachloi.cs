using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class danhsachloi
    {
        [Key]
        public int id { get; set; }
        public string? hoten { get; set; }
        public string? gioitinh { get; set; }
        public DateTime ngaysinh { get; set; }
        public string? cmnd { get; set; }
        public string? dantoc { get; set; }
        public string? nation { get; set; }
        public string? tinh { get; set; }
        public string? huyen { get; set; }
        public string? xa { get; set; }
        public string? address { get; set; }
        public string? sobaohiem { get; set; }
        public string? trinhdogiaoduc { get; set; }
        public string? trinhdocmkt { get; set; }
        public string? nghenghiep { get; set; }
        public string? linhvucdaotao { get; set; }
        public string? loaihdld { get; set; }
        public DateTime bdhopdong { get; set; }
        public DateTime kthopdong { get; set; }
        public string? luong { get; set; }
        public string? pcchucvu { get; set; }
        public string? pcthamnien { get; set; }
        public string? pcthamniennghe { get; set; }
        public string? pcluong { get; set; }
        public string? pcbosung { get; set; }
        public DateTime bddochai { get; set; }
        public DateTime ktdochai { get; set; }
        public string? vitri { get; set; }
        public string? chucvu { get; set; }
        public DateTime bdbhxh { get; set; }
        public DateTime ktbhxh { get; set; }
        public string? luongbhxh { get; set; }
        public string? ghichu { get; set; }
        public int? company { get; set; } = 0!;
        public short? state { get; set; } = 0!; 
        public short? fromttdvvl { get; set; } = 0!; 
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
