using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace addon365.Chit.EfContext.Migrations
{
    public partial class GroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChitGroups",
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
                    ChitGroupAccessId = table.Column<string>(nullable: true),
                    GroupName = table.Column<string>(nullable: true),
                    ChitSchemeKeyId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    TotalMember = table.Column<short>(nullable: false),
                    TotalDues = table.Column<short>(nullable: false),
                    PaymentFrequency = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChitGroups", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_ChitGroups_ChitSchemes_ChitSchemeKeyId",
                        column: x => x.ChitSchemeKeyId,
                        principalSchema: "addon365",
                        principalTable: "ChitSchemes",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChitGroups_ChitSchemeKeyId",
                schema: "addon365",
                table: "ChitGroups",
                column: "ChitSchemeKeyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChitGroups",
                schema: "addon365");
        }
    }
}
