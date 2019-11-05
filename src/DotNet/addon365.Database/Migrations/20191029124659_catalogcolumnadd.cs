using Microsoft.EntityFrameworkCore.Migrations;

namespace addon365.Database.Migrations
{
    public partial class catalogcolumnadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberofSystem",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberofSystem",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup");
        }
    }
}
