using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApp.data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Laptop",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    Model_adı = table.Column<string>(nullable: false),
                    Marka = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    Isletim_sistemi = table.Column<string>(fixedLength: true, maxLength: 20, nullable: false),
                    Islemci_tipi = table.Column<string>(fixedLength: true, maxLength: 20, nullable: false),
                    Islemci_nesli = table.Column<string>(nullable: true),
                    Ram = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    Disk_boyutu = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    Disk_türü = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    Ekran_boyutu = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaptopSite",
                columns: table => new
                {
                    SiteId = table.Column<int>(nullable: false),
                    LaptopId = table.Column<string>(maxLength: 50, nullable: false),
                    Puan = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: false),
                    Details = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelSite", x => new { x.SiteId, x.LaptopId });
                    table.ForeignKey(
                        name: "FK_ModelSite_Model",
                        column: x => x.LaptopId,
                        principalTable: "Laptop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModelSite_Site",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LaptopSite_LaptopId",
                table: "LaptopSite",
                column: "LaptopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaptopSite");

            migrationBuilder.DropTable(
                name: "Laptop");

            migrationBuilder.DropTable(
                name: "Site");
        }
    }
}
