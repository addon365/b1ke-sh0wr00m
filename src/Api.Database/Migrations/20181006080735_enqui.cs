using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Api.Database.Migrations
{
    public partial class enqui : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccessoriesId",
                schema: "swc",
                table: "EnquiryAccessories",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "EnquiryProducts",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccessoriesAmount = table.Column<double>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    EnquiryId = table.Column<Guid>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    OnRoadPrice = table.Column<double>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnquiryProducts_Enquiries_EnquiryId",
                        column: x => x.EnquiryId,
                        principalSchema: "swc",
                        principalTable: "Enquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnquiryProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "swc",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryProducts_EnquiryId",
                schema: "swc",
                table: "EnquiryProducts",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryProducts_ProductId",
                schema: "swc",
                table: "EnquiryProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnquiryProducts",
                schema: "swc");

            migrationBuilder.DropColumn(
                name: "AccessoriesId",
                schema: "swc",
                table: "EnquiryAccessories");
        }
    }
}
