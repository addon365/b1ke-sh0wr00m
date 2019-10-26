using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace addon365.Database.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "addon");

            migrationBuilder.CreateTable(
                name: "AccountBooks",
                schema: "addon",
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
                    table.PrimaryKey("PK_AccountBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddressMasters",
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                name: "LogicMasters",
                schema: "addon",
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
                    table.PrimaryKey("PK_LogicMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "marketingZones",
                schema: "addon",
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
                name: "PaymentModes",
                schema: "addon",
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
                    table.PrimaryKey("PK_PaymentModes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pincodes",
                schema: "addon",
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
                name: "RoleGroupPermissions",
                schema: "addon",
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
                    GroupId = table.Column<Guid>(nullable: false),
                    LogicId = table.Column<Guid>(nullable: false),
                    Create = table.Column<bool>(nullable: false),
                    Update = table.Column<bool>(nullable: false),
                    View = table.Column<bool>(nullable: false),
                    Delete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGroupPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleGroups",
                schema: "addon",
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
                    table.PrimaryKey("PK_RoleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                schema: "addon",
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
                name: "UserPermissions",
                schema: "addon",
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
                    UserId = table.Column<Guid>(nullable: false),
                    LogicId = table.Column<Guid>(nullable: false),
                    Create = table.Column<bool>(nullable: false),
                    Update = table.Column<bool>(nullable: false),
                    View = table.Column<bool>(nullable: false),
                    Delete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoucherTypeMasters",
                schema: "addon",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: false),
                    ProgrammerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherTypeMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "AddressMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Catalog.CatalogItems",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "Inventory.Catalog.CatalogBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CatalogItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "addon",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "addon",
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
                        name: "FK_Users_RoleGroups_RoleGroupId",
                        column: x => x.RoleGroupId,
                        principalSchema: "addon",
                        principalTable: "RoleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Threats",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Threats_Type_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "addon",
                        principalTable: "Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                schema: "addon",
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
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vouchers_VoucherTypeMasters_VoucherTypeId",
                        column: x => x.VoucherTypeId,
                        principalSchema: "addon",
                        principalTable: "VoucherTypeMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessContacts",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "AddressMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessContacts_Contacts_ContactPersonId",
                        column: x => x.ContactPersonId,
                        principalSchema: "addon",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessContacts_Contacts_ProprietorId",
                        column: x => x.ProprietorId,
                        principalSchema: "addon",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Catalog.CatalogItemPropertiesMaps",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "Inventory.Catalog.CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CatalogItemPropertiesMaps_Inventory.Catalog.CatalogItemPropertyMasters_CatalogPropertyMasterId",
                        column: x => x.CatalogPropertyMasterId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Catalog.CatalogItemPropertyMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "addon",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enquiries",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enquiries_EnquriyType_EnquiryTypeId",
                        column: x => x.EnquiryTypeId,
                        principalSchema: "addon",
                        principalTable: "EnquriyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enquiries_EnquiryStatuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "addon",
                        principalTable: "EnquiryStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enquiries_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalSchema: "addon",
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VouchersInfo",
                schema: "addon",
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
                    table.PrimaryKey("PK_VouchersInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VouchersInfo_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalSchema: "addon",
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VouchersInfo_AccountBooks_bookId",
                        column: x => x.bookId,
                        principalSchema: "addon",
                        principalTable: "AccountBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCustomers",
                schema: "addon",
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
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessCustomers_BusinessContacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "addon",
                        principalTable: "BusinessContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessCustomers_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "addon",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "addon",
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
                    ProfileId = table.Column<Guid>(nullable: true),
                    BusinessContactId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_BusinessContacts_BusinessContactId",
                        column: x => x.BusinessContactId,
                        principalSchema: "addon",
                        principalTable: "BusinessContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Contacts_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "addon",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Buyers",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "BusinessContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Sellers",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "BusinessContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leads",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "BusinessContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leads_LeadSources_SourceId",
                        column: x => x.SourceId,
                        principalSchema: "addon",
                        principalTable: "LeadSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnquiryAccessories",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "Inventory.Catalog.CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnquiryAccessories_Enquiries_EnquiryId",
                        column: x => x.EnquiryId,
                        principalSchema: "addon",
                        principalTable: "Enquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnquiryExchangeQuotations",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "Enquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnquiryItems",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "Inventory.Catalog.CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnquiryItems_Enquiries_EnquiryId",
                        column: x => x.EnquiryId,
                        principalSchema: "addon",
                        principalTable: "Enquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChitSubscribers",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "ChitSchemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChitSubscribers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "addon",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Sales.Sales",
                schema: "addon",
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
                    CustomerId = table.Column<Guid>(nullable: false),
                    BuyerId = table.Column<Guid>(nullable: false),
                    VoucherId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Sales.Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Sales.Sales_Inventory.Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Buyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Sales.Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "addon",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Sales.Sales_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalSchema: "addon",
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Purchases.Purchases",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "Inventory.Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Purchases.Purchases_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalSchema: "addon",
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignInfos",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignInfos_Leads_LeadId",
                        column: x => x.LeadId,
                        principalSchema: "addon",
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadHistory",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeadHistory_LeadStatusMasters_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "addon",
                        principalTable: "LeadStatusMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnquiryFinanceQuotations",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "EnquiryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChitSubscriberDues",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "ChitSubscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChitSubscriberDues_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalSchema: "addon",
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Catalog.CustomerCatalogGroup",
                schema: "addon",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerCatalogGroupId = table.Column<string>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: true),
                    ItemId = table.Column<Guid>(nullable: true),
                    SaleId = table.Column<Guid>(nullable: true),
                    ActivatedOn = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    CreatedEmployeeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Catalog.CustomerCatalogGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CustomerCatalogGroup_Employees_CreatedEmployeeId",
                        column: x => x.CreatedEmployeeId,
                        principalSchema: "addon",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CustomerCatalogGroup_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "addon",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CustomerCatalogGroup_Inventory.Catalog.CatalogItems_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Catalog.CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CustomerCatalogGroup_Inventory.Sales.Sales_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Sales.Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Sales.SalesItems",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "Inventory.Catalog.CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Sales.SalesItems_Inventory.Sales.Sales_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Sales.Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Purchases.PurchasesItems",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "Inventory.Catalog.CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Purchases.PurchasesItems_Inventory.Purchases.Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Purchases.Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentStatuses",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentStatuses_Users_AssignedToId",
                        column: x => x.AssignedToId,
                        principalSchema: "addon",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppointmentStatuses_StatusMasters_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "addon",
                        principalTable: "StatusMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentStatuses_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "addon",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Catalog.CustomerCatalogGroupDetail",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "Inventory.Catalog.CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CustomerCatalogGroupDetail_Inventory.Catalog.CustomerCatalogGroup_CatalogGroupId",
                        column: x => x.CatalogGroupId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Catalog.CustomerCatalogGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory.Catalog.CustomerCatalogGroupDetail_Inventory.Sales.Sales_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Sales.Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Sales.SalesItemsProperties",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "Inventory.Sales.SalesItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Purchases.PurchasesItemsPropertiesMaps",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "Inventory.Purchases.PurchasesItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Purchases.PurchasesItemsPropertiesValues",
                schema: "addon",
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
                        principalSchema: "addon",
                        principalTable: "Inventory.Catalog.CatalogItemPropertyMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Purchases.PurchasesItemsPropertiesValues_Inventory.Purchases.PurchasesItemsPropertiesMaps_PurchaseItemPropertyMapId",
                        column: x => x.PurchaseItemPropertyMapId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Purchases.PurchasesItemsPropertiesMaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_LeadId",
                schema: "addon",
                table: "Appointments",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentStatuses_AppointmentId",
                schema: "addon",
                table: "AppointmentStatuses",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentStatuses_AssignedToId",
                schema: "addon",
                table: "AppointmentStatuses",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentStatuses_StatusId",
                schema: "addon",
                table: "AppointmentStatuses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentStatuses_UpdatedById",
                schema: "addon",
                table: "AppointmentStatuses",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessContacts_ContactAddressId",
                schema: "addon",
                table: "BusinessContacts",
                column: "ContactAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessContacts_ContactPersonId",
                schema: "addon",
                table: "BusinessContacts",
                column: "ContactPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessContacts_ProprietorId",
                schema: "addon",
                table: "BusinessContacts",
                column: "ProprietorId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCustomers_ContactId",
                schema: "addon",
                table: "BusinessCustomers",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCustomers_UserId",
                schema: "addon",
                table: "BusinessCustomers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignInfos_CampaignId",
                schema: "addon",
                table: "CampaignInfos",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignInfos_LeadId",
                schema: "addon",
                table: "CampaignInfos",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitSubscriberDues_ChitSubscriberId",
                schema: "addon",
                table: "ChitSubscriberDues",
                column: "ChitSubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitSubscriberDues_VoucherId",
                schema: "addon",
                table: "ChitSubscriberDues",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitSubscribers_ChitSchemeId",
                schema: "addon",
                table: "ChitSubscribers",
                column: "ChitSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitSubscribers_CustomerId",
                schema: "addon",
                table: "ChitSubscribers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactAddressId",
                schema: "addon",
                table: "Contacts",
                column: "ContactAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BusinessContactId",
                schema: "addon",
                table: "Customers",
                column: "BusinessContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ProfileId",
                schema: "addon",
                table: "Customers",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ContactId",
                schema: "addon",
                table: "Employees",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                schema: "addon",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_ContactId",
                schema: "addon",
                table: "Enquiries",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_EnquiryTypeId",
                schema: "addon",
                table: "Enquiries",
                column: "EnquiryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_StatusId",
                schema: "addon",
                table: "Enquiries",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_VoucherId",
                schema: "addon",
                table: "Enquiries",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryAccessories_CatalogItemId",
                schema: "addon",
                table: "EnquiryAccessories",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryAccessories_EnquiryId",
                schema: "addon",
                table: "EnquiryAccessories",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryExchangeQuotations_EnquiryId",
                schema: "addon",
                table: "EnquiryExchangeQuotations",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryFinanceQuotations_EnquiryCatalogItemId",
                schema: "addon",
                table: "EnquiryFinanceQuotations",
                column: "EnquiryCatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryItems_CatalogItemId",
                schema: "addon",
                table: "EnquiryItems",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryItems_EnquiryId",
                schema: "addon",
                table: "EnquiryItems",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Buyers_BusinessContactId",
                schema: "addon",
                table: "Inventory.Buyers",
                column: "BusinessContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CatalogItemPropertiesMaps_CatalogItemId",
                schema: "addon",
                table: "Inventory.Catalog.CatalogItemPropertiesMaps",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CatalogItemPropertiesMaps_CatalogPropertyMasterId",
                schema: "addon",
                table: "Inventory.Catalog.CatalogItemPropertiesMaps",
                column: "CatalogPropertyMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CatalogItems_BrandId",
                schema: "addon",
                table: "Inventory.Catalog.CatalogItems",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CatalogItems_CategoryId",
                schema: "addon",
                table: "Inventory.Catalog.CatalogItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CustomerCatalogGroup_CreatedEmployeeId",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup",
                column: "CreatedEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CustomerCatalogGroup_CustomerId",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CustomerCatalogGroup_ItemId",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CustomerCatalogGroup_SaleId",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroup",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CustomerCatalogGroupDetail_AddonItemId",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroupDetail",
                column: "AddonItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CustomerCatalogGroupDetail_CatalogGroupId",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroupDetail",
                column: "CatalogGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Catalog.CustomerCatalogGroupDetail_SaleId",
                schema: "addon",
                table: "Inventory.Catalog.CustomerCatalogGroupDetail",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.Purchases_SellerId",
                schema: "addon",
                table: "Inventory.Purchases.Purchases",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.Purchases_VoucherId",
                schema: "addon",
                table: "Inventory.Purchases.Purchases",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.PurchasesItems_CatalogItemId",
                schema: "addon",
                table: "Inventory.Purchases.PurchasesItems",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.PurchasesItems_PurchaseId",
                schema: "addon",
                table: "Inventory.Purchases.PurchasesItems",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.PurchasesItemsPropertiesMaps_PurchaseItemId",
                schema: "addon",
                table: "Inventory.Purchases.PurchasesItemsPropertiesMaps",
                column: "PurchaseItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.PurchasesItemsPropertiesValues_CatalogPropertyMasterId",
                schema: "addon",
                table: "Inventory.Purchases.PurchasesItemsPropertiesValues",
                column: "CatalogPropertyMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.PurchasesItemsPropertiesValues_PurchaseItemPropertyMapId",
                schema: "addon",
                table: "Inventory.Purchases.PurchasesItemsPropertiesValues",
                column: "PurchaseItemPropertyMapId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sales.Sales_BuyerId",
                schema: "addon",
                table: "Inventory.Sales.Sales",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sales.Sales_CustomerId",
                schema: "addon",
                table: "Inventory.Sales.Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sales.Sales_VoucherId",
                schema: "addon",
                table: "Inventory.Sales.Sales",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sales.SalesItems_CatalogItemId",
                schema: "addon",
                table: "Inventory.Sales.SalesItems",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sales.SalesItems_SaleId",
                schema: "addon",
                table: "Inventory.Sales.SalesItems",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sales.SalesItemsProperties_SaleItemId",
                schema: "addon",
                table: "Inventory.Sales.SalesItemsProperties",
                column: "SaleItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sellers_BusinessContactId",
                schema: "addon",
                table: "Inventory.Sellers",
                column: "BusinessContactId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadHistory_LeadId",
                schema: "addon",
                table: "LeadHistory",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadHistory_StatusId",
                schema: "addon",
                table: "LeadHistory",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_ContactId",
                schema: "addon",
                table: "Leads",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_SourceId",
                schema: "addon",
                table: "Leads",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_Referer",
                schema: "addon",
                table: "Threats",
                column: "Referer",
                unique: true,
                filter: "[Referer] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_StatusId",
                schema: "addon",
                table: "Threats",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_TypeId",
                schema: "addon",
                table: "Threats",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleGroupId",
                schema: "addon",
                table: "Users",
                column: "RoleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_VoucherTypeId",
                schema: "addon",
                table: "Vouchers",
                column: "VoucherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VouchersInfo_VoucherId",
                schema: "addon",
                table: "VouchersInfo",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_VouchersInfo_bookId",
                schema: "addon",
                table: "VouchersInfo",
                column: "bookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentStatuses",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "BranchMasters",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "BusinessCustomers",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "CampaignInfos",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "ChitSubscriberDues",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "DeviceMasters",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Districts",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "EnquiryAccessories",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "EnquiryExchangeQuotations",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "EnquiryFinanceQuotations",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "FinanceCompanies",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "FollowUpModes",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "FollowUpStatuses",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "InquiryReport",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Catalog.CatalogItemPropertiesMaps",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Catalog.CatalogTypes",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Catalog.CustomerCatalogGroupDetail",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Purchases.PurchasesItemsPropertiesValues",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Sales.SalesItemsProperties",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "LeadHistory",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "LicenseMasters",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Localities",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "LogicMasters",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "marketingZones",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "PaymentModes",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Pincodes",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "RoleGroupPermissions",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "States",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "SubDistricts",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Threats",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "UserPermissions",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "VouchersInfo",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Appointments",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "StatusMasters",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Campaigns",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "ChitSubscribers",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "EnquiryItems",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Catalog.CustomerCatalogGroup",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Catalog.CatalogItemPropertyMasters",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Purchases.PurchasesItemsPropertiesMaps",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Sales.SalesItems",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "LeadStatusMasters",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Statuses",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Type",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "AccountBooks",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Leads",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "ChitSchemes",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Enquiries",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Purchases.PurchasesItems",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Sales.Sales",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "LeadSources",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "EnquriyType",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "EnquiryStatuses",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Catalog.CatalogItems",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Purchases.Purchases",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Buyers",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "RoleGroups",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Catalog.CatalogBrands",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Sellers",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Vouchers",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "BusinessContacts",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "VoucherTypeMasters",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "AddressMasters",
                schema: "addon");
        }
    }
}
