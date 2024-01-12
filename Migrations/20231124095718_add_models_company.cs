using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLVL_Binh.Migrations
{
    /// <inheritdoc />
    public partial class add_models_company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    masodn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dkkd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    khuvuc = table.Column<int>(type: "int", nullable: false),
                    khucn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    loaihinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Public = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user = table.Column<int>(type: "int", nullable: false),
                    nganhnghe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remember_token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    madv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quymo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sld = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "company");
        }
    }
}
