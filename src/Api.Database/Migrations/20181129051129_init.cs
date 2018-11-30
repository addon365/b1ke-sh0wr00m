using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Database.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "swc");

            migrationBuilder.CreateTable(
                name: "BranchMaster",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
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
                name: "InquiredProducts",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MonthIndex = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    ProductCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InquiredProducts", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Campaigns",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Filter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    Identifier = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnquiryStatuses",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    ProgrammerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnquiryStatuses_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnquriyType",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ProgrammerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquriyType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnquriyType_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinanceCompanies",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinanceCompanies_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FollowUpModes",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUpModes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollowUpModes_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FollowUpStatuses",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUpStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollowUpStatuses_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryInfos",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    InventoryMasterId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Unit = table.Column<double>(nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    InventoryItemMasterId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryInfos_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItemMasters",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    ChasisNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItemMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryItemMasters_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "marketingZones",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    Identifier = table.Column<string>(nullable: true),
                    ZonalName = table.Column<string>(nullable: true),
                    ZonalDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marketingZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_marketingZones_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentModes",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProgrammerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentModes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentModes_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCompanies",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    Identifier = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    ProgrammerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCompanies_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    Identifier = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    InsuranceAmount = table.Column<double>(nullable: false),
                    RoadTax = table.Column<double>(nullable: false),
                    HSN = table.Column<string>(nullable: true),
                    GST = table.Column<double>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    TypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    Identifier = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: false),
                    ProgrammerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTypes_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statuses_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Type_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ConfirmPassword = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    SessionToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vouchers_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VouchersInfo",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    VoucherId = table.Column<Guid>(nullable: false),
                    BookId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    IsCredit = table.Column<bool>(nullable: false),
                    FieldInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VouchersInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VouchersInfo_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    Identifier = table.Column<string>(nullable: true),
                    ContactId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "swc",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    BranchMasterId1 = table.Column<Guid>(nullable: true),
                    Identifier = table.Column<string>(nullable: true),
                    ContactId = table.Column<Guid>(nullable: false),
                    JoiningDate = table.Column<DateTime>(nullable: false),
                    LastDate = table.Column<DateTime>(nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    DesignationId = table.Column<Guid>(nullable: true),
                    DepartmentId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_BranchMaster_BranchMasterId1",
                        column: x => x.BranchMasterId1,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "swc",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enquiries",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    Identifier = table.Column<string>(nullable: true),
                    EnquiryDate = table.Column<DateTime>(nullable: false),
                    ContactId = table.Column<Guid>(nullable: false),
                    EnquiryTypeId = table.Column<Guid>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false),
                    VoucherId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquiries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enquiries_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enquiries_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "swc",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enquiries_EnquriyType_EnquiryTypeId",
                        column: x => x.EnquiryTypeId,
                        principalSchema: "swc",
                        principalTable: "EnquriyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enquiries_EnquiryStatuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "swc",
                        principalTable: "EnquiryStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignInfos",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    CampaignId = table.Column<Guid>(nullable: false),
                    ContactId = table.Column<Guid>(nullable: false),
                    ModeId = table.Column<Guid>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignInfos_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignInfos_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "swc",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignInfos_FollowUpModes_ModeId",
                        column: x => x.ModeId,
                        principalSchema: "swc",
                        principalTable: "FollowUpModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignInfos_FollowUpStatuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "swc",
                        principalTable: "FollowUpStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExtraFittings",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    AccessoriesProductId = table.Column<Guid>(nullable: false),
                    AccessoriesProductItemId = table.Column<Guid>(nullable: true),
                    Unit = table.Column<double>(nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraFittings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraFittings_Products_AccessoriesProductItemId",
                        column: x => x.AccessoriesProductItemId,
                        principalSchema: "swc",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExtraFittings_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExtraFittings_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "swc",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Threats",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    Identifier = table.Column<string>(nullable: true, computedColumnSql: "CONCAT('swc-',[Id])"),
                    Referer = table.Column<string>(maxLength: 255, nullable: true),
                    Host = table.Column<string>(nullable: true),
                    UserAgent = table.Column<string>(nullable: true),
                    XForwardHost = table.Column<string>(nullable: true),
                    XForwardProto = table.Column<string>(nullable: true),
                    QueryString = table.Column<string>(nullable: true),
                    Protocol = table.Column<string>(nullable: true),
                    TypeId = table.Column<Guid>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Threats_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Threats_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "swc",
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Threats_Type_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "swc",
                        principalTable: "Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryMasters",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    Identifier = table.Column<string>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryMasters_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMasters_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "swc",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnquiryAccessories",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    EnquiryId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    AccessoriesId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryAccessories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnquiryAccessories_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnquiryAccessories_Enquiries_EnquiryId",
                        column: x => x.EnquiryId,
                        principalSchema: "swc",
                        principalTable: "Enquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnquiryAccessories_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "swc",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnquiryExchangeQuotations",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    EnquiryId = table.Column<Guid>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    NoOfOwner = table.Column<int>(nullable: false),
                    ExpectedAmount = table.Column<double>(nullable: false),
                    QuotatedAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryExchangeQuotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnquiryExchangeQuotations_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnquiryExchangeQuotations_Enquiries_EnquiryId",
                        column: x => x.EnquiryId,
                        principalSchema: "swc",
                        principalTable: "Enquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnquiryProducts",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    EnquiryId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    OnRoadPrice = table.Column<double>(nullable: false),
                    AccessoriesAmount = table.Column<double>(nullable: false),
                    OtherAmount = table.Column<double>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnquiryProducts_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "EnquiryFinanceQuotations",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    EnquiryProductId = table.Column<Guid>(nullable: false),
                    InitialDownPayment = table.Column<double>(nullable: false),
                    MonthlyEMIAmount = table.Column<double>(nullable: false),
                    NumberOfMonths = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryFinanceQuotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnquiryFinanceQuotations_BranchMaster_BranchMasterId",
                        column: x => x.BranchMasterId,
                        principalSchema: "swc",
                        principalTable: "BranchMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnquiryFinanceQuotations_EnquiryProducts_EnquiryProductId",
                        column: x => x.EnquiryProductId,
                        principalSchema: "swc",
                        principalTable: "EnquiryProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchMaster_BranchMasterId",
                schema: "swc",
                table: "BranchMaster",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignInfos_BranchMasterId",
                schema: "swc",
                table: "CampaignInfos",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignInfos_ContactId",
                schema: "swc",
                table: "CampaignInfos",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignInfos_ModeId",
                schema: "swc",
                table: "CampaignInfos",
                column: "ModeId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignInfos_StatusId",
                schema: "swc",
                table: "CampaignInfos",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_BranchMasterId",
                schema: "swc",
                table: "Campaigns",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_BranchMasterId",
                schema: "swc",
                table: "Contacts",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BranchMasterId",
                schema: "swc",
                table: "Customers",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ContactId",
                schema: "swc",
                table: "Customers",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchMasterId1",
                schema: "swc",
                table: "Employees",
                column: "BranchMasterId1");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ContactId",
                schema: "swc",
                table: "Employees",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_BranchMasterId",
                schema: "swc",
                table: "Enquiries",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_ContactId",
                schema: "swc",
                table: "Enquiries",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_EnquiryTypeId",
                schema: "swc",
                table: "Enquiries",
                column: "EnquiryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_StatusId",
                schema: "swc",
                table: "Enquiries",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryAccessories_BranchMasterId",
                schema: "swc",
                table: "EnquiryAccessories",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryAccessories_EnquiryId",
                schema: "swc",
                table: "EnquiryAccessories",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryAccessories_ProductId",
                schema: "swc",
                table: "EnquiryAccessories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryExchangeQuotations_BranchMasterId",
                schema: "swc",
                table: "EnquiryExchangeQuotations",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryExchangeQuotations_EnquiryId",
                schema: "swc",
                table: "EnquiryExchangeQuotations",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryFinanceQuotations_BranchMasterId",
                schema: "swc",
                table: "EnquiryFinanceQuotations",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryFinanceQuotations_EnquiryProductId",
                schema: "swc",
                table: "EnquiryFinanceQuotations",
                column: "EnquiryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryProducts_BranchMasterId",
                schema: "swc",
                table: "EnquiryProducts",
                column: "BranchMasterId");

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

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryStatuses_BranchMasterId",
                schema: "swc",
                table: "EnquiryStatuses",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquriyType_BranchMasterId",
                schema: "swc",
                table: "EnquriyType",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraFittings_AccessoriesProductItemId",
                schema: "swc",
                table: "ExtraFittings",
                column: "AccessoriesProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraFittings_BranchMasterId",
                schema: "swc",
                table: "ExtraFittings",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraFittings_ProductId",
                schema: "swc",
                table: "ExtraFittings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FinanceCompanies_BranchMasterId",
                schema: "swc",
                table: "FinanceCompanies",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpModes_BranchMasterId",
                schema: "swc",
                table: "FollowUpModes",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpStatuses_BranchMasterId",
                schema: "swc",
                table: "FollowUpStatuses",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryInfos_BranchMasterId",
                schema: "swc",
                table: "InventoryInfos",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItemMasters_BranchMasterId",
                schema: "swc",
                table: "InventoryItemMasters",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMasters_BranchMasterId",
                schema: "swc",
                table: "InventoryMasters",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMasters_CustomerId",
                schema: "swc",
                table: "InventoryMasters",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_marketingZones_BranchMasterId",
                schema: "swc",
                table: "marketingZones",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentModes_BranchMasterId",
                schema: "swc",
                table: "PaymentModes",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCompanies_BranchMasterId",
                schema: "swc",
                table: "ProductCompanies",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BranchMasterId",
                schema: "swc",
                table: "Products",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_BranchMasterId",
                schema: "swc",
                table: "ProductTypes",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_BranchMasterId",
                schema: "swc",
                table: "Statuses",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_BranchMasterId",
                schema: "swc",
                table: "Threats",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_Referer",
                schema: "swc",
                table: "Threats",
                column: "Referer",
                unique: true,
                filter: "[Referer] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_StatusId",
                schema: "swc",
                table: "Threats",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_TypeId",
                schema: "swc",
                table: "Threats",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Type_BranchMasterId",
                schema: "swc",
                table: "Type",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BranchMasterId",
                schema: "swc",
                table: "Users",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_BranchMasterId",
                schema: "swc",
                table: "Vouchers",
                column: "BranchMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_VouchersInfo_BranchMasterId",
                schema: "swc",
                table: "VouchersInfo",
                column: "BranchMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignInfos",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Campaigns",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "EnquiryAccessories",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "EnquiryExchangeQuotations",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "EnquiryFinanceQuotations",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "ExtraFittings",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "FinanceCompanies",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "InquiredProducts",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "InventoryInfos",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "InventoryItemMasters",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "InventoryMasters",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "LicenseMasters",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "marketingZones",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "PaymentModes",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "ProductCompanies",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "ProductTypes",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Threats",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Vouchers",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "VouchersInfo",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "FollowUpModes",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "FollowUpStatuses",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "EnquiryProducts",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Statuses",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Type",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Enquiries",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "EnquriyType",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "EnquiryStatuses",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "BranchMaster",
                schema: "swc");
        }
    }
}
