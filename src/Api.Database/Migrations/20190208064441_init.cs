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
                name: "AddressMaster",
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
                    table.PrimaryKey("PK_AddressMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchMasters",
                schema: "addon",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BranchName = table.Column<string>(nullable: true),
                    ShortCode = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    LicenseId = table.Column<Guid>(nullable: false)
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
                    Name = table.Column<string>(nullable: true),
                    Filter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
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
                    OtherId = table.Column<int>(nullable: false),
                    DeviceName = table.Column<string>(nullable: true),
                    DeviceId = table.Column<string>(nullable: true),
                    RequestedUser = table.Column<string>(nullable: true),
                    AuthorisedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceMasters", x => x.Id);
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InquiryReport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Products.Product",
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
                    table.PrimaryKey("PK_Inventory.Products.Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Products.ProductCompany",
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
                    Identifier = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    ProgrammerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Products.ProductCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Products.ProductPropertyMaster",
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
                    PropertyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Products.ProductPropertyMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Products.ProductType",
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
                    Identifier = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: false),
                    ProgrammerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Products.ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LicenseMasters",
                schema: "addon",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BusinessName = table.Column<string>(nullable: true),
                    LicenseId = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseMasters", x => x.Id);
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
                    Name = table.Column<string>(nullable: true),
                    ProgrammerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentModes", x => x.Id);
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
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
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
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
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
                    SessionToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                name: "BusinessContact",
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
                    BusinessName = table.Column<string>(nullable: true),
                    ContactAddressId = table.Column<Guid>(nullable: true),
                    Landline = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    SecondaryMobileNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessContact_AddressMaster_ContactAddressId",
                        column: x => x.ContactAddressId,
                        principalSchema: "addon",
                        principalTable: "AddressMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_Contacts_AddressMaster_ContactAddressId",
                        column: x => x.ContactAddressId,
                        principalSchema: "addon",
                        principalTable: "AddressMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Products.ExtraFittingsAccessories",
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
                    ProductId = table.Column<Guid>(nullable: false),
                    AccessoriesProductId = table.Column<Guid>(nullable: false),
                    AccessoriesProductItemId = table.Column<Guid>(nullable: true),
                    Unit = table.Column<double>(nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Products.ExtraFittingsAccessories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Products.ExtraFittingsAccessories_Inventory.Products.Product_AccessoriesProductItemId",
                        column: x => x.AccessoriesProductItemId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Products.Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory.Products.ExtraFittingsAccessories_Inventory.Products.Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Products.Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Products.ProductPropertiesMap",
                schema: "addon",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    ProductPropertyMasterId = table.Column<Guid>(nullable: false),
                    ValueType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Products.ProductPropertiesMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Products.ProductPropertiesMap_Inventory.Products.Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Products.Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Products.ProductPropertiesMap_Inventory.Products.ProductPropertyMaster_ProductPropertyMasterId",
                        column: x => x.ProductPropertyMasterId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Products.ProductPropertyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Inventory.Buyer",
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
                    BuyerId = table.Column<string>(nullable: true),
                    BusinessContactId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Buyer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Buyer_BusinessContact_BusinessContactId",
                        column: x => x.BusinessContactId,
                        principalSchema: "addon",
                        principalTable: "BusinessContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Seller",
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
                    SellerId = table.Column<string>(nullable: true),
                    BusinessContactId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Seller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Seller_BusinessContact_BusinessContactId",
                        column: x => x.BusinessContactId,
                        principalSchema: "addon",
                        principalTable: "BusinessContact",
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
                        name: "FK_CampaignInfos_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "addon",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignInfos_FollowUpModes_ModeId",
                        column: x => x.ModeId,
                        principalSchema: "addon",
                        principalTable: "FollowUpModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignInfos_FollowUpStatuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "addon",
                        principalTable: "FollowUpStatuses",
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
                    Identifier = table.Column<string>(nullable: true),
                    ProfileId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Contacts_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "addon",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_Employees_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "addon",
                        principalTable: "Contacts",
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
                name: "Inventory.Purchases.Purchase",
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
                    PurchaseInvoiceNo = table.Column<string>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    SellerId = table.Column<Guid>(nullable: false),
                    VoucherId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Purchases.Purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Purchases.Purchase_Inventory.Seller_SellerId",
                        column: x => x.SellerId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Seller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Purchases.Purchase_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalSchema: "addon",
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Sales.Sale",
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
                    table.PrimaryKey("PK_Inventory.Sales.Sale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Sales.Sale_Inventory.Buyer_BuyerId",
                        column: x => x.BuyerId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Buyer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Sales.Sale_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "addon",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Sales.Sale_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalSchema: "addon",
                        principalTable: "Vouchers",
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
                    EnquiryId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    AccessoriesId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryAccessories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnquiryAccessories_Enquiries_EnquiryId",
                        column: x => x.EnquiryId,
                        principalSchema: "addon",
                        principalTable: "Enquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnquiryAccessories_Inventory.Products.Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Products.Product",
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
                name: "EnquiryProducts",
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
                        name: "FK_EnquiryProducts_Enquiries_EnquiryId",
                        column: x => x.EnquiryId,
                        principalSchema: "addon",
                        principalTable: "Enquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnquiryProducts_Inventory.Products.Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Products.Product",
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
                    SubscribeId = table.Column<string>(nullable: true),
                    ChitSchemaId = table.Column<Guid>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: true),
                    JoinedDate = table.Column<DateTime>(nullable: false),
                    ClosedVoucherInfoIdId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChitSubscribers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChitSubscribers_ChitSchemes_ChitSchemaId",
                        column: x => x.ChitSchemaId,
                        principalSchema: "addon",
                        principalTable: "ChitSchemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChitSubscribers_VouchersInfo_ClosedVoucherInfoIdId",
                        column: x => x.ClosedVoucherInfoIdId,
                        principalSchema: "addon",
                        principalTable: "VouchersInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChitSubscribers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "addon",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Purchases.PurchaseItem",
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
                    PurchaseId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Unit = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Purchases.PurchaseItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Purchases.PurchaseItem_Inventory.Products.Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Products.Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Purchases.PurchaseItem_Inventory.Purchases.Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Purchases.Purchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Sales.SaleItem",
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
                    SalesId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    SaleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Sales.SaleItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Sales.SaleItem_Inventory.Products.Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Products.Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Sales.SaleItem_Inventory.Sales.Sale_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Sales.Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    EnquiryProductId = table.Column<Guid>(nullable: false),
                    InitialDownPayment = table.Column<double>(nullable: false),
                    MonthlyEMIAmount = table.Column<double>(nullable: false),
                    NumberOfMonths = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryFinanceQuotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnquiryFinanceQuotations_EnquiryProducts_EnquiryProductId",
                        column: x => x.EnquiryProductId,
                        principalSchema: "addon",
                        principalTable: "EnquiryProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ChitSubscriberId = table.Column<Guid>(nullable: true),
                    DueNo = table.Column<string>(nullable: true),
                    VoucherInfoId = table.Column<Guid>(nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChitSubscriberDues_VouchersInfo_VoucherInfoId",
                        column: x => x.VoucherInfoId,
                        principalSchema: "addon",
                        principalTable: "VouchersInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Purchases.PurchaseItemPropertyMap",
                schema: "addon",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PurchaseItemId = table.Column<Guid>(nullable: false),
                    Unit = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Purchases.PurchaseItemPropertyMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Purchases.PurchaseItemPropertyMap_Inventory.Purchases.PurchaseItem_PurchaseItemId",
                        column: x => x.PurchaseItemId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Purchases.PurchaseItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Sales.SaleItemProperty",
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
                    table.PrimaryKey("PK_Inventory.Sales.SaleItemProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Sales.SaleItemProperty_Inventory.Sales.SaleItem_SaleItemId",
                        column: x => x.SaleItemId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Sales.SaleItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory.Purchases.PurchaseItemPropertyValue",
                schema: "addon",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PurchaseItemPropertyMapId = table.Column<Guid>(nullable: false),
                    ProductPropertyMasterId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory.Purchases.PurchaseItemPropertyValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory.Purchases.PurchaseItemPropertyValue_Inventory.Products.ProductPropertyMaster_ProductPropertyMasterId",
                        column: x => x.ProductPropertyMasterId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Products.ProductPropertyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory.Purchases.PurchaseItemPropertyValue_Inventory.Purchases.PurchaseItemPropertyMap_PurchaseItemPropertyMapId",
                        column: x => x.PurchaseItemPropertyMapId,
                        principalSchema: "addon",
                        principalTable: "Inventory.Purchases.PurchaseItemPropertyMap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessContact_ContactAddressId",
                schema: "addon",
                table: "BusinessContact",
                column: "ContactAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignInfos_ContactId",
                schema: "addon",
                table: "CampaignInfos",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignInfos_ModeId",
                schema: "addon",
                table: "CampaignInfos",
                column: "ModeId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignInfos_StatusId",
                schema: "addon",
                table: "CampaignInfos",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitSubscriberDues_ChitSubscriberId",
                schema: "addon",
                table: "ChitSubscriberDues",
                column: "ChitSubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitSubscriberDues_VoucherInfoId",
                schema: "addon",
                table: "ChitSubscriberDues",
                column: "VoucherInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitSubscribers_ChitSchemaId",
                schema: "addon",
                table: "ChitSubscribers",
                column: "ChitSchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitSubscribers_ClosedVoucherInfoIdId",
                schema: "addon",
                table: "ChitSubscribers",
                column: "ClosedVoucherInfoIdId");

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
                name: "IX_EnquiryAccessories_EnquiryId",
                schema: "addon",
                table: "EnquiryAccessories",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryAccessories_ProductId",
                schema: "addon",
                table: "EnquiryAccessories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryExchangeQuotations_EnquiryId",
                schema: "addon",
                table: "EnquiryExchangeQuotations",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryFinanceQuotations_EnquiryProductId",
                schema: "addon",
                table: "EnquiryFinanceQuotations",
                column: "EnquiryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryProducts_EnquiryId",
                schema: "addon",
                table: "EnquiryProducts",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryProducts_ProductId",
                schema: "addon",
                table: "EnquiryProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Buyer_BusinessContactId",
                schema: "addon",
                table: "Inventory.Buyer",
                column: "BusinessContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Products.ExtraFittingsAccessories_AccessoriesProductItemId",
                schema: "addon",
                table: "Inventory.Products.ExtraFittingsAccessories",
                column: "AccessoriesProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Products.ExtraFittingsAccessories_ProductId",
                schema: "addon",
                table: "Inventory.Products.ExtraFittingsAccessories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Products.ProductPropertiesMap_ProductId",
                schema: "addon",
                table: "Inventory.Products.ProductPropertiesMap",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Products.ProductPropertiesMap_ProductPropertyMasterId",
                schema: "addon",
                table: "Inventory.Products.ProductPropertiesMap",
                column: "ProductPropertyMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.Purchase_SellerId",
                schema: "addon",
                table: "Inventory.Purchases.Purchase",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.Purchase_VoucherId",
                schema: "addon",
                table: "Inventory.Purchases.Purchase",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.PurchaseItem_ProductId",
                schema: "addon",
                table: "Inventory.Purchases.PurchaseItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.PurchaseItem_PurchaseId",
                schema: "addon",
                table: "Inventory.Purchases.PurchaseItem",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.PurchaseItemPropertyMap_PurchaseItemId",
                schema: "addon",
                table: "Inventory.Purchases.PurchaseItemPropertyMap",
                column: "PurchaseItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.PurchaseItemPropertyValue_ProductPropertyMasterId",
                schema: "addon",
                table: "Inventory.Purchases.PurchaseItemPropertyValue",
                column: "ProductPropertyMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Purchases.PurchaseItemPropertyValue_PurchaseItemPropertyMapId",
                schema: "addon",
                table: "Inventory.Purchases.PurchaseItemPropertyValue",
                column: "PurchaseItemPropertyMapId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sales.Sale_BuyerId",
                schema: "addon",
                table: "Inventory.Sales.Sale",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sales.Sale_CustomerId",
                schema: "addon",
                table: "Inventory.Sales.Sale",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sales.Sale_VoucherId",
                schema: "addon",
                table: "Inventory.Sales.Sale",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sales.SaleItem_ProductId",
                schema: "addon",
                table: "Inventory.Sales.SaleItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sales.SaleItem_SaleId",
                schema: "addon",
                table: "Inventory.Sales.SaleItem",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Sales.SaleItemProperty_SaleItemId",
                schema: "addon",
                table: "Inventory.Sales.SaleItemProperty",
                column: "SaleItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory.Seller_BusinessContactId",
                schema: "addon",
                table: "Inventory.Seller",
                column: "BusinessContactId");

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
                name: "BranchMasters",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "CampaignInfos",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Campaigns",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "ChitSubscriberDues",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "DeviceMasters",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Employees",
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
                name: "InquiryReport",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Products.ExtraFittingsAccessories",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Products.ProductCompany",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Products.ProductPropertiesMap",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Products.ProductType",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Purchases.PurchaseItemPropertyValue",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Sales.SaleItemProperty",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "LicenseMasters",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "marketingZones",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "PaymentModes",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Threats",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "FollowUpModes",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "FollowUpStatuses",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "ChitSubscribers",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "EnquiryProducts",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Products.ProductPropertyMaster",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Purchases.PurchaseItemPropertyMap",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Sales.SaleItem",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Statuses",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Type",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "ChitSchemes",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "VouchersInfo",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Enquiries",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Purchases.PurchaseItem",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Sales.Sale",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "AccountBooks",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "EnquriyType",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "EnquiryStatuses",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Products.Product",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Purchases.Purchase",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Buyer",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Inventory.Seller",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Vouchers",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "BusinessContact",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "VoucherTypeMasters",
                schema: "addon");

            migrationBuilder.DropTable(
                name: "AddressMaster",
                schema: "addon");
        }
    }
}
