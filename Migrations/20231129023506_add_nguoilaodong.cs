using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLVL_Binh.Migrations
{
    /// <inheritdoc />
    public partial class add_nguoilaodong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "nguoilaodong",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gioitinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngaysinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ccnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dantoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sobaohiem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trinhdogiaoduc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trinhdocmkt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nghenghiep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    linhvucdaotao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    loaihdld = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bdhopdong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    kthopdong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    luong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pcchucvu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pcthamnien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pcthamniennghe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pcluong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pcbosung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bddochai = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ktdochai = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vitri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    chucvu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bdbhxh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ktbhxh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    luongbhxh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ghichu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<short>(type: "smallint", nullable: false),
                    fromttdvvl = table.Column<short>(type: "smallint", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nguoilaodong", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nguoilaodong");
        }
    }
}
