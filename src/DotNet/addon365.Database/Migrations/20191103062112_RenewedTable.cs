using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace addon365.Database.Migrations
{
    public partial class RenewedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup");

            migrationBuilder.AddColumn<Guid>(
                name: "RenewedDetailId",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LicenseRenewedDetails",
                schema: "addon",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerCatalogGroupId = table.Column<Guid>(nullable: false),
                    RenewedOn = table.Column<DateTime>(nullable: false),
                    ExpiryOn = table.Column<DateTime>(nullable: false),
                    VoucherId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseRenewedDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicenseRenewedDetails_Inventory.Catalog.CustomerCatalogGroup_CustomerCatalogGroupId",
                        column: x => x.CustomerCatalogGroupId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Catalog.CustomerCatalogGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicenseRenewedDetails_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalSchema: "addon",
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CustomerCatalogGroup_RenewedDetailId",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup",
                column: "RenewedDetailId",
                unique: true,
                filter: "[RenewedDetailId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseRenewedDetails_CustomerCatalogGroupId",
                schema: "addon",
                table: "LicenseRenewedDetails",
                column: "CustomerCatalogGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseRenewedDetails_VoucherId",
                schema: "addon",
                table: "LicenseRenewedDetails",
                column: "VoucherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory.Catalog.CustomerCatalogGroup_LicenseRenewedDetails_RenewedDetailId",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup",
                column: "RenewedDetailId",
                principalSchema: "addon",
                principalTable: "LicenseRenewedDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory.Catalog.CustomerCatalogGroup_LicenseRenewedDetails_RenewedDetailId",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup");

            migrationBuilder.DropTable(
                name: "LicenseRenewedDetails",
                schema: "addon");

            migrationBuilder.DropIndex(
                name: "IX_Inventory.Catalog.CustomerCatalogGroup_RenewedDetailId",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup");

            migrationBuilder.DropColumn(
                name: "RenewedDetailId",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
