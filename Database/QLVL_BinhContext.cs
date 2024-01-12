using Microsoft.EntityFrameworkCore;
using QLVL_Binh.Models.Systems;
using QLVL_Binh.Models.Systems.PhienGiaoDichVL;

namespace QLVL_Binh.Database
{
    public class QLVL_BinhContext : DbContext
    {
        public QLVL_BinhContext(DbContextOptions<QLVL_BinhContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<dmchucvu> dmchucvu { get; set; }
        //
        public DbSet<dmdoituonguutiens> dmdoituonguutiens { get; set; }
        public DbSet<dmmanghetrinhdo> dmmanghetrinhdo { get; set; }
        public DbSet<dmtrinhdogdpt> dmtrinhdogdpt { get; set; }
        public DbSet<dmtrinhdokythuat> dmtrinhdokythuat { get; set; }
        public DbSet<dmnganhsxkd> dmnganhsxkd { get; set; }
        public DbSet<dmloailaodong> dmloailaodong { get; set; }
        public DbSet<dmloaihinhhdkt> dmloaihinhhdkt { get; set; }
        public DbSet<dmloaihieuluchdld> dmloaihieuluchdld { get; set; }
        public DbSet<dmtinhtrangthamgiahdkt> dmtinhtrangthamgiahdkt { get; set; }
        public DbSet<dmtinhtrangthamgiahdktct> dmtinhtrangthamgiahdktct { get; set; }
        public DbSet<dmtinhtrangthamgiahdktct2> dmtinhtrangthamgiahdktct2 { get; set; }
        public DbSet<nghecongviec> nghecongviec { get; set; }
        public DbSet<dmhinhthuclamviec> dmhinhthuclamviec { get; set; }
        public DbSet<nguyennhanthatnghiep> nguyennhanthatnghiep { get; set; }
        public DbSet<cacytcohai> cacytcohai { get; set; }
        public DbSet<chanthuong> chanthuong { get; set; }
        // Danh mục chung
        public DbSet<Users> Users { get; set; }
        public DbSet<chucnangs> chucnangs { get; set; }
        public DbSet<dmdonvi> dmdonvi { get; set; }
        public DbSet<company> company { get; set; }
        public DbSet<danhmuchanhchinh> danhmuchanhchinh { get; set; }
        public DbSet<dsnhomtaikhoan> dsnhomtaikhoan { get; set; }
        public DbSet<dsnhomtaikhoan_phanquyen> dsnhomtaikhoan_phanquyen { get; set; }
        public DbSet<dstaikhoan_phanquyen> dstaikhoan_phanquyen { get; set; }
        public DbSet<capbac> capbac { get; set; }
        public DbSet<dangkydv> dangkydv { get; set; }
        public DbSet<dangkytimviec> dangkytimviec { get; set; }
        public DbSet<danhsach> danhsach { get; set; }
        public DbSet<danhsachloi> danhsachloi { get; set; }
        public DbSet<dichvu> dichvu { get; set; }
        public DbSet<donvinhanthongbao> donvinhanthongbao { get; set; }
        public DbSet<dsthatnghiep> dsthatnghiep { get; set; }
        public DbSet<hopthu> hopthu { get; set; }
        public DbSet<kybaocao> kybaocao { get; set; }
        public DbSet<messages> messages { get; set; }
        public DbSet<nguoilaodong> nguoilaodong { get; set; }
        public DbSet<nhankhau> nhankhau { get; set; }
        public DbSet<param> param { get; set; }
        public DbSet<paramtype> paramtype { get; set; }
        public DbSet<participants> participants { get; set; }
        public DbSet<password_resets> password_resets { get; set; }
        public DbSet<report> report { get; set; }
        public DbSet<threads> threads { get; set; }
        public DbSet<tonghopcunglaodong> tonghopcunglaodong { get; set; }
        public DbSet<tuyendung> tuyendung { get; set; }
        public DbSet<dmnganhnghe> dmnganhnghe { get; set; }
        public DbSet<donvihanhchinhsunghiep> donvihanhchinhsunghiep { get; set; }
        public DbSet<vitrituyendung> vitrituyendung { get; set; }
        public DbSet<phiengiaodichvl> phiengiaodichvl { get; set; }
        public DbSet<phiengiaodichvl_ct> phiengiaodichvl_ct { get; set; }
    }
}
