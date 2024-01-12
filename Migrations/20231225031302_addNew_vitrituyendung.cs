using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLVL_Binh.Migrations
{
    /// <inheritdoc />
    public partial class addNew_vitrituyendung : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "vitrituyendung",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idtuyendung = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    soluong = table.Column<short>(type: "smallint", nullable: true),
                    manghe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    capbac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    chucvu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tdgd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tdcmkt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    chuyennganh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trinhdonghe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bacnge = table.Column<short>(type: "smallint", nullable: true),
                    ngoaingu1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    chungchinn1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    xeploainn1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngoaingu2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    chungchinn2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    xeploainn2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    loaithvp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tinhockhac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    loaithk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kynangmem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yeucaukn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diadiem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    loaihopdong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yeucauthem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hinhthuclv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mucdichlv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mucluong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hotroan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phucloi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noilamviec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trongluongnang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dungvadilai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nghenoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    thiluc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    thaotactay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dungtay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uutien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vitrituyendung", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vitrituyendung");

        }
    }
}
