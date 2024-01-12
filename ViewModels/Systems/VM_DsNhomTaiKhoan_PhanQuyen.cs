namespace QLVL_Binh.ViewModels.Systems
{
    public class VM_DsNhomTaiKhoan_PhanQuyen
    {
        public long id { get; set; }
        public string? stt { get; set; }
        public string? tennhomchucnang { get; set; }
        public string? tencn { get; set; }
        public string? manhomchucnang { get; set; }
        public string? machucnang { get; set; }
        public bool phanquyen { get; set; }
        public bool danhsach { get; set; }
        public bool thaydoi { get; set; }
        public bool hoanthanh { get; set; }
        public int? capdo { get; set; }
        public int? parent { get; set; }
        public string? machucnang_goc { get; set; }
    }
}
