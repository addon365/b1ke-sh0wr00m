using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace addon365.Chit.EfContext.Migrations
{
    public partial class subscriber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Master",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_Master", x => x.KeyId);
                });

            migrationBuilder.CreateTable(
                name: "RoleGroupMaster",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_RoleGroupMaster", x => x.KeyId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
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
                    ContactAddressKeyId = table.Column<Guid>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_Contacts_Master_ContactAddressKeyId",
                        column: x => x.ContactAddressKeyId,
                        principalSchema: "addon365",
                        principalTable: "Master",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
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
                    RoleGroupId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_User_RoleGroupMaster_RoleGroupId",
                        column: x => x.RoleGroupId,
                        principalSchema: "addon365",
                        principalTable: "RoleGroupMaster",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessContactTable",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
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
                    table.PrimaryKey("PK_BusinessContactTable", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_BusinessContactTable_Master_ContactAddressKeyId",
                        column: x => x.ContactAddressKeyId,
                        principalSchema: "addon365",
                        principalTable: "Master",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessContactTable_Contacts_ContactPersonKeyId",
                        column: x => x.ContactPersonKeyId,
                        principalSchema: "addon365",
                        principalTable: "Contacts",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessContactTable_Contacts_ProprietorKeyId",
                        column: x => x.ProprietorKeyId,
                        principalSchema: "addon365",
                        principalTable: "Contacts",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
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
                    ContactKeyId = table.Column<Guid>(nullable: true),
                    BusinessContactKeyId = table.Column<Guid>(nullable: true),
                    UserKeyId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_Customers_BusinessContactTable_BusinessContactKeyId",
                        column: x => x.BusinessContactKeyId,
                        principalSchema: "addon365",
                        principalTable: "BusinessContactTable",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Contacts_ContactKeyId",
                        column: x => x.ContactKeyId,
                        principalSchema: "addon365",
                        principalTable: "Contacts",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_User_UserKeyId",
                        column: x => x.UserKeyId,
                        principalSchema: "addon365",
                        principalTable: "User",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChitSubscribers",
                schema: "addon365",
                columns: table => new
                {
                    KeyId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDeviceId = table.Column<int>(nullable: true),
                    BranchMasterId = table.Column<Guid>(nullable: true),
                    YearId = table.Column<Guid>(nullable: false),
                    SubscribeAccessId = table.Column<string>(nullable: true),
                    ChitGroupKeyId = table.Column<Guid>(nullable: false),
                    CustomerKeyId = table.Column<Guid>(nullable: false),
                    JoinedDate = table.Column<DateTime>(nullable: false),
                    ClosedVoucherId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChitSubscribers", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_ChitSubscribers_ChitGroups_ChitGroupKeyId",
                        column: x => x.ChitGroupKeyId,
                        principalSchema: "addon365",
                        principalTable: "ChitGroups",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChitSubscribers_Customers_CustomerKeyId",
                        column: x => x.CustomerKeyId,
                        principalSchema: "addon365",
                        principalTable: "Customers",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessContactTable_ContactAddressKeyId",
                schema: "addon365",
                table: "BusinessContactTable",
                column: "ContactAddressKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessContactTable_ContactPersonKeyId",
                schema: "addon365",
                table: "BusinessContactTable",
                column: "ContactPersonKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessContactTable_ProprietorKeyId",
                schema: "addon365",
                table: "BusinessContactTable",
                column: "ProprietorKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitSubscribers_ChitGroupKeyId",
                schema: "addon365",
                table: "ChitSubscribers",
                column: "ChitGroupKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitSubscribers_CustomerKeyId",
                schema: "addon365",
                table: "ChitSubscribers",
                column: "CustomerKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactAddressKeyId",
                schema: "addon365",
                table: "Contacts",
                column: "ContactAddressKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BusinessContactKeyId",
                schema: "addon365",
                table: "Customers",
                column: "BusinessContactKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ContactKeyId",
                schema: "addon365",
                table: "Customers",
                column: "ContactKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserKeyId",
                schema: "addon365",
                table: "Customers",
                column: "UserKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleGroupId",
                schema: "addon365",
                table: "User",
                column: "RoleGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChitSubscribers",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "BusinessContactTable",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "User",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "RoleGroupMaster",
                schema: "addon365");

            migrationBuilder.DropTable(
                name: "Master",
                schema: "addon365");
        }
    }
}
