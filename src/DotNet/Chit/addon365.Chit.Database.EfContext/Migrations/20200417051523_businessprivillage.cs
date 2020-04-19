using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace addon365.Chit.Database.EfContext.Migrations
{
    public partial class businessprivillage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "addon365");

            migrationBuilder.CreateTable(
                name: "Accounting.AccountBooks",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    CompanyMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    BookName = table.Column<string>(nullable: true),
                    UnderAccountGroupKeyId = table.Column<Guid>(nullable: false),
                    ProgId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounting.AccountBooks", x => x.KeyId);
                });

            migrationBuilder.CreateTable(
                name: "Accounting.AccountGroups",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    AccountGroupName = table.Column<string>(nullable: true),
                    ParentGroupId = table.Column<Guid>(nullable: true),
                    ProgId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounting.AccountGroups", x => x.KeyId);
                });

            migrationBuilder.CreateTable(
                name: "Accounting.VoucherTypes",
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
                    table.PrimaryKey("PK_Accounting.VoucherTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchPrivilages",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    BusinessPrivilageKeyId = table.Column<Guid>(nullable: false),
                    CurrentValue = table.Column<string>(nullable: true),
                    DefaultValue = table.Column<string>(nullable: true),
                    ValueOptions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchPrivilages", x => x.KeyId);
                });

            migrationBuilder.CreateTable(
                name: "BusinessPrivilages",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    PropertyName = table.Column<string>(nullable: true),
                    CurrentValue = table.Column<string>(nullable: true),
                    DefaultValue = table.Column<string>(nullable: true),
                    ValueOptions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPrivilages", x => x.KeyId);
                });

            migrationBuilder.CreateTable(
                name: "Chit.ChitSchemes",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_Chit.ChitSchemes", x => x.KeyId);
                });

            migrationBuilder.CreateTable(
                name: "Crm.Address.Address",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_Crm.Address.Address", x => x.KeyId);
                });

            migrationBuilder.CreateTable(
                name: "User.UserRoleGroups",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    CompanyMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User.UserRoleGroups", x => x.KeyId);
                });

            migrationBuilder.CreateTable(
                name: "UserPrivilages",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    BusinessPrivilageKeyId = table.Column<Guid>(nullable: false),
                    CurrentValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrivilages", x => x.KeyId);
                });

            migrationBuilder.CreateTable(
                name: "UserRolePrivilages",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    BusinessPrivilageKeyId = table.Column<Guid>(nullable: false),
                    CurrentValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRolePrivilages", x => x.KeyId);
                });

            migrationBuilder.CreateTable(
                name: "Accounting.AccountBookFieldMaps",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    CompanyMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    FieldNameKey = table.Column<string>(nullable: true),
                    AccountBookKeyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounting.AccountBookFieldMaps", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_Accounting.AccountBookFieldMaps_Accounting.AccountBooks_AccountBookKeyId",
                        column: x => x.AccountBookKeyId,
                        principalSchema: "addon365",
                        principalTable: "Accounting.AccountBooks",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounting.Vouchers",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    CompanyMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    AccessId = table.Column<string>(nullable: true),
                    VoucherDate = table.Column<DateTime>(nullable: false),
                    VoucherTypeKeyId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounting.Vouchers", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_Accounting.Vouchers_Accounting.VoucherTypes_VoucherTypeKeyId",
                        column: x => x.VoucherTypeKeyId,
                        principalSchema: "addon365",
                        principalTable: "Accounting.VoucherTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chit.ChitGroups",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    AccessId = table.Column<string>(nullable: true),
                    GroupName = table.Column<string>(nullable: true),
                    ChitSchemeKeyId = table.Column<Guid>(nullable: true),
                    ChitDueAmount = table.Column<decimal>(nullable: false),
                    TotalMember = table.Column<short>(nullable: false),
                    TotalDues = table.Column<short>(nullable: false),
                    PaymentFrequency = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chit.ChitGroups", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_Chit.ChitGroups_Chit.ChitSchemes_ChitSchemeKeyId",
                        column: x => x.ChitSchemeKeyId,
                        principalSchema: "addon365",
                        principalTable: "Chit.ChitSchemes",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Crm.Contacts",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    SecondaryMobileNo = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    ContactAddressKeyId = table.Column<Guid>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crm.Contacts", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_Crm.Contacts_Crm.Address.Address_ContactAddressKeyId",
                        column: x => x.ContactAddressKeyId,
                        principalSchema: "addon365",
                        principalTable: "Crm.Address.Address",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User.Users",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    OtherId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ConfirmPassword = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    SessionToken = table.Column<string>(nullable: true),
                    NotificationToken = table.Column<string>(nullable: true),
                    RoleGroupKeyId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User.Users", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_User.Users_User.UserRoleGroups_RoleGroupKeyId",
                        column: x => x.RoleGroupKeyId,
                        principalSchema: "addon365",
                        principalTable: "User.UserRoleGroups",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounting.VoucherInfos",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    CompanyMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    VoucherKeyId = table.Column<Guid>(nullable: false),
                    AccountBookKeyId = table.Column<Guid>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    IsCredit = table.Column<bool>(nullable: false),
                    FieldInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounting.VoucherInfos", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_Accounting.VoucherInfos_Accounting.AccountBooks_AccountBookKeyId",
                        column: x => x.AccountBookKeyId,
                        principalSchema: "addon365",
                        principalTable: "Accounting.AccountBooks",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounting.VoucherInfos_Accounting.Vouchers_VoucherKeyId",
                        column: x => x.VoucherKeyId,
                        principalSchema: "addon365",
                        principalTable: "Accounting.Vouchers",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agency.Agent",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    AccessId = table.Column<string>(nullable: true),
                    ContactId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agency.Agent", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_Agency.Agent_Crm.Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "addon365",
                        principalTable: "Crm.Contacts",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crm.BusinessContacts",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    CompanyMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    BusinessName = table.Column<string>(nullable: true),
                    BusinessMailId = table.Column<string>(nullable: true),
                    ContactAddressKeyId = table.Column<Guid>(nullable: true),
                    ProprietorKeyId = table.Column<Guid>(nullable: true),
                    ContactPersonKeyId = table.Column<Guid>(nullable: true),
                    Landline = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    SecondaryMobileNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crm.BusinessContacts", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_Crm.BusinessContacts_Crm.Address.Address_ContactAddressKeyId",
                        column: x => x.ContactAddressKeyId,
                        principalSchema: "addon365",
                        principalTable: "Crm.Address.Address",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Crm.BusinessContacts_Crm.Contacts_ContactPersonKeyId",
                        column: x => x.ContactPersonKeyId,
                        principalSchema: "addon365",
                        principalTable: "Crm.Contacts",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Crm.BusinessContacts_Crm.Contacts_ProprietorKeyId",
                        column: x => x.ProprietorKeyId,
                        principalSchema: "addon365",
                        principalTable: "Crm.Contacts",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Crm.Customers",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    AccessId = table.Column<string>(nullable: true),
                    CustomerEmailId = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    ContactKeyId = table.Column<Guid>(nullable: true),
                    BusinessContactKeyId = table.Column<Guid>(nullable: true),
                    UserKeyId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crm.Customers", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_Crm.Customers_Crm.BusinessContacts_BusinessContactKeyId",
                        column: x => x.BusinessContactKeyId,
                        principalSchema: "addon365",
                        principalTable: "Crm.BusinessContacts",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Crm.Customers_Crm.Contacts_ContactKeyId",
                        column: x => x.ContactKeyId,
                        principalSchema: "addon365",
                        principalTable: "Crm.Contacts",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Crm.Customers_User.Users_UserKeyId",
                        column: x => x.UserKeyId,
                        principalSchema: "addon365",
                        principalTable: "User.Users",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chit.ChitSubscribers",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    CompanyMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    AccessId = table.Column<string>(nullable: true),
                    ChitGroupKeyId = table.Column<Guid>(nullable: false),
                    CustomerKeyId = table.Column<Guid>(nullable: false),
                    AgentKeyId = table.Column<Guid>(nullable: true),
                    JoinedDate = table.Column<DateTime>(nullable: false),
                    ClosedVoucherId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chit.ChitSubscribers", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_Chit.ChitSubscribers_Agency.Agent_AgentKeyId",
                        column: x => x.AgentKeyId,
                        principalSchema: "addon365",
                        principalTable: "Agency.Agent",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chit.ChitSubscribers_Chit.ChitGroups_ChitGroupKeyId",
                        column: x => x.ChitGroupKeyId,
                        principalSchema: "addon365",
                        principalTable: "Chit.ChitGroups",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chit.ChitSubscribers_Crm.Customers_CustomerKeyId",
                        column: x => x.CustomerKeyId,
                        principalSchema: "addon365",
                        principalTable: "Crm.Customers",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chit.ChitSubscriberDues",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    CreatedDeviceId = table.Column<Guid>(nullable: true),
                    CompanyMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    AccessId = table.Column<string>(nullable: true),
                    ChitSubscriberKeyId = table.Column<Guid>(nullable: false),
                    DueNo = table.Column<int>(nullable: false),
                    DueAmountInfoKeyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chit.ChitSubscriberDues", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_Chit.ChitSubscriberDues_Chit.ChitSubscribers_ChitSubscriberKeyId",
                        column: x => x.ChitSubscriberKeyId,
                        principalSchema: "addon365",
                        principalTable: "Chit.ChitSubscribers",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chit.ChitSubscriberDues_Accounting.VoucherInfos_DueAmountInfoKeyId",
                        column: x => x.DueAmountInfoKeyId,
                        principalSchema: "addon365",
                        principalTable: "Accounting.VoucherInfos",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "addon365",
                table: "Accounting.AccountBooks",
                columns: new[] { "KeyId", "BookName", "CompanyMasterId", "Created", "CreatedDeviceId", "CreatedUserId", "Deleted", "Identifier", "Modified", "ProgId", "UnderAccountGroupKeyId", "YearId" },
                values: new object[,]
                {
                    { new Guid("2f242136-24df-4561-a68c-d7cd749132b0"), "Cash", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("8d9c5eed-e58a-4310-85d5-9fd11ea55f4c"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("1b95a6c7-02e2-4628-a9a0-7c9f6f48b34f"), "Chit Collection", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("838c911c-623f-4a8c-b63c-b5aaadc7fa69"), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                schema: "addon365",
                table: "Accounting.AccountGroups",
                columns: new[] { "KeyId", "AccountGroupName", "ParentGroupId", "ProgId" },
                values: new object[,]
                {
                    { new Guid("e1aeb4a6-f7e0-43a2-bd75-3b877e9911eb"), "Sundry Creditors", new Guid("98878d64-004b-4440-be67-483127850351"), 0 },
                    { new Guid("4d3041e7-4895-44b4-b7ea-f071e9182a68"), "Sundry Debitors", new Guid("98878d64-004b-4440-be67-483127850351"), 0 },
                    { new Guid("23e344e7-1a7d-4a92-8b21-c33b540e6b56"), "Provisions", new Guid("98878d64-004b-4440-be67-483127850351"), 0 },
                    { new Guid("3a33d356-9688-4e84-9da5-881fc26ca4f9"), "Capital Account", new Guid("98878d64-004b-4440-be67-483127850351"), 0 },
                    { new Guid("5aebceab-75ba-41be-ad78-d4af060c8aab"), "Branch / Divisions", new Guid("98878d64-004b-4440-be67-483127850351"), 0 },
                    { new Guid("3829fe81-18b6-4f46-8036-ec2134a38c82"), "Direct Incomes", new Guid("8ce77381-3472-4a29-8ba6-dc7d70f23e66"), 0 },
                    { new Guid("d95ed166-2a39-42c8-b03b-861fcacbb66c"), "InDirect Incomes", new Guid("8ce77381-3472-4a29-8ba6-dc7d70f23e66"), 0 },
                    { new Guid("c87b3cb5-373f-49ac-a627-caa67b702d76"), "Provisions", new Guid("8ce77381-3472-4a29-8ba6-dc7d70f23e66"), 0 },
                    { new Guid("09cf37fc-c3c2-49a6-aa92-52c7c5bd90be"), "Reserves & Surplus", new Guid("8ce77381-3472-4a29-8ba6-dc7d70f23e66"), 0 },
                    { new Guid("22cffdf6-85c6-47aa-81f1-26370fbf9aa5"), "SalesAccount", new Guid("8ce77381-3472-4a29-8ba6-dc7d70f23e66"), 0 },
                    { new Guid("5bf50f3b-fa79-4493-ac5b-37b8bb3d6da6"), "Direct Expenses", new Guid("9462ce54-7323-40c7-8210-32a3b3a254be"), 0 },
                    { new Guid("e982fb44-167d-4de2-8168-03f8efd28319"), "Indirect Expenses", new Guid("9462ce54-7323-40c7-8210-32a3b3a254be"), 0 },
                    { new Guid("b7674f29-18da-48e7-8686-b6a636a5b911"), "Purchase Accounting", new Guid("9462ce54-7323-40c7-8210-32a3b3a254be"), 0 },
                    { new Guid("639ef160-708f-4568-823f-64197d40076e"), "Ratained Earnings", new Guid("9462ce54-7323-40c7-8210-32a3b3a254be"), 0 },
                    { new Guid("8c5e9b63-048c-4a24-af26-123f33f31253"), "Duties & Taxes", new Guid("98878d64-004b-4440-be67-483127850351"), 0 },
                    { new Guid("c2928176-40cd-4d7c-b7e3-31c391d4ab5e"), "Loan(Liability)", new Guid("98878d64-004b-4440-be67-483127850351"), 0 },
                    { new Guid("5cf7d367-69c4-434e-a429-3a6250222695"), "Bank OCC", new Guid("98878d64-004b-4440-be67-483127850351"), 0 },
                    { new Guid("0a99203e-80e6-4c4b-9f13-a3143eafce57"), "Deposits(Assets)", new Guid("488d3ca5-cbf4-45de-a820-ae8e33f31082"), 0 },
                    { new Guid("488d3ca5-cbf4-45de-a820-ae8e33f31082"), "Assets", null, 1 },
                    { new Guid("98878d64-004b-4440-be67-483127850351"), "Liabilities", null, 2 },
                    { new Guid("8ce77381-3472-4a29-8ba6-dc7d70f23e66"), "Income", null, 3 },
                    { new Guid("9462ce54-7323-40c7-8210-32a3b3a254be"), "Expense", null, 4 },
                    { new Guid("8d9c5eed-e58a-4310-85d5-9fd11ea55f4c"), "Cash In Hand", new Guid("488d3ca5-cbf4-45de-a820-ae8e33f31082"), 0 },
                    { new Guid("838c911c-623f-4a8c-b63c-b5aaadc7fa69"), "Current Liabilities", new Guid("98878d64-004b-4440-be67-483127850351"), 0 },
                    { new Guid("45e0bd74-5a00-44a8-b63e-af5e4ac8eac8"), "Bank Account", new Guid("488d3ca5-cbf4-45de-a820-ae8e33f31082"), 0 },
                    { new Guid("189c3e1d-0751-48c2-a27e-f7670e03088e"), "Inventments", new Guid("488d3ca5-cbf4-45de-a820-ae8e33f31082"), 0 },
                    { new Guid("ed85d0ba-502b-4adb-9541-ac2af25560c6"), "Fixed Assets", new Guid("488d3ca5-cbf4-45de-a820-ae8e33f31082"), 0 },
                    { new Guid("df33ab99-c22d-417f-9e3a-537f177954a3"), "Suspense A/c", new Guid("488d3ca5-cbf4-45de-a820-ae8e33f31082"), 0 },
                    { new Guid("5f4a823b-7e0d-4877-9658-26c8a5921ad5"), "Unsecured Loans", new Guid("488d3ca5-cbf4-45de-a820-ae8e33f31082"), 0 },
                    { new Guid("38df0155-693f-4ed0-bba6-ddb4f78a5b81"), "Miscellineous Expenses(Assets)", new Guid("488d3ca5-cbf4-45de-a820-ae8e33f31082"), 0 },
                    { new Guid("bf02b8a0-4bb0-4892-90d9-17cf9e2bfdb5"), "Current Assets", new Guid("488d3ca5-cbf4-45de-a820-ae8e33f31082"), 0 },
                    { new Guid("918cc17c-f679-4dd6-aee8-bc22758c6a16"), "Loan & Advance(Assets)", new Guid("488d3ca5-cbf4-45de-a820-ae8e33f31082"), 0 }
                });

            migrationBuilder.InsertData(
                schema: "addon365",
                table: "BusinessPrivilages",
                columns: new[] { "KeyId", "CurrentValue", "DefaultValue", "PropertyName", "Source", "ValueOptions" },
                values: new object[] { new Guid("11ed6ee7-ec5e-45f7-a28d-dd748365b51f"), "false", "false", "Agent", "addon365.Chit.DomainEntity.Feature", "true,false" });

            migrationBuilder.InsertData(
                schema: "addon365",
                table: "Crm.Contacts",
                columns: new[] { "KeyId", "Address", "AddressId", "ContactAddressKeyId", "FirstName", "LastName", "MobileNumber", "Place", "SecondaryMobileNo" },
                values: new object[] { new Guid("d7f4e8e9-5e3b-4e79-98db-20b817a31813"), null, null, null, "None", null, null, null, null });

            migrationBuilder.InsertData(
                schema: "addon365",
                table: "Accounting.AccountBookFieldMaps",
                columns: new[] { "KeyId", "AccountBookKeyId", "CompanyMasterId", "Created", "CreatedDeviceId", "CreatedUserId", "Deleted", "FieldNameKey", "Modified", "YearId" },
                values: new object[] { new Guid("9fca1dc7-a435-4bcb-9355-f7b7a4ad8a95"), new Guid("1b95a6c7-02e2-4628-a9a0-7c9f6f48b34f"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "addon365.Chit.DataEntity.ChitSubscriberDueTable.DueAmountInfoKeyId", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                schema: "addon365",
                table: "Agency.Agent",
                columns: new[] { "KeyId", "AccessId", "ContactId" },
                values: new object[] { new Guid("4ac9a0ec-d5aa-4972-8f6a-488c74cacd29"), "0", new Guid("d7f4e8e9-5e3b-4e79-98db-20b817a31813") });

            migrationBuilder.CreateIndex(
                name: "IX_Accounting.AccountBookFieldMaps_AccountBookKeyId",
                schema: "addon365",
                table: "Accounting.AccountBookFieldMaps",
                column: "AccountBookKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounting.VoucherInfos_AccountBookKeyId",
                schema: "addon365",
                table: "Accounting.VoucherInfos",
                column: "AccountBookKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounting.VoucherInfos_VoucherKeyId",
                schema: "addon365",
                table: "Accounting.VoucherInfos",
                column: "VoucherKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounting.Vouchers_VoucherTypeKeyId",
                schema: "addon365",
                table: "Accounting.Vouchers",
                column: "VoucherTypeKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Agency.Agent_ContactId",
                schema: "addon365",
                table: "Agency.Agent",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Chit.ChitGroups_ChitSchemeKeyId",
                schema: "addon365",
                table: "Chit.ChitGroups",
                column: "ChitSchemeKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Chit.ChitSubscriberDues_ChitSubscriberKeyId",
                schema: "addon365",
                table: "Chit.ChitSubscriberDues",
                column: "ChitSubscriberKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Chit.ChitSubscriberDues_DueAmountInfoKeyId",
                schema: "addon365",
                table: "Chit.ChitSubscriberDues",
                column: "DueAmountInfoKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Chit.ChitSubscribers_AgentKeyId",
                schema: "addon365",
                table: "Chit.ChitSubscribers",
                column: "AgentKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Chit.ChitSubscribers_ChitGroupKeyId",
                schema: "addon365",
                table: "Chit.ChitSubscribers",
                column: "ChitGroupKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Chit.ChitSubscribers_CustomerKeyId",
                schema: "addon365",
                table: "Chit.ChitSubscribers",
                column: "CustomerKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Crm.BusinessContacts_ContactAddressKeyId",
                schema: "addon365",
                table: "Crm.BusinessContacts",
                column: "ContactAddressKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Crm.BusinessContacts_ContactPersonKeyId",
                schema: "addon365",
                table: "Crm.BusinessContacts",
                column: "ContactPersonKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Crm.BusinessContacts_ProprietorKeyId",
                schema: "addon365",
                table: "Crm.BusinessContacts",
                column: "ProprietorKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Crm.Contacts_ContactAddressKeyId",
                schema: "addon365",
                table: "Crm.Contacts",
                column: "ContactAddressKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Crm.Customers_BusinessContactKeyId",
                schema: "addon365",
                table: "Crm.Customers",
                column: "BusinessContactKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Crm.Customers_ContactKeyId",
                schema: "addon365",
                table: "Crm.Customers",
                column: "ContactKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Crm.Customers_UserKeyId",
                schema: "addon365",
                table: "Crm.Customers",
                column: "UserKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_User.Users_RoleGroupKeyId",
                schema: "addon365",
                table: "User.Users",
                column: "RoleGroupKeyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounting.AccountBookFieldMaps",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Accounting.AccountGroups",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "BranchPrivilages",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "BusinessPrivilages",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Chit.ChitSubscriberDues",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "UserPrivilages",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "UserRolePrivilages",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Chit.ChitSubscribers",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Accounting.VoucherInfos",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Agency.Agent",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Chit.ChitGroups",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Crm.Customers",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Accounting.AccountBooks",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Accounting.Vouchers",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Chit.ChitSchemes",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Crm.BusinessContacts",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "User.Users",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Accounting.VoucherTypes",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Crm.Contacts",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "User.UserRoleGroups",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Crm.Address.Address",
                schema: "addon365");
        }
    }
}
