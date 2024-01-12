using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Hosting;
using QLVL_Binh.Models.Systems;

#nullable disable

namespace QLVL_Binh.Migrations
{
    /// <inheritdoc />
    public partial class addDataDmLan1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "quoctich",
            columnTypes: new string[] { "bigint", "string", "string", "string", "datetime2", "datetime2" },
            columns: new[] { "id", "maqg", "tenqg", "mota", "created_at", "updated_at" },
            values: new object[,]
            {
                 {2, "VN", "Việt Nam", "",  DateTime.Now, DateTime.Now },
                 //{ maqg = "YE", tenqg = "Yemen",mota = "", created_at = DateTime.Now, updated_at = DateTime.Now },
                 //{ maqg = "BY", tenqg = "Belarus",mota = "", created_at = DateTime.Now, updated_at = DateTime.Now },
                 //{ maqg = "CU", tenqg = "Cuba",mota = "", created_at = DateTime.Now, updated_at = DateTime.Now },
                 //{ maqg = "RU", tenqg = "Liên bang Nga",mota = "", created_at = DateTime.Now, updated_at = DateTime.Now },
                 //{ maqg = "SD", tenqg = "Sudan",mota = "", created_at = DateTime.Now, updated_at = DateTime.Now },
            });


            /*migrationBuilder.InsertData(
            table: "donvihanhchinhsunghiep",
            columns: new[] { "id", "maso", "tenhanhchinhsunghiep", "capdo", "magoc", "mota", "created_at", "updated_at" },
            values: new[]
            {
                new { id = 1, maso = "100", tenhanhchinhsunghiep = "Doanh nghiệp",capdo=1,magoc = "",mota = "Tổ chức kinh tế có tên riêng, có tài sản, có trụ sở giao dịch ổn định, được đăng ký kinh doanh theo quy định của pháp luật", created_at = DateTime.Now, updated_at = DateTime.Now },
                new { id = 2, maso = "110", tenhanhchinhsunghiep = "Doanh nghiệp nhà nước",capdo=2,magoc = "100",mota = "Tổ chức dưới hình thức DN độc lập, Tổng công ty, DN thành viên của Tổng công ty có 100% vốn nhà nước", created_at = DateTime.Now, updated_at = DateTime.Now },
                new { id = 3, maso = "111", tenhanhchinhsunghiep = "Doanh nghiệp nhà nước trung ương",capdo=3,magoc = "110",mota = "Bao gồm DN nhà nước do các Bộ, Cơ quan ngang Bộ, Cơ quan thuộc Chính phủ, các Cơ quan trung ương của các tổ chức chính trị, tổ chức chính trị – xã hội, các Tổng công ty 91 quản lý.", created_at = DateTime.Now, updated_at = DateTime.Now },
            });

            migrationBuilder.InsertData(
            table: "chanthuong",
            columns: new[] { "id", "maso", "tenchanthuong", "capdo", "magoc", "mota", "created_at", "updated_at" },
            values: new[]
            {
                new { id = 1, maso = "01", tenchanthuong = "Đầu, mặt, cổ",capdo=1,magoc = "",mota = "", created_at = DateTime.Now, updated_at = DateTime.Now },
                new { id = 2, maso = "011", tenchanthuong = "Các chấn thương sọ não hở hoặc kín",capdo=2,magoc = "01",mota = "", created_at = DateTime.Now, updated_at = DateTime.Now },
                new { id = 3, maso = "019", tenchanthuong = "Tổn thương phần mềm rộng ở mặt",capdo=2,magoc = "01",mota = "", created_at = DateTime.Now, updated_at = DateTime.Now },
                new { id = 4, maso = "0110", tenchanthuong = "Bị thương vào cổ, tác hại đến thanh quản và thực quản",capdo=2,magoc = "01",mota = "", created_at = DateTime.Now, updated_at = DateTime.Now },
            });

            migrationBuilder.InsertData(
            table: "cacytcohai",
            columns: new[] { "id", "phanloai", "tenyeuto", "mota", "created_at", "updated_at" },
            values: new[]
            {
                new { id = 1, phanloai = "01", tenyeuto = "Nhiệt độ",mota = "khí hậu bất lợi", created_at = DateTime.Now, updated_at = DateTime.Now },
                new { id = 2, phanloai = "01", tenyeuto = "Độ ẩm",mota = "khí hậu bất lợi", created_at = DateTime.Now, updated_at = DateTime.Now },
                new { id = 3, phanloai = "02", tenyeuto = "Ánh sáng",mota = "vật lý", created_at = DateTime.Now, updated_at = DateTime.Now },
                new { id = 4, phanloai = "02", tenyeuto = "Tiếng ồn theo dải tần",mota = "vật lý", created_at = DateTime.Now, updated_at = DateTime.Now },
                new { id = 5, phanloai = "03", tenyeuto = "Bụi toàn phần",mota = "bụi các loại", created_at = DateTime.Now, updated_at = DateTime.Now },
                new { id = 6, phanloai = "03", tenyeuto = "Bụi hô hấp",mota = "bụi các loại", created_at = DateTime.Now, updated_at = DateTime.Now },
                new { id = 7, phanloai = "04", tenyeuto = "Thủy ngân",mota = "hơi khí độc", created_at = DateTime.Now, updated_at = DateTime.Now },
                new { id = 8, phanloai = "04", tenyeuto = "Asen",mota = "hơi khí độc", created_at = DateTime.Now, updated_at = DateTime.Now },
                new { id = 9, phanloai = "05", tenyeuto = "Đánh giá gánh nặng thần kinh tâm lý",mota = "tâm sinh lý và ec-gô-nô-my", created_at = DateTime.Now, updated_at = DateTime.Now },
                new { id = 10, phanloai = "05", tenyeuto = "Đánh giá ec-gô-nô-my",mota = "tâm sinh lý và ec-gô-nô-my", created_at = DateTime.Now, updated_at = DateTime.Now },
                new { id = 11, phanloai = "06", tenyeuto = "Yếu tố vi sinh vật",mota = "tiếp xúc nghề nghiệp", created_at = DateTime.Now, updated_at = DateTime.Now },
                new { id = 12, phanloai = "06", tenyeuto = "Yếu tố gây dị ứng, mẫn cảm",mota = "tiếp xúc nghề nghiệp", created_at = DateTime.Now, updated_at = DateTime.Now },
            });*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("quoctich");
            migrationBuilder.DropTable("donvihanhchinhsunghiep");
            migrationBuilder.DropTable("chanthuong");
            migrationBuilder.DropTable("cacytcohai");
        }
    }
}
