using static System.Net.Mime.MediaTypeNames;
using System.Numerics;
using System.ComponentModel.DataAnnotations;

namespace QLVL_Binh.Models.Systems
{
    public class company
    {
        [Key]
        public long id { get; set; }        
        public string? name { get; set; }
        public string? masodn { get; set; }
        public string? dkkd { get; set; }
        public string? phone { get; set; }
        public string? fax { get; set; }
        public string? website { get; set; }
        [EmailAddress(ErrorMessage ="Địa chỉ email không hợp lệ")]
        public string? email { get; set; }
        public string? address { get; set; }
        public string? tinh { get; set; }
        public string? huyen { get; set; }
        public string? xa { get; set; }
        public int khuvuc { get; set; }
        public string? khucn { get; set; }
        public string? loaihinh { get; set; }
        public int Public { get; set; }
        public string? image { get; set; }
        public int user { get; set; }
        public string? nganhnghe { get; set; }
        public string? remember_token { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string? madv { get; set; }
        public string? quymo { get; set; }
        public int sld { get; set; }
    }
}
