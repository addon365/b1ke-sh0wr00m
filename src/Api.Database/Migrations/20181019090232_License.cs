using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Database.Migrations
{
    public partial class License : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BranchMasterId",
                schema: "swc",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "swc",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "swc",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionToken",
                schema: "swc",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchMasterId",
                schema: "swc",
                table: "Type",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "Type",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "swc",
                table: "Type",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "swc",
                table: "Type",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchMasterId",
                schema: "swc",
                table: "Threats",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "Threats",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "swc",
                table: "Threats",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "swc",
                table: "Threats",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchMasterId",
                schema: "swc",
                table: "Statuses",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "Statuses",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "swc",
                table: "Statuses",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "swc",
                table: "Statuses",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchMasterId",
                schema: "swc",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "swc",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "swc",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchMasterId",
                schema: "swc",
                table: "ProductTypes",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "ProductTypes",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "swc",
                table: "ProductTypes",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "swc",
                table: "ProductTypes",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchMasterId",
                schema: "swc",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "swc",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "swc",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchMasterId",
                schema: "swc",
                table: "ProductCompanies",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "ProductCompanies",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "swc",
                table: "ProductCompanies",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "swc",
                table: "ProductCompanies",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchMasterId",
                schema: "swc",
                table: "marketingZones",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "marketingZones",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "swc",
                table: "marketingZones",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "swc",
                table: "marketingZones",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AccessoriesProductsId",
                schema: "swc",
                table: "ExtraFittings",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchMasterId",
                schema: "swc",
                table: "ExtraFittings",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "ExtraFittings",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "swc",
                table: "ExtraFittings",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "swc",
                table: "ExtraFittings",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchMasterId",
                schema: "swc",
                table: "EnquriyType",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "EnquriyType",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "swc",
                table: "EnquriyType",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "swc",
                table: "EnquriyType",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchMasterId",
                schema: "swc",
                table: "EnquiryStatuses",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "EnquiryStatuses",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "swc",
                table: "EnquiryStatuses",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "swc",
                table: "EnquiryStatuses",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchMasterId",
                schema: "swc",
                table: "EnquiryProducts",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "EnquiryProducts",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "swc",
                table: "EnquiryProducts",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "swc",
                table: "EnquiryProducts",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchMasterId",
                schema: "swc",
                table: "EnquiryFinanceQuotations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "EnquiryFinanceQuotations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "swc",
                table: "EnquiryFinanceQuotations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "swc",
                table: "EnquiryFinanceQuotations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchMasterId",
                schema: "swc",
                table: "EnquiryExchangeQuotations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "EnquiryExchangeQuotations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "swc",
                table: "EnquiryExchangeQuotations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "swc",
                table: "EnquiryExchangeQuotations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchMasterId",
                schema: "swc",
                table: "EnquiryAccessories",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "EnquiryAccessories",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "swc",
                table: "EnquiryAccessories",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "swc",
                table: "EnquiryAccessories",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchMasterId",
                schema: "swc",
                table: "Enquiries",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "Enquiries",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "swc",
                table: "Enquiries",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "swc",
                table: "Enquiries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BranchMaster",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    BranchName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    ProgrammerID = table.Column<int>(nullable: false),
                    LicenseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchMaster_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LicenseMasters",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BusinessName = table.Column<string>(nullable: true),
                    LicenseId = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    ProgrammerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseMasters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_BranchMasterId",
                schema: "swc",
                table: "Users",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Type_BranchMasterId",
                schema: "swc",
                table: "Type",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_BranchMasterId",
                schema: "swc",
                table: "Threats",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_BranchMasterId",
                schema: "swc",
                table: "Statuses",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_BranchMasterId",
                schema: "swc",
                table: "Profiles",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_BranchMasterId",
                schema: "swc",
                table: "ProductTypes",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BranchMasterId",
                schema: "swc",
                table: "Products",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCompanies_BranchMasterId",
                schema: "swc",
                table: "ProductCompanies",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_marketingZones_BranchMasterId",
                schema: "swc",
                table: "marketingZones",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraFittings_AccessoriesProductsId",
                schema: "swc",
                table: "ExtraFittings",
                column: "AccessoriesProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraFittings_BranchMasterId",
                schema: "swc",
                table: "ExtraFittings",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquriyType_BranchMasterId",
                schema: "swc",
                table: "EnquriyType",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryStatuses_BranchMasterId",
                schema: "swc",
                table: "EnquiryStatuses",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryProducts_BranchMasterId",
                schema: "swc",
                table: "EnquiryProducts",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryFinanceQuotations_BranchMasterId",
                schema: "swc",
                table: "EnquiryFinanceQuotations",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryExchangeQuotations_BranchMasterId",
                schema: "swc",
                table: "EnquiryExchangeQuotations",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryAccessories_BranchMasterId",
                schema: "swc",
                table: "EnquiryAccessories",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_BranchMasterId",
                schema: "swc",
                table: "Enquiries",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "BranchMaster",
                column: "BranchMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enquiries_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "Enquiries",
                column: "BranchMasterId",
                principalSchema: "swc",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnquiryAccessories_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "EnquiryAccessories",
                column: "BranchMasterId",
                principalSchema: "swc",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnquiryExchangeQuotations_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "EnquiryExchangeQuotations",
                column: "BranchMasterId",
                principalSchema: "swc",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnquiryFinanceQuotations_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "EnquiryFinanceQuotations",
                column: "BranchMasterId",
                principalSchema: "swc",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnquiryProducts_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "EnquiryProducts",
                column: "BranchMasterId",
                principalSchema: "swc",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnquiryStatuses_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "EnquiryStatuses",
                column: "BranchMasterId",
                principalSchema: "swc",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnquriyType_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "EnquriyType",
                column: "BranchMasterId",
                principalSchema: "swc",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraFittings_Products_AccessoriesProductsId",
                schema: "swc",
                table: "ExtraFittings",
                column: "AccessoriesProductsId",
                principalSchema: "swc",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraFittings_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "ExtraFittings",
                column: "BranchMasterId",
                principalSchema: "swc",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_marketingZones_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "marketingZones",
                column: "BranchMasterId",
                principalSchema: "swc",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCompanies_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "ProductCompanies",
                column: "BranchMasterId",
                principalSchema: "swc",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "Products",
                column: "BranchMasterId",
                principalSchema: "swc",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "ProductTypes",
                column: "BranchMasterId",
                principalSchema: "swc",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "Profiles",
                column: "BranchMasterId",
                principalSchema: "swc",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "Statuses",
                column: "BranchMasterId",
                principalSchema: "swc",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Threats_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "Threats",
                column: "BranchMasterId",
                principalSchema: "swc",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Type_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "Type",
                column: "BranchMasterId",
                principalSchema: "swc",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "Users",
                column: "BranchMasterId",
                principalSchema: "swc",
                principalTable: "BranchMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enquiries_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "Enquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_EnquiryAccessories_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "EnquiryAccessories");

            migrationBuilder.DropForeignKey(
                name: "FK_EnquiryExchangeQuotations_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "EnquiryExchangeQuotations");

            migrationBuilder.DropForeignKey(
                name: "FK_EnquiryFinanceQuotations_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "EnquiryFinanceQuotations");

            migrationBuilder.DropForeignKey(
                name: "FK_EnquiryProducts_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "EnquiryProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_EnquiryStatuses_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "EnquiryStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_EnquriyType_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "EnquriyType");

            migrationBuilder.DropForeignKey(
                name: "FK_ExtraFittings_Products_AccessoriesProductsId",
                schema: "swc",
                table: "ExtraFittings");

            migrationBuilder.DropForeignKey(
                name: "FK_ExtraFittings_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "ExtraFittings");

            migrationBuilder.DropForeignKey(
                name: "FK_marketingZones_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "marketingZones");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCompanies_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "ProductCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "ProductTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "Statuses");

            migrationBuilder.DropForeignKey(
                name: "FK_Threats_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "Threats");

            migrationBuilder.DropForeignKey(
                name: "FK_Type_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "Type");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "Users");

            migrationBuilder.DropTable(
                name: "BranchMaster",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "LicenseMasters",
                schema: "swc");

            migrationBuilder.DropIndex(
                name: "IX_Users_BranchMasterId",
                schema: "swc",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Type_BranchMasterId",
                schema: "swc",
                table: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Threats_BranchMasterId",
                schema: "swc",
                table: "Threats");

            migrationBuilder.DropIndex(
                name: "IX_Statuses_BranchMasterId",
                schema: "swc",
                table: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_BranchMasterId",
                schema: "swc",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_BranchMasterId",
                schema: "swc",
                table: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_Products_BranchMasterId",
                schema: "swc",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductCompanies_BranchMasterId",
                schema: "swc",
                table: "ProductCompanies");

            migrationBuilder.DropIndex(
                name: "IX_marketingZones_BranchMasterId",
                schema: "swc",
                table: "marketingZones");

            migrationBuilder.DropIndex(
                name: "IX_ExtraFittings_AccessoriesProductsId",
                schema: "swc",
                table: "ExtraFittings");

            migrationBuilder.DropIndex(
                name: "IX_ExtraFittings_BranchMasterId",
                schema: "swc",
                table: "ExtraFittings");

            migrationBuilder.DropIndex(
                name: "IX_EnquriyType_BranchMasterId",
                schema: "swc",
                table: "EnquriyType");

            migrationBuilder.DropIndex(
                name: "IX_EnquiryStatuses_BranchMasterId",
                schema: "swc",
                table: "EnquiryStatuses");

            migrationBuilder.DropIndex(
                name: "IX_EnquiryProducts_BranchMasterId",
                schema: "swc",
                table: "EnquiryProducts");

            migrationBuilder.DropIndex(
                name: "IX_EnquiryFinanceQuotations_BranchMasterId",
                schema: "swc",
                table: "EnquiryFinanceQuotations");

            migrationBuilder.DropIndex(
                name: "IX_EnquiryExchangeQuotations_BranchMasterId",
                schema: "swc",
                table: "EnquiryExchangeQuotations");

            migrationBuilder.DropIndex(
                name: "IX_EnquiryAccessories_BranchMasterId",
                schema: "swc",
                table: "EnquiryAccessories");

            migrationBuilder.DropIndex(
                name: "IX_Enquiries_BranchMasterId",
                schema: "swc",
                table: "Enquiries");

            migrationBuilder.DropColumn(
                name: "BranchMasterId",
                schema: "swc",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "swc",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "swc",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SessionToken",
                schema: "swc",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BranchMasterId",
                schema: "swc",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "swc",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "swc",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "BranchMasterId",
                schema: "swc",
                table: "Threats");

            migrationBuilder.DropColumn(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "Threats");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "swc",
                table: "Threats");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "swc",
                table: "Threats");

            migrationBuilder.DropColumn(
                name: "BranchMasterId",
                schema: "swc",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "swc",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "swc",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "BranchMasterId",
                schema: "swc",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "swc",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "swc",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "BranchMasterId",
                schema: "swc",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "swc",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "swc",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "BranchMasterId",
                schema: "swc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "swc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "swc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BranchMasterId",
                schema: "swc",
                table: "ProductCompanies");

            migrationBuilder.DropColumn(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "ProductCompanies");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "swc",
                table: "ProductCompanies");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "swc",
                table: "ProductCompanies");

            migrationBuilder.DropColumn(
                name: "BranchMasterId",
                schema: "swc",
                table: "marketingZones");

            migrationBuilder.DropColumn(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "marketingZones");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "swc",
                table: "marketingZones");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "swc",
                table: "marketingZones");

            migrationBuilder.DropColumn(
                name: "AccessoriesProductsId",
                schema: "swc",
                table: "ExtraFittings");

            migrationBuilder.DropColumn(
                name: "BranchMasterId",
                schema: "swc",
                table: "ExtraFittings");

            migrationBuilder.DropColumn(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "ExtraFittings");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "swc",
                table: "ExtraFittings");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "swc",
                table: "ExtraFittings");

            migrationBuilder.DropColumn(
                name: "BranchMasterId",
                schema: "swc",
                table: "EnquriyType");

            migrationBuilder.DropColumn(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "EnquriyType");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "swc",
                table: "EnquriyType");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "swc",
                table: "EnquriyType");

            migrationBuilder.DropColumn(
                name: "BranchMasterId",
                schema: "swc",
                table: "EnquiryStatuses");

            migrationBuilder.DropColumn(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "EnquiryStatuses");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "swc",
                table: "EnquiryStatuses");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "swc",
                table: "EnquiryStatuses");

            migrationBuilder.DropColumn(
                name: "BranchMasterId",
                schema: "swc",
                table: "EnquiryProducts");

            migrationBuilder.DropColumn(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "EnquiryProducts");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "swc",
                table: "EnquiryProducts");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "swc",
                table: "EnquiryProducts");

            migrationBuilder.DropColumn(
                name: "BranchMasterId",
                schema: "swc",
                table: "EnquiryFinanceQuotations");

            migrationBuilder.DropColumn(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "EnquiryFinanceQuotations");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "swc",
                table: "EnquiryFinanceQuotations");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "swc",
                table: "EnquiryFinanceQuotations");

            migrationBuilder.DropColumn(
                name: "BranchMasterId",
                schema: "swc",
                table: "EnquiryExchangeQuotations");

            migrationBuilder.DropColumn(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "EnquiryExchangeQuotations");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "swc",
                table: "EnquiryExchangeQuotations");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "swc",
                table: "EnquiryExchangeQuotations");

            migrationBuilder.DropColumn(
                name: "BranchMasterId",
                schema: "swc",
                table: "EnquiryAccessories");

            migrationBuilder.DropColumn(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "EnquiryAccessories");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "swc",
                table: "EnquiryAccessories");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "swc",
                table: "EnquiryAccessories");

            migrationBuilder.DropColumn(
                name: "BranchMasterId",
                schema: "swc",
                table: "Enquiries");

            migrationBuilder.DropColumn(
                name: "CreatedDeviceId",
                schema: "swc",
                table: "Enquiries");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "swc",
                table: "Enquiries");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "swc",
                table: "Enquiries");
        }
    }
}
