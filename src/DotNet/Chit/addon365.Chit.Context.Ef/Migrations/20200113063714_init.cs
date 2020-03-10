using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace addon365.Chit.Context.Ef.Migrations
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
                    table.PrimaryKey("PK_Accounts.AccountBooks", x => x.KeyId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts.AccountGroups",
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
                    table.PrimaryKey("PK_Accounts.AccountGroups", x => x.KeyId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts.VoucherTypes",
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
                    table.PrimaryKey("PK_Accounts.VoucherTypes", x => x.Id);
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
                name: "Accounts.AccountBookFieldMaps",
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
                    table.PrimaryKey("PK_Accounts.AccountBookFieldMaps", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_Accounts.AccountBookFieldMaps_Accounts.AccountBooks_AccountBookKeyId",
                        column: x => x.AccountBookKeyId,
                        principalSchema: "addon365",
                        principalTable: "Accounts.AccountBooks",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts.Vouchers",
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
                    table.PrimaryKey("PK_Accounts.Vouchers", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_Accounts.Vouchers_Accounts.VoucherTypes_VoucherTypeKeyId",
                        column: x => x.VoucherTypeKeyId,
                        principalSchema: "addon365",
                        principalTable: "Accounts.VoucherTypes",
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
                name: "Accounts.VoucherInfos",
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
                    table.PrimaryKey("PK_Accounts.VoucherInfos", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_Accounts.VoucherInfos_Accounts.AccountBooks_AccountBookKeyId",
                        column: x => x.AccountBookKeyId,
                        principalSchema: "addon365",
                        principalTable: "Accounts.AccountBooks",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts.VoucherInfos_Accounts.Vouchers_VoucherKeyId",
                        column: x => x.VoucherKeyId,
                        principalSchema: "addon365",
                        principalTable: "Accounts.Vouchers",
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
                        name: "FK_Chit.ChitSubscriberDues_Accounts.VoucherInfos_DueAmountInfoKeyId",
                        column: x => x.DueAmountInfoKeyId,
                        principalSchema: "addon365",
                        principalTable: "Accounts.VoucherInfos",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "addon365",
                table: "Accounts.AccountBooks",
                columns: new[] { "KeyId", "BookName", "CompanyMasterId", "Created", "CreatedDeviceId", "CreatedUserId", "Deleted", "Identifier", "Modified", "ProgId", "UnderAccountGroupKeyId", "YearId" },
                values: new object[,]
                {
                    { new Guid("4e8a9e56-bf45-465e-b414-6025e7482371"), "Cash", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("1bc990b2-7d3a-4e00-a0e5-5e0ca2784c1b"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("30941403-b26a-451b-84b8-0fa8dea05a29"), "Chit Collection", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("70bbde02-2486-4491-9406-6cfb93a51ab1"), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                schema: "addon365",
                table: "Accounts.AccountGroups",
                columns: new[] { "KeyId", "AccountGroupName", "ParentGroupId", "ProgId" },
                values: new object[,]
                {
                    { new Guid("72c2686b-e4fe-497f-8d11-c9f15c31a381"), "Sundry Creditors", new Guid("21673da4-3a5b-49b1-933d-36024d01e528"), 0 },
                    { new Guid("8562d6be-2f27-47b5-aeee-2c93023017aa"), "Sundry Debitors", new Guid("21673da4-3a5b-49b1-933d-36024d01e528"), 0 },
                    { new Guid("f90f407c-d1ae-468a-9200-9063c6f5e07b"), "Provisions", new Guid("21673da4-3a5b-49b1-933d-36024d01e528"), 0 },
                    { new Guid("1bc11c71-01bf-4d90-9f78-1ec29d22dba3"), "Capital Account", new Guid("21673da4-3a5b-49b1-933d-36024d01e528"), 0 },
                    { new Guid("f226b659-bb8e-494f-ae37-969775fc7e74"), "Branch / Divisions", new Guid("21673da4-3a5b-49b1-933d-36024d01e528"), 0 },
                    { new Guid("8df7698e-e265-44b4-9003-ffd36cf8fc1a"), "Direct Incomes", new Guid("3a6caf12-c606-45a0-8089-1c25e29210e0"), 0 },
                    { new Guid("1601306a-b43c-46c7-8dd8-58df32572517"), "InDirect Incomes", new Guid("3a6caf12-c606-45a0-8089-1c25e29210e0"), 0 },
                    { new Guid("e8b52185-ffde-438e-b207-2f64f62577d4"), "Provisions", new Guid("3a6caf12-c606-45a0-8089-1c25e29210e0"), 0 },
                    { new Guid("28e93b35-2a73-4054-ab78-f6216d5fa2fa"), "Reserves & Surplus", new Guid("3a6caf12-c606-45a0-8089-1c25e29210e0"), 0 },
                    { new Guid("e730cf45-f39c-47e5-83e3-066276767c15"), "SalesAccount", new Guid("3a6caf12-c606-45a0-8089-1c25e29210e0"), 0 },
                    { new Guid("5cdee992-dfd0-4375-8b75-d1c1be386a8c"), "Direct Expenses", new Guid("c19bd82a-fa96-47fe-bc83-d7c33ab08f01"), 0 },
                    { new Guid("3528693d-7ac0-48c3-9e9b-b18fc83aeb16"), "Indirect Expenses", new Guid("c19bd82a-fa96-47fe-bc83-d7c33ab08f01"), 0 },
                    { new Guid("79494c17-5183-45e6-8694-ed13fd62cbc5"), "Purchase Accounts", new Guid("c19bd82a-fa96-47fe-bc83-d7c33ab08f01"), 0 },
                    { new Guid("87017279-3131-4580-a346-d91b0d1c55e0"), "Duties & Taxes", new Guid("21673da4-3a5b-49b1-933d-36024d01e528"), 0 },
                    { new Guid("a9300868-d060-4b20-888d-710ab02358a8"), "Loan(Liability)", new Guid("21673da4-3a5b-49b1-933d-36024d01e528"), 0 },
                    { new Guid("40915c92-5209-4605-9bd2-768811498b9e"), "Bank OCC", new Guid("21673da4-3a5b-49b1-933d-36024d01e528"), 0 },
                    { new Guid("320dd5b5-84db-4934-b46a-3252eec89382"), "Deposits(Assets)", new Guid("6b50177f-9812-4bdc-ba44-f2ce472deea1"), 0 },
                    { new Guid("6b50177f-9812-4bdc-ba44-f2ce472deea1"), "Assets", null, 1 },
                    { new Guid("21673da4-3a5b-49b1-933d-36024d01e528"), "Liabilities", null, 2 },
                    { new Guid("3a6caf12-c606-45a0-8089-1c25e29210e0"), "Income", null, 3 },
                    { new Guid("c19bd82a-fa96-47fe-bc83-d7c33ab08f01"), "Expense", null, 4 },
                    { new Guid("1bc990b2-7d3a-4e00-a0e5-5e0ca2784c1b"), "Cash In Hand", new Guid("6b50177f-9812-4bdc-ba44-f2ce472deea1"), 0 },
                    { new Guid("70bbde02-2486-4491-9406-6cfb93a51ab1"), "Current Liabilities", new Guid("21673da4-3a5b-49b1-933d-36024d01e528"), 0 },
                    { new Guid("7c8d793e-b92f-4331-bf56-82e73e32e342"), "Ratained Earnings", new Guid("c19bd82a-fa96-47fe-bc83-d7c33ab08f01"), 0 },
                    { new Guid("b6afeff9-abf0-4530-a62a-831c30300200"), "Bank Account", new Guid("6b50177f-9812-4bdc-ba44-f2ce472deea1"), 0 },
                    { new Guid("54c6d740-3992-4a9c-ad68-1c5b87f21ba5"), "Inventments", new Guid("6b50177f-9812-4bdc-ba44-f2ce472deea1"), 0 },
                    { new Guid("24f5284a-1736-4753-b1d9-cd9e3a3c5555"), "Fixed Assets", new Guid("6b50177f-9812-4bdc-ba44-f2ce472deea1"), 0 },
                    { new Guid("e36f2ad7-4f29-44b5-81da-681aaf4a1944"), "Suspense A/c", new Guid("6b50177f-9812-4bdc-ba44-f2ce472deea1"), 0 },
                    { new Guid("f2464796-afd0-4c57-939d-e94a877a4834"), "Unsecured Loans", new Guid("6b50177f-9812-4bdc-ba44-f2ce472deea1"), 0 },
                    { new Guid("e3899175-8ddf-4b3d-90b2-56e34a61a093"), "Miscellineous Expenses(Assets)", new Guid("6b50177f-9812-4bdc-ba44-f2ce472deea1"), 0 },
                    { new Guid("96f43f7e-e420-429d-ba48-b4cd1bbf878a"), "Current Assets", new Guid("6b50177f-9812-4bdc-ba44-f2ce472deea1"), 0 },
                    { new Guid("35a5708d-fff1-4ab6-99e3-024a18a26efb"), "Loan & Advance(Assets)", new Guid("6b50177f-9812-4bdc-ba44-f2ce472deea1"), 0 }
                });

            migrationBuilder.InsertData(
                schema: "addon365",
                table: "Crm.Contacts",
                columns: new[] { "KeyId", "Address", "AddressId", "ContactAddressKeyId", "FirstName", "LastName", "MobileNumber", "Place", "SecondaryMobileNo" },
                values: new object[] { new Guid("288f6529-e1bf-4aaf-b348-63df7dc3d7ee"), null, null, null, "None", null, null, null, null });

            migrationBuilder.InsertData(
                schema: "addon365",
                table: "Accounts.AccountBookFieldMaps",
                columns: new[] { "KeyId", "AccountBookKeyId", "CompanyMasterId", "Created", "CreatedDeviceId", "CreatedUserId", "Deleted", "FieldNameKey", "Modified", "YearId" },
                values: new object[] { new Guid("695ef085-3109-499f-86dc-ef753ae26aa9"), new Guid("30941403-b26a-451b-84b8-0fa8dea05a29"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "addon365.Chit.DataEntity.ChitSubscriberDueTable.DueAmountInfoKeyId", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                schema: "addon365",
                table: "Agency.Agent",
                columns: new[] { "KeyId", "AccessId", "ContactId" },
                values: new object[] { new Guid("52860493-d41d-489d-a2bc-f75fc5366e92"), "0", new Guid("288f6529-e1bf-4aaf-b348-63df7dc3d7ee") });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts.AccountBookFieldMaps_AccountBookKeyId",
                schema: "addon365",
                table: "Accounts.AccountBookFieldMaps",
                column: "AccountBookKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts.VoucherInfos_AccountBookKeyId",
                schema: "addon365",
                table: "Accounts.VoucherInfos",
                column: "AccountBookKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts.VoucherInfos_VoucherKeyId",
                schema: "addon365",
                table: "Accounts.VoucherInfos",
                column: "VoucherKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts.Vouchers_VoucherTypeKeyId",
                schema: "addon365",
                table: "Accounts.Vouchers",
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
                name: "Accounts.AccountBookFieldMaps",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Accounts.AccountGroups",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Chit.ChitSubscriberDues",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Chit.ChitSubscribers",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Accounts.VoucherInfos",
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
                name: "Accounts.AccountBooks",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Accounts.Vouchers",
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
                name: "Accounts.VoucherTypes",
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
