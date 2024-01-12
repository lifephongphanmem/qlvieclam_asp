using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLVL_Binh.Migrations
{
    /// <inheritdoc />
    public partial class addPhienGiaoDichVL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "phiengiaodichvl",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    magd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nguoilaodong = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phiengiaodichvl", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "phiengiaodichvl_ct",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    magd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user = table.Column<int>(type: "int", nullable: true),
                    noidung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vitri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    soluong = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phiengiaodichvl_ct", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "phiengiaodichvl");

            migrationBuilder.DropTable(
                name: "phiengiaodichvl_ct");
        }
    }
}
