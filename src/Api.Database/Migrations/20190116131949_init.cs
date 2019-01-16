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
                name: "Addon");

            migrationBuilder.CreateTable(
                name: "AccountBooks",
                schema: "Addon",
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
                name: "BranchMasters",
                schema: "Addon",
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
                name: "BusinessContact",
                schema: "Addon",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    BusinessName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessContact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                schema: "Addon",
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
                schema: "Addon",
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
                name: "Contacts",
                schema: "Addon",
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
                    Place = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceMasters",
                schema: "Addon",
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
                schema: "Addon",
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
                schema: "Addon",
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
                schema: "Addon",
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
                schema: "Addon",
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
                schema: "Addon",
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
                schema: "Addon",
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
                name: "LicenseMasters",
                schema: "Addon",
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
                schema: "Addon",
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
                schema: "Addon",
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
                name: "ProductCompanies",
                schema: "Addon",
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
                    table.PrimaryKey("PK_ProductCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductPropertiesMaps",
                schema: "Addon",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    ItemPropertyMasterId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPropertiesMaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductPropertyMasters",
                schema: "Addon",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    PropertyMasterId = table.Column<string>(nullable: true),
                    PropertyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPropertyMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Addon",
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
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                schema: "Addon",
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
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItemProperties",
                schema: "Addon",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PurchaseItemsId = table.Column<Guid>(nullable: false),
                    ProductPropertyMasterId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    GroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItemProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                schema: "Addon",
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
                schema: "Addon",
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
                schema: "Addon",
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
                schema: "Addon",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherTypeMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buyers",
                schema: "Addon",
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
                    BusinessContactId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buyers_BusinessContact_BusinessContactId",
                        column: x => x.BusinessContactId,
                        principalSchema: "Addon",
                        principalTable: "BusinessContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                schema: "Addon",
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
                    BusinessContactId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sellers_BusinessContact_BusinessContactId",
                        column: x => x.BusinessContactId,
                        principalSchema: "Addon",
                        principalTable: "BusinessContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Addon",
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
                        principalSchema: "Addon",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "Addon",
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
                        principalSchema: "Addon",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignInfos",
                schema: "Addon",
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
                        principalSchema: "Addon",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignInfos_FollowUpModes_ModeId",
                        column: x => x.ModeId,
                        principalSchema: "Addon",
                        principalTable: "FollowUpModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignInfos_FollowUpStatuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Addon",
                        principalTable: "FollowUpStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExtraFittings",
                schema: "Addon",
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
                    table.PrimaryKey("PK_ExtraFittings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraFittings_Products_AccessoriesProductItemId",
                        column: x => x.AccessoriesProductItemId,
                        principalSchema: "Addon",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExtraFittings_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Addon",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Threats",
                schema: "Addon",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
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
                        name: "FK_Threats_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Addon",
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Threats_Type_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "Addon",
                        principalTable: "Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                schema: "Addon",
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
                        principalSchema: "Addon",
                        principalTable: "VoucherTypeMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                schema: "Addon",
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
                    BusinessContactId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Sellers_BusinessContactId",
                        column: x => x.BusinessContactId,
                        principalSchema: "Addon",
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enquiries",
                schema: "Addon",
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
                        principalSchema: "Addon",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enquiries_EnquriyType_EnquiryTypeId",
                        column: x => x.EnquiryTypeId,
                        principalSchema: "Addon",
                        principalTable: "EnquriyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enquiries_EnquiryStatuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Addon",
                        principalTable: "EnquiryStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enquiries_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalSchema: "Addon",
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                schema: "Addon",
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
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalSchema: "Addon",
                        principalTable: "Buyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Addon",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalSchema: "Addon",
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VouchersInfo",
                schema: "Addon",
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
                        principalSchema: "Addon",
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VouchersInfo_AccountBooks_bookId",
                        column: x => x.bookId,
                        principalSchema: "Addon",
                        principalTable: "AccountBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItems",
                schema: "Addon",
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
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Addon",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalSchema: "Addon",
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnquiryAccessories",
                schema: "Addon",
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
                        principalSchema: "Addon",
                        principalTable: "Enquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnquiryAccessories_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Addon",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnquiryExchangeQuotations",
                schema: "Addon",
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
                        principalSchema: "Addon",
                        principalTable: "Enquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnquiryProducts",
                schema: "Addon",
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
                        principalSchema: "Addon",
                        principalTable: "Enquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnquiryProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Addon",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleItems",
                schema: "Addon",
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
                    table.PrimaryKey("PK_SaleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Addon",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleItems_Sales_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "Addon",
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChitSubscribers",
                schema: "Addon",
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
                        principalSchema: "Addon",
                        principalTable: "ChitSchemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChitSubscribers_VouchersInfo_ClosedVoucherInfoIdId",
                        column: x => x.ClosedVoucherInfoIdId,
                        principalSchema: "Addon",
                        principalTable: "VouchersInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChitSubscribers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Addon",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnquiryFinanceQuotations",
                schema: "Addon",
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
                        principalSchema: "Addon",
                        principalTable: "EnquiryProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleItemsProperties",
                schema: "Addon",
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
                    table.PrimaryKey("PK_SaleItemsProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleItemsProperties_SaleItems_SaleItemId",
                        column: x => x.SaleItemId,
                        principalSchema: "Addon",
                        principalTable: "SaleItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChitSubscriberDues",
                schema: "Addon",
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
                        principalSchema: "Addon",
                        principalTable: "ChitSubscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChitSubscriberDues_VouchersInfo_VoucherInfoId",
                        column: x => x.VoucherInfoId,
                        principalSchema: "Addon",
                        principalTable: "VouchersInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_BusinessContactId",
                schema: "Addon",
                table: "Buyers",
                column: "BusinessContactId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignInfos_ContactId",
                schema: "Addon",
                table: "CampaignInfos",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignInfos_ModeId",
                schema: "Addon",
                table: "CampaignInfos",
                column: "ModeId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignInfos_StatusId",
                schema: "Addon",
                table: "CampaignInfos",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitSubscriberDues_ChitSubscriberId",
                schema: "Addon",
                table: "ChitSubscriberDues",
                column: "ChitSubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitSubscriberDues_VoucherInfoId",
                schema: "Addon",
                table: "ChitSubscriberDues",
                column: "VoucherInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitSubscribers_ChitSchemaId",
                schema: "Addon",
                table: "ChitSubscribers",
                column: "ChitSchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitSubscribers_ClosedVoucherInfoIdId",
                schema: "Addon",
                table: "ChitSubscribers",
                column: "ClosedVoucherInfoIdId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitSubscribers_CustomerId",
                schema: "Addon",
                table: "ChitSubscribers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ProfileId",
                schema: "Addon",
                table: "Customers",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ContactId",
                schema: "Addon",
                table: "Employees",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_ContactId",
                schema: "Addon",
                table: "Enquiries",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_EnquiryTypeId",
                schema: "Addon",
                table: "Enquiries",
                column: "EnquiryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_StatusId",
                schema: "Addon",
                table: "Enquiries",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_VoucherId",
                schema: "Addon",
                table: "Enquiries",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryAccessories_EnquiryId",
                schema: "Addon",
                table: "EnquiryAccessories",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryAccessories_ProductId",
                schema: "Addon",
                table: "EnquiryAccessories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryExchangeQuotations_EnquiryId",
                schema: "Addon",
                table: "EnquiryExchangeQuotations",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryFinanceQuotations_EnquiryProductId",
                schema: "Addon",
                table: "EnquiryFinanceQuotations",
                column: "EnquiryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryProducts_EnquiryId",
                schema: "Addon",
                table: "EnquiryProducts",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryProducts_ProductId",
                schema: "Addon",
                table: "EnquiryProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraFittings_AccessoriesProductItemId",
                schema: "Addon",
                table: "ExtraFittings",
                column: "AccessoriesProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraFittings_ProductId",
                schema: "Addon",
                table: "ExtraFittings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_ProductId",
                schema: "Addon",
                table: "PurchaseItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_PurchaseId",
                schema: "Addon",
                table: "PurchaseItems",
                column: "PurchaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_BusinessContactId",
                schema: "Addon",
                table: "Purchases",
                column: "BusinessContactId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_ProductId",
                schema: "Addon",
                table: "SaleItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_SaleId",
                schema: "Addon",
                table: "SaleItems",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItemsProperties_SaleItemId",
                schema: "Addon",
                table: "SaleItemsProperties",
                column: "SaleItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_BuyerId",
                schema: "Addon",
                table: "Sales",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                schema: "Addon",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_VoucherId",
                schema: "Addon",
                table: "Sales",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_BusinessContactId",
                schema: "Addon",
                table: "Sellers",
                column: "BusinessContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_Referer",
                schema: "Addon",
                table: "Threats",
                column: "Referer",
                unique: true,
                filter: "[Referer] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_StatusId",
                schema: "Addon",
                table: "Threats",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Threats_TypeId",
                schema: "Addon",
                table: "Threats",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_VoucherTypeId",
                schema: "Addon",
                table: "Vouchers",
                column: "VoucherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VouchersInfo_VoucherId",
                schema: "Addon",
                table: "VouchersInfo",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_VouchersInfo_bookId",
                schema: "Addon",
                table: "VouchersInfo",
                column: "bookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchMasters",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "CampaignInfos",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "Campaigns",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "ChitSubscriberDues",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "DeviceMasters",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "EnquiryAccessories",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "EnquiryExchangeQuotations",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "EnquiryFinanceQuotations",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "ExtraFittings",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "FinanceCompanies",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "InquiryReport",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "LicenseMasters",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "marketingZones",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "PaymentModes",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "ProductCompanies",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "ProductPropertiesMaps",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "ProductPropertyMasters",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "ProductTypes",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "PurchaseItemProperties",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "PurchaseItems",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "SaleItemsProperties",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "Threats",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "FollowUpModes",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "FollowUpStatuses",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "ChitSubscribers",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "EnquiryProducts",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "Purchases",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "SaleItems",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "Statuses",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "Type",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "ChitSchemes",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "VouchersInfo",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "Enquiries",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "Sellers",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "Sales",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "AccountBooks",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "EnquriyType",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "EnquiryStatuses",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "Buyers",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "Vouchers",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "BusinessContact",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "Addon");

            migrationBuilder.DropTable(
                name: "VoucherTypeMasters",
                schema: "Addon");
        }
    }
}
