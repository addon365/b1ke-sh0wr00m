using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace addon365.Database.Migrations
{
    public partial class KeychangeCatalogIteminCataloggroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory.Catalog.CustomerCatalogGroup_Inventory.Catalog.CatalogItems_CatalogItemId",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup");

            migrationBuilder.AlterColumn<Guid>(
                name: "CatalogItemId",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory.Catalog.CustomerCatalogGroup_Inventory.Catalog.CatalogItems_CatalogItemId",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup",
                column: "CatalogItemId",
                principalSchema: "addon",
                principalTable: "Inventory.Catalog.CatalogItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory.Catalog.CustomerCatalogGroup_Inventory.Catalog.CatalogItems_CatalogItemId",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup");

            migrationBuilder.AlterColumn<Guid>(
                name: "CatalogItemId",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory.Catalog.CustomerCatalogGroup_Inventory.Catalog.CatalogItems_CatalogItemId",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup",
                column: "CatalogItemId",
                principalSchema: "addon",
                principalTable: "Inventory.Catalog.CatalogItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
