using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace THTHU1_NET104.Migrations
{
    /// <inheritdoc />
    public partial class ver1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hangs",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenHang = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hangs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Otos",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Otos_Hangs_IDHang",
                        column: x => x.IDHang,
                        principalTable: "Hangs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hangs",
                columns: new[] { "ID", "TenHang" },
                values: new object[,]
                {
                    { "H1", "Roll Royces" },
                    { "H2", "Balencicaca" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Otos_IDHang",
                table: "Otos",
                column: "IDHang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Otos");

            migrationBuilder.DropTable(
                name: "Hangs");
        }
    }
}
