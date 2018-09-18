using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Api.Database.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "swc");

            migrationBuilder.CreateTable(
                name: "EnquiryStatus",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnquriyType",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquriyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enquiries",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    EnquiryTypeId = table.Column<Guid>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ProfileId = table.Column<Guid>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquiries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enquiries_EnquriyType_EnquiryTypeId",
                        column: x => x.EnquiryTypeId,
                        principalSchema: "swc",
                        principalTable: "EnquriyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enquiries_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "swc",
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enquiries_EnquiryStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "swc",
                        principalTable: "EnquiryStatus",
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
                    Host = table.Column<string>(nullable: true),
                    Identifier = table.Column<string>(nullable: true, computedColumnSql: "CONCAT('swc-',[Id])"),
                    Modified = table.Column<DateTime>(nullable: false),
                    Protocol = table.Column<string>(nullable: true),
                    QueryString = table.Column<string>(nullable: true),
                    Referer = table.Column<string>(maxLength: 255, nullable: true),
                    StatusId = table.Column<Guid>(nullable: false),
                    TypeId = table.Column<Guid>(nullable: false),
                    UserAgent = table.Column<string>(nullable: true),
                    XForwardHost = table.Column<string>(nullable: true),
                    XForwardProto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Threats_Status_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "swc",
                        principalTable: "Status",
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

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_EnquiryTypeId",
                schema: "swc",
                table: "Enquiries",
                column: "EnquiryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_ProfileId",
                schema: "swc",
                table: "Enquiries",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_StatusId",
                schema: "swc",
                table: "Enquiries",
                column: "StatusId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enquiries",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Threats",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "EnquriyType",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Profiles",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "EnquiryStatus",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Status",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Type",
                schema: "swc");
        }
    }
}
