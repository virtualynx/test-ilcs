using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test2.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Simulations",
                columns: table => new
                {
                    id_simulasi = table.Column<Guid>(type: "char(36)", nullable: false),
                    kode_barang = table.Column<string>(type: "longtext", nullable: false),
                    uraian_barang = table.Column<string>(type: "longtext", nullable: false),
                    bm = table.Column<int>(type: "int", nullable: false),
                    nilai_komoditas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    nilai_bm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    waktu_insert = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulations", x => x.id_simulasi);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Simulations");
        }
    }
}
