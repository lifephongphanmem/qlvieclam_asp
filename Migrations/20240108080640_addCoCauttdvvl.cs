using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLVL_Binh.Migrations
{
    /// <inheritdoc />
    public partial class addCoCauttdvvl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cocau_ttdvvl",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gioitinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngaysinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cccd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bhxh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    thuongtru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diachi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uutien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dantoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trinhdogiaoduc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    chuyenmonkythuat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    chuyennganh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tinhtranghdkt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    congvieccuthe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    thamgiabhxh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hdld = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noilamviec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    loaihinhnoilamviec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diachinoilamviec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    madv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nhiemvu_id = table.Column<int>(type: "int"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    manv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    magoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cocau_ttdvvl", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nhiemvu_ttdvvl",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    manv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    magoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhiemvu_ttdvvl", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cocau_ttdvvl");

            migrationBuilder.DropTable(
                name: "nhiemvu_ttdvvl");
        }
    }
}
