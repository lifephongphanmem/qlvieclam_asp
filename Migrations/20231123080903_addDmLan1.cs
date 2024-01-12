using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLVL_Binh.Migrations
{
    /// <inheritdoc />
    public partial class addDmLan1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "quoctich",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maqg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tenqg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quoctich", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "donvihanhchinhsunghiep",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tenhanhchinhsunghiep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    capdo = table.Column<int>(type: "int", nullable: false),
                    magoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donvihanhchinhsunghiep", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "chanthuong",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tenchanthuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    capdo = table.Column<int>(type: "int", nullable: false),
                    magoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chanthuong", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cacytcohai",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phanloai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tenyeuto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cacytcohai", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "quoctich");
            migrationBuilder.DropTable(
                name: "donvihanhchinhsunghiep");
            migrationBuilder.DropTable(
                name: "chanthuong");
            migrationBuilder.DropTable(
                name: "cacytcohai");


        }
    }
}
