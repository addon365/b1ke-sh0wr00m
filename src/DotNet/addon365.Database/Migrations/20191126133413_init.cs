using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace addon365.Database.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "addon365");

            migrationBuilder.CreateTable(
                name: "Accounts.AccountBooks",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    BookName = table.Column<string>(nullable: true),
                    UnderGroupId = table.Column<Guid>(nullable: false),
                    ProgrammerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts.AccountBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts.PaymentModes",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProgrammerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts.PaymentModes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts.VoucherTypeMasters",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: false),
                    ProgrammerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts.VoucherTypeMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddressMasters",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    PinOrZip = table.Column<long>(nullable: false),
                    LocalityOrVillage = table.Column<string>(nullable: true),
                    LocalityOrVillageId = table.Column<Guid>(nullable: true),
                    SubDistrict = table.Column<string>(nullable: true),
                    SubDistrictId = table.Column<Guid>(nullable: true),
                    DistrictId = table.Column<Guid>(nullable: true),
                    StateId = table.Column<Guid>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchMasters",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    BranchName = table.Column<string>(nullable: true),
                    ShortCode = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    LicenseMasterId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Filter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChitSchemes",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    SchemaName = table.Column<string>(nullable: true),
                    TotalMonths = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    HasFixedDate = table.Column<bool>(nullable: false),
                    MaxMembers = table.Column<int>(nullable: false),
                    MonthlyAmount = table.Column<double>(nullable: false),
                    BonusAmount = table.Column<double>(nullable: false),
                    FinalBonus = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChitSchemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceMasters",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    OtherId = table.Column<int>(nullable: false),
                    DeviceName = table.Column<string>(nullable: true),
                    DeviceId = table.Column<string>(nullable: true),
                    MacId1 = table.Column<string>(nullable: true),
                    MacId2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    DistrictName = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnquiryStatuses",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    ProgrammerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnquriyType",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ProgrammerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquriyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinanceCompanies",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FollowUpModes",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUpModes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FollowUpStatuses",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUpStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InquiryReport",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InquiryReport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Catalog.CatalogBrands",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    ProgrammerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Catalog.CatalogBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Catalog.CatalogItemPropertyMasters",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    PropertyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Catalog.CatalogItemPropertyMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Catalog.CatalogTypes",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: false),
                    ProgrammerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Catalog.CatalogTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadSources",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadStatusMasters",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadStatusMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LicenseMasters",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    BusinessName = table.Column<string>(nullable: true),
                    LicenseId = table.Column<Guid>(nullable: false),
                    URL = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: false),
                    CatalogItemId = table.Column<Guid>(nullable: false),
                    VoucherId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localities",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    LocalityOrVillageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "marketingZones",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    ZonalName = table.Column<string>(nullable: true),
                    ZonalDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marketingZones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pincodes",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Pincode = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pincodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleGroup",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    StateName = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusMasters",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    StatusName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProgrammerId = table.Column<string>(nullable: true),
                    Priority = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDistricts",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    SubDistrictName = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDistricts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts.Vouchers",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    VoucherDate = table.Column<DateTime>(nullable: false),
                    VoucherTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts.Vouchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts.Vouchers_Accounts.VoucherTypeMasters_VoucherTypeId",
                        column: x => x.VoucherTypeId,
                        principalSchema: "addon365",
                        principalTable: "Accounts.VoucherTypeMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    SecondaryMobileNo = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    ContactAddressId = table.Column<Guid>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_AddressMasters_ContactAddressId",
                        column: x => x.ContactAddressId,
                        principalSchema: "addon365",
                        principalTable: "AddressMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Catalog.CatalogItems",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    ProductCode = table.Column<string>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false),
                    BrandId = table.Column<Guid>(nullable: false),
                    Image = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Inventory.Catalog.CatalogItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CatalogItems_Inventory.Catalog.CatalogBrands_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Catalog.CatalogBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CatalogItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "addon365",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OtherId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ConfirmPassword = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    SessionToken = table.Column<string>(nullable: true),
                    NotificationToken = table.Column<string>(nullable: true),
                    RoleGroupId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_RoleGroup_RoleGroupId",
                        column: x => x.RoleGroupId,
                        principalSchema: "addon365",
                        principalTable: "RoleGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Threats",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Identifier = table.Column<string>(nullable: true, computedColumnSql: "CONCAT('SVB-',[Id])"),
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
                        name: "FK_Threats_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "addon365",
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Threats_Type_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "addon365",
                        principalTable: "Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts.VoucherInfos",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    VoucherId = table.Column<Guid>(nullable: false),
                    bookId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    IsCredit = table.Column<bool>(nullable: false),
                    FieldInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts.VoucherInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts.VoucherInfos_Accounts.Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalSchema: "addon365",
                        principalTable: "Accounts.Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts.VoucherInfos_Accounts.AccountBooks_bookId",
                        column: x => x.bookId,
                        principalSchema: "addon365",
                        principalTable: "Accounts.AccountBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessContacts",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    BusinessName = table.Column<string>(nullable: true),
                    BusinessMailId = table.Column<string>(nullable: true),
                    ContactAddressId = table.Column<Guid>(nullable: true),
                    ProprietorId = table.Column<Guid>(nullable: true),
                    ContactPersonId = table.Column<Guid>(nullable: true),
                    Landline = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    SecondaryMobileNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessContacts_AddressMasters_ContactAddressId",
                        column: x => x.ContactAddressId,
                        principalSchema: "addon365",
                        principalTable: "AddressMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessContacts_Contacts_ContactPersonId",
                        column: x => x.ContactPersonId,
                        principalSchema: "addon365",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessContacts_Contacts_ProprietorId",
                        column: x => x.ProprietorId,
                        principalSchema: "addon365",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enquiries",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    EnquiryDate = table.Column<DateTime>(nullable: false),
                    ContactId = table.Column<Guid>(nullable: false),
                    EnquiryTypeId = table.Column<Guid>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false),
                    VoucherId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquiries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enquiries_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "addon365",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enquiries_EnquriyType_EnquiryTypeId",
                        column: x => x.EnquiryTypeId,
                        principalSchema: "addon365",
                        principalTable: "EnquriyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enquiries_EnquiryStatuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "addon365",
                        principalTable: "EnquiryStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enquiries_Accounts.Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalSchema: "addon365",
                        principalTable: "Accounts.Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Catalog.CatalogItemPropertiesMaps",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CatalogItemId = table.Column<Guid>(nullable: false),
                    CatalogPropertyMasterId = table.Column<Guid>(nullable: false),
                    ValueType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Catalog.CatalogItemPropertiesMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CatalogItemPropertiesMaps_Inventory.Catalog.CatalogItems_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Catalog.CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CatalogItemPropertiesMaps_Inventory.Catalog.CatalogItemPropertyMasters_CatalogPropertyMasterId",
                        column: x => x.CatalogPropertyMasterId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Catalog.CatalogItemPropertyMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    ContactId = table.Column<Guid>(nullable: false),
                    JoiningDate = table.Column<DateTime>(nullable: false),
                    LastDate = table.Column<DateTime>(nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    DesignationId = table.Column<Guid>(nullable: true),
                    DepartmentId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "addon365",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "addon365",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    CustomerEmailId = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    ContactId = table.Column<Guid>(nullable: true),
                    BusinessContactId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_BusinessContacts_BusinessContactId",
                        column: x => x.BusinessContactId,
                        principalSchema: "addon365",
                        principalTable: "BusinessContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "addon365",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "addon365",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Buyers",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    BuyerId = table.Column<string>(nullable: true),
                    BusinessContactId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Buyers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Buyers_BusinessContacts_BusinessContactId",
                        column: x => x.BusinessContactId,
                        principalSchema: "addon365",
                        principalTable: "BusinessContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Sellers",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    SellerId = table.Column<string>(nullable: true),
                    BusinessContactId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Sellers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Sellers_BusinessContacts_BusinessContactId",
                        column: x => x.BusinessContactId,
                        principalSchema: "addon365",
                        principalTable: "BusinessContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leads",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    ContactId = table.Column<Guid>(nullable: true),
                    SourceId = table.Column<Guid>(nullable: false),
                    CurrentLeadStatusId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leads_BusinessContacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "addon365",
                        principalTable: "BusinessContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leads_LeadSources_SourceId",
                        column: x => x.SourceId,
                        principalSchema: "addon365",
                        principalTable: "LeadSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnquiryAccessories",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    EnquiryId = table.Column<Guid>(nullable: false),
                    CatalogItemId = table.Column<Guid>(nullable: false),
                    AccessoriesId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryAccessories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnquiryAccessories_Inventory.Catalog.CatalogItems_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Catalog.CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnquiryAccessories_Enquiries_EnquiryId",
                        column: x => x.EnquiryId,
                        principalSchema: "addon365",
                        principalTable: "Enquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnquiryExchangeQuotations",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
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
                        name: "FK_EnquiryExchangeQuotations_Enquiries_EnquiryId",
                        column: x => x.EnquiryId,
                        principalSchema: "addon365",
                        principalTable: "Enquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnquiryItems",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    EnquiryId = table.Column<Guid>(nullable: false),
                    CatalogItemId = table.Column<Guid>(nullable: false),
                    OnRoadPrice = table.Column<double>(nullable: false),
                    AccessoriesAmount = table.Column<double>(nullable: false),
                    OtherAmount = table.Column<double>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnquiryItems_Inventory.Catalog.CatalogItems_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Catalog.CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnquiryItems_Enquiries_EnquiryId",
                        column: x => x.EnquiryId,
                        principalSchema: "addon365",
                        principalTable: "Enquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChitSubscribers",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    SubscribeId = table.Column<string>(nullable: true),
                    ChitSchemeId = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    JoinedDate = table.Column<DateTime>(nullable: false),
                    ClosedVoucherId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChitSubscribers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChitSubscribers_ChitSchemes_ChitSchemeId",
                        column: x => x.ChitSchemeId,
                        principalSchema: "addon365",
                        principalTable: "ChitSchemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChitSubscribers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "addon365",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Sales.Sales",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    BillNo = table.Column<string>(nullable: true),
                    BillDate = table.Column<DateTime>(nullable: false),
                    ShippingAddressId = table.Column<Guid>(nullable: true),
                    BillingAddressId = table.Column<Guid>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: true),
                    BuyerId = table.Column<Guid>(nullable: true),
                    VoucherId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Sales.Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Sales.Sales_Inventory.Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Buyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory.Sales.Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "addon365",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory.Sales.Sales_Accounts.Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalSchema: "addon365",
                        principalTable: "Accounts.Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Purchases.Purchases",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    PurchaseInvoiceNo = table.Column<string>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    SellerId = table.Column<Guid>(nullable: false),
                    VoucherId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Purchases.Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Purchases.Purchases_Inventory.Sellers_SellerId",
                        column: x => x.SellerId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Purchases.Purchases_Accounts.Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalSchema: "addon365",
                        principalTable: "Accounts.Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    LeadId = table.Column<Guid>(nullable: false),
                    AppointmentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Leads_LeadId",
                        column: x => x.LeadId,
                        principalSchema: "addon365",
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignInfos",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    LeadId = table.Column<Guid>(nullable: false),
                    IsInProgress = table.Column<bool>(nullable: false),
                    CampaignId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignInfos_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalSchema: "addon365",
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignInfos_Leads_LeadId",
                        column: x => x.LeadId,
                        principalSchema: "addon365",
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadHistory",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    StatusDate = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false),
                    ExtraData = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    LeadId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadHistory_Leads_LeadId",
                        column: x => x.LeadId,
                        principalSchema: "addon365",
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeadHistory_LeadStatusMasters_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "addon365",
                        principalTable: "LeadStatusMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnquiryFinanceQuotations",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    EnquiryProductId = table.Column<Guid>(nullable: false),
                    InitialDownPayment = table.Column<double>(nullable: false),
                    MonthlyEMIAmount = table.Column<double>(nullable: false),
                    NumberOfMonths = table.Column<int>(nullable: false),
                    EnquiryCatalogItemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryFinanceQuotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnquiryFinanceQuotations_EnquiryItems_EnquiryCatalogItemId",
                        column: x => x.EnquiryCatalogItemId,
                        principalSchema: "addon365",
                        principalTable: "EnquiryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChitSubscriberDues",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    ChitSubscriberId = table.Column<Guid>(nullable: false),
                    DueNo = table.Column<string>(nullable: true),
                    VoucherId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChitSubscriberDues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChitSubscriberDues_ChitSubscribers_ChitSubscriberId",
                        column: x => x.ChitSubscriberId,
                        principalSchema: "addon365",
                        principalTable: "ChitSubscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChitSubscriberDues_Accounts.Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalSchema: "addon365",
                        principalTable: "Accounts.Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Sales.SalesItems",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    SalesId = table.Column<Guid>(nullable: false),
                    CatalogItemId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    SaleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Sales.SalesItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Sales.SalesItems_Inventory.Catalog.CatalogItems_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Catalog.CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Sales.SalesItems_Inventory.Sales.Sales_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Sales.Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Purchases.PurchasesItems",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    PurchaseId = table.Column<Guid>(nullable: false),
                    CatalogItemId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Unit = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Purchases.PurchasesItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Purchases.PurchasesItems_Inventory.Catalog.CatalogItems_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Catalog.CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Purchases.PurchasesItems_Inventory.Purchases.Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Purchases.Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentStatuses",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    AssignedToId = table.Column<Guid>(nullable: true),
                    UpdatedById = table.Column<Guid>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    AppointmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentStatuses_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalSchema: "addon365",
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentStatuses_Users_AssignedToId",
                        column: x => x.AssignedToId,
                        principalSchema: "addon365",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppointmentStatuses_StatusMasters_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "addon365",
                        principalTable: "StatusMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentStatuses_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "addon365",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Sales.SalesItemsProperties",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SalesItemsId = table.Column<Guid>(nullable: false),
                    ProductPropertyMasterId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    GroupId = table.Column<Guid>(nullable: false),
                    SaleItemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Sales.SalesItemsProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Sales.SalesItemsProperties_Inventory.Sales.SalesItems_SaleItemId",
                        column: x => x.SaleItemId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Sales.SalesItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Purchases.PurchasesItemsPropertiesMaps",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PurchaseItemId = table.Column<Guid>(nullable: false),
                    Unit = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Purchases.PurchasesItemsPropertiesMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Purchases.PurchasesItemsPropertiesMaps_Inventory.Purchases.PurchasesItems_PurchaseItemId",
                        column: x => x.PurchaseItemId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Purchases.PurchasesItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Purchases.PurchasesItemsPropertiesValues",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PurchaseItemPropertyMapId = table.Column<Guid>(nullable: false),
                    CatalogPropertyMasterId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Purchases.PurchasesItemsPropertiesValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Purchases.PurchasesItemsPropertiesValues_Inventory.Catalog.CatalogItemPropertyMasters_CatalogPropertyMasterId",
                        column: x => x.CatalogPropertyMasterId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Catalog.CatalogItemPropertyMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Purchases.PurchasesItemsPropertiesValues_Inventory.Purchases.PurchasesItemsPropertiesMaps_PurchaseItemPropertyMapId",
                        column: x => x.PurchaseItemPropertyMapId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Purchases.PurchasesItemsPropertiesMaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddonLicense.LicenseRenewedDetails",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerCatalogGroupId = table.Column<Guid>(nullable: false),
                    RenewedDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    Activated = table.Column<bool>(nullable: false),
                    ActivateDate = table.Column<DateTime>(nullable: false),
                    ActivateComment = table.Column<string>(nullable: true),
                    VoucherId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddonLicense.LicenseRenewedDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddonLicense.LicenseRenewedDetails_Accounts.Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalSchema: "addon365",
                        principalTable: "Accounts.Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Catalog.CustomerCatalogGroup",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerCatalogGroupId = table.Column<string>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: true),
                    CatalogItemId = table.Column<Guid>(nullable: true),
                    NumberofSystem = table.Column<int>(nullable: false),
                    SaleId = table.Column<Guid>(nullable: true),
                    ActivatedOn = table.Column<DateTime>(nullable: false),
                    RenewedDetailId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Catalog.CustomerCatalogGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CustomerCatalogGroup_Inventory.Catalog.CatalogItems_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Catalog.CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CustomerCatalogGroup_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "addon365",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CustomerCatalogGroup_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "addon365",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CustomerCatalogGroup_AddonLicense.LicenseRenewedDetails_RenewedDetailId",
                        column: x => x.RenewedDetailId,
                        principalSchema: "addon365",
                        principalTable: "AddonLicense.LicenseRenewedDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CustomerCatalogGroup_Inventory.Sales.Sales_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Sales.Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddonLicense.LicensedHardwares",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerCatalogGroupId = table.Column<Guid>(nullable: false),
                    HardwareId = table.Column<string>(nullable: true),
                    DeviceName = table.Column<string>(nullable: true),
                    MacAddress = table.Column<string>(nullable: true),
                    DeviceType = table.Column<int>(nullable: false),
                    DeviceComment = table.Column<string>(nullable: true),
                    ActivatedDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddonLicense.LicensedHardwares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddonLicense.LicensedHardwares_Inventory.Catalog.CustomerCatalogGroup_CustomerCatalogGroupId",
                        column: x => x.CustomerCatalogGroupId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Catalog.CustomerCatalogGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Catalog.CustomerCatalogGroupDetail",
                schema: "addon365",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CatalogGroupId = table.Column<Guid>(nullable: true),
                    AddonItemId = table.Column<Guid>(nullable: true),
                    AddedOn = table.Column<DateTime>(nullable: false),
                    WarantyUpto = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    SaleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Catalog.CustomerCatalogGroupDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CustomerCatalogGroupDetail_Inventory.Catalog.CatalogItems_AddonItemId",
                        column: x => x.AddonItemId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Catalog.CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CustomerCatalogGroupDetail_Inventory.Catalog.CustomerCatalogGroup_CatalogGroupId",
                        column: x => x.CatalogGroupId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Catalog.CustomerCatalogGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CustomerCatalogGroupDetail_Inventory.Sales.Sales_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "addon365",
                        principalTable: "Inventory.Sales.Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts.VoucherInfos_VoucherId",
                schema: "addon365",
                table: "Accounts.VoucherInfos",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts.VoucherInfos_bookId",
                schema: "addon365",
                table: "Accounts.VoucherInfos",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts.Vouchers_VoucherTypeId",
                schema: "addon365",
                table: "Accounts.Vouchers",
                column: "VoucherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AddonLicense.LicensedHardwares_CustomerCatalogGroupId",
                schema: "addon365",
                table: "AddonLicense.LicensedHardwares",
                column: "CustomerCatalogGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AddonLicense.LicenseRenewedDetails_CustomerCatalogGroupId",
                schema: "addon365",
                table: "AddonLicense.LicenseRenewedDetails",
                column: "CustomerCatalogGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AddonLicense.LicenseRenewedDetails_VoucherId",
                schema: "addon365",
                table: "AddonLicense.LicenseRenewedDetails",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_LeadId",
                schema: "addon365",
                table: "Appointments",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentStatuses_AppointmentId",
                schema: "addon365",
                table: "AppointmentStatuses",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentStatuses_AssignedToId",
                schema: "addon365",
                table: "AppointmentStatuses",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentStatuses_StatusId",
                schema: "addon365",
                table: "AppointmentStatuses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentStatuses_UpdatedById",
                schema: "addon365",
                table: "AppointmentStatuses",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessContacts_ContactAddressId",
                schema: "addon365",
                table: "BusinessContacts",
                column: "ContactAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessContacts_ContactPersonId",
                schema: "addon365",
                table: "BusinessContacts",
                column: "ContactPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessContacts_ProprietorId",
                schema: "addon365",
                table: "BusinessContacts",
                column: "ProprietorId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignInfos_CampaignId",
                schema: "addon365",
                table: "CampaignInfos",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignInfos_LeadId",
                schema: "addon365",
                table: "CampaignInfos",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitSubscriberDues_ChitSubscriberId",
                schema: "addon365",
                table: "ChitSubscriberDues",
                column: "ChitSubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitSubscriberDues_VoucherId",
                schema: "addon365",
                table: "ChitSubscriberDues",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitSubscribers_ChitSchemeId",
                schema: "addon365",
                table: "ChitSubscribers",
                column: "ChitSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitSubscribers_CustomerId",
                schema: "addon365",
                table: "ChitSubscribers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactAddressId",
                schema: "addon365",
                table: "Contacts",
                column: "ContactAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BusinessContactId",
                schema: "addon365",
                table: "Customers",
                column: "BusinessContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ContactId",
                schema: "addon365",
                table: "Customers",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                schema: "addon365",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ContactId",
                schema: "addon365",
                table: "Employees",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                schema: "addon365",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_ContactId",
                schema: "addon365",
                table: "Enquiries",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_EnquiryTypeId",
                schema: "addon365",
                table: "Enquiries",
                column: "EnquiryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_StatusId",
                schema: "addon365",
                table: "Enquiries",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_VoucherId",
                schema: "addon365",
                table: "Enquiries",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryAccessories_CatalogItemId",
                schema: "addon365",
                table: "EnquiryAccessories",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryAccessories_EnquiryId",
                schema: "addon365",
                table: "EnquiryAccessories",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryExchangeQuotations_EnquiryId",
                schema: "addon365",
                table: "EnquiryExchangeQuotations",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryFinanceQuotations_EnquiryCatalogItemId",
                schema: "addon365",
                table: "EnquiryFinanceQuotations",
                column: "EnquiryCatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryItems_CatalogItemId",
                schema: "addon365",
                table: "EnquiryItems",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryItems_EnquiryId",
                schema: "addon365",
                table: "EnquiryItems",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Buyers_BusinessContactId",
                schema: "addon365",
                table: "Inventory.Buyers",
                column: "BusinessContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CatalogItemPropertiesMaps_CatalogItemId",
                schema: "addon365",
                table: "Inventory.Catalog.CatalogItemPropertiesMaps",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CatalogItemPropertiesMaps_CatalogPropertyMasterId",
                schema: "addon365",
                table: "Inventory.Catalog.CatalogItemPropertiesMaps",
                column: "CatalogPropertyMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CatalogItems_BrandId",
                schema: "addon365",
                table: "Inventory.Catalog.CatalogItems",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CatalogItems_CategoryId",
                schema: "addon365",
                table: "Inventory.Catalog.CatalogItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CustomerCatalogGroup_CatalogItemId",
                schema: "addon365",
                table: "Inventory.Catalog.CustomerCatalogGroup",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CustomerCatalogGroup_CustomerId",
                schema: "addon365",
                table: "Inventory.Catalog.CustomerCatalogGroup",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CustomerCatalogGroup_EmployeeId",
                schema: "addon365",
                table: "Inventory.Catalog.CustomerCatalogGroup",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CustomerCatalogGroup_RenewedDetailId",
                schema: "addon365",
                table: "Inventory.Catalog.CustomerCatalogGroup",
                column: "RenewedDetailId",
                unique: true,
                filter: "[RenewedDetailId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CustomerCatalogGroup_SaleId",
                schema: "addon365",
                table: "Inventory.Catalog.CustomerCatalogGroup",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CustomerCatalogGroupDetail_AddonItemId",
                schema: "addon365",
                table: "Inventory.Catalog.CustomerCatalogGroupDetail",
                column: "AddonItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CustomerCatalogGroupDetail_CatalogGroupId",
                schema: "addon365",
                table: "Inventory.Catalog.CustomerCatalogGroupDetail",
                column: "CatalogGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CustomerCatalogGroupDetail_SaleId",
                schema: "addon365",
                table: "Inventory.Catalog.CustomerCatalogGroupDetail",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.Purchases_SellerId",
                schema: "addon365",
                table: "Inventory.Purchases.Purchases",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.Purchases_VoucherId",
                schema: "addon365",
                table: "Inventory.Purchases.Purchases",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.PurchasesItems_CatalogItemId",
                schema: "addon365",
                table: "Inventory.Purchases.PurchasesItems",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.PurchasesItems_PurchaseId",
                schema: "addon365",
                table: "Inventory.Purchases.PurchasesItems",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.PurchasesItemsPropertiesMaps_PurchaseItemId",
                schema: "addon365",
                table: "Inventory.Purchases.PurchasesItemsPropertiesMaps",
                column: "PurchaseItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.PurchasesItemsPropertiesValues_CatalogPropertyMasterId",
                schema: "addon365",
                table: "Inventory.Purchases.PurchasesItemsPropertiesValues",
                column: "CatalogPropertyMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.PurchasesItemsPropertiesValues_PurchaseItemPropertyMapId",
                schema: "addon365",
                table: "Inventory.Purchases.PurchasesItemsPropertiesValues",
                column: "PurchaseItemPropertyMapId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sales.Sales_BuyerId",
                schema: "addon365",
                table: "Inventory.Sales.Sales",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sales.Sales_CustomerId",
                schema: "addon365",
                table: "Inventory.Sales.Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sales.Sales_VoucherId",
                schema: "addon365",
                table: "Inventory.Sales.Sales",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sales.SalesItems_CatalogItemId",
                schema: "addon365",
                table: "Inventory.Sales.SalesItems",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sales.SalesItems_SaleId",
                schema: "addon365",
                table: "Inventory.Sales.SalesItems",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sales.SalesItemsProperties_SaleItemId",
                schema: "addon365",
                table: "Inventory.Sales.SalesItemsProperties",
                column: "SaleItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sellers_BusinessContactId",
                schema: "addon365",
                table: "Inventory.Sellers",
                column: "BusinessContactId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadHistory_LeadId",
                schema: "addon365",
                table: "LeadHistory",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadHistory_StatusId",
                schema: "addon365",
                table: "LeadHistory",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_ContactId",
                schema: "addon365",
                table: "Leads",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_SourceId",
                schema: "addon365",
                table: "Leads",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_Referer",
                schema: "addon365",
                table: "Threats",
                column: "Referer",
                unique: true,
                filter: "[Referer] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_StatusId",
                schema: "addon365",
                table: "Threats",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_TypeId",
                schema: "addon365",
                table: "Threats",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleGroupId",
                schema: "addon365",
                table: "Users",
                column: "RoleGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddonLicense.LicenseRenewedDetails_Inventory.Catalog.CustomerCatalogGroup_CustomerCatalogGroupId",
                schema: "addon365",
                table: "AddonLicense.LicenseRenewedDetails",
                column: "CustomerCatalogGroupId",
                principalSchema: "addon365",
                principalTable: "Inventory.Catalog.CustomerCatalogGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddonLicense.LicenseRenewedDetails_Accounts.Vouchers_VoucherId",
                schema: "addon365",
                table: "AddonLicense.LicenseRenewedDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory.Sales.Sales_Accounts.Vouchers_VoucherId",
                schema: "addon365",
                table: "Inventory.Sales.Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_AddonLicense.LicenseRenewedDetails_Inventory.Catalog.CustomerCatalogGroup_CustomerCatalogGroupId",
                schema: "addon365",
                table: "AddonLicense.LicenseRenewedDetails");

            migrationBuilder.DropTable(
                name: "Accounts.PaymentModes",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Accounts.VoucherInfos",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "AddonLicense.LicensedHardwares",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "AppointmentStatuses",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "BranchMasters",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "CampaignInfos",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "ChitSubscriberDues",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "DeviceMasters",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Districts",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "EnquiryAccessories",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "EnquiryExchangeQuotations",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "EnquiryFinanceQuotations",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "FinanceCompanies",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "FollowUpModes",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "FollowUpStatuses",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "InquiryReport",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Inventory.Catalog.CatalogItemPropertiesMaps",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Inventory.Catalog.CatalogTypes",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Inventory.Catalog.CustomerCatalogGroupDetail",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Inventory.Purchases.PurchasesItemsPropertiesValues",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Inventory.Sales.SalesItemsProperties",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "LeadHistory",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "LicenseMasters",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Localities",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "marketingZones",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Pincodes",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "States",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "SubDistricts",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Threats",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Accounts.AccountBooks",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Appointments",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "StatusMasters",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Campaigns",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "ChitSubscribers",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "EnquiryItems",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Inventory.Catalog.CatalogItemPropertyMasters",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Inventory.Purchases.PurchasesItemsPropertiesMaps",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Inventory.Sales.SalesItems",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "LeadStatusMasters",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Statuses",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Type",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Leads",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "ChitSchemes",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Enquiries",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Inventory.Purchases.PurchasesItems",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "LeadSources",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "EnquriyType",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "EnquiryStatuses",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Inventory.Purchases.Purchases",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Inventory.Sellers",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Accounts.Vouchers",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Accounts.VoucherTypeMasters",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Inventory.Catalog.CustomerCatalogGroup",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Inventory.Catalog.CatalogItems",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "AddonLicense.LicenseRenewedDetails",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Inventory.Sales.Sales",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Inventory.Catalog.CatalogBrands",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Inventory.Buyers",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "BusinessContacts",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "RoleGroup",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "AddressMasters",
                schema: "addon365");
        }
    }
}
