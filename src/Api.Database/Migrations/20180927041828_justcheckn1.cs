using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Api.Database.Migrations
{
    public partial class justcheckn1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "swc");

            migrationBuilder.CreateTable(
                name: "EnquiryStatuses",
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
                    table.PrimaryKey("PK_EnquiryStatuses", x => x.Id);
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
                name: "ExchangeQuotations",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Expected = table.Column<double>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    NoOfOwner = table.Column<int>(nullable: false),
                    Quotated = table.Column<double>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeQuotations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinanceQuotations",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    DownPayment = table.Column<double>(nullable: false),
                    EMIAmount = table.Column<double>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    TenureInMonths = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceQuotations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "marketingZones",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ZonalDescription = table.Column<string>(nullable: true),
                    ZonalName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marketingZones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ProductName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
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
                name: "Statuses",
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
                    table.PrimaryKey("PK_Statuses", x => x.Id);
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
                name: "ExtraFittings",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccessoriesProductId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraFittings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraFittings_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "swc",
                        principalTable: "Products",
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
                        name: "FK_Enquiries_EnquiryStatuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "swc",
                        principalTable: "EnquiryStatuses",
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
                name: "EnquiryExchangeQuotations",
                schema: "swc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    EnquiryId = table.Column<Guid>(nullable: false),
                    ExchangeQuotationId = table.Column<Guid>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryExchangeQuotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnquiryExchangeQuotations_Enquiries_EnquiryId",
                        column: x => x.EnquiryId,
                        principalSchema: "swc",
                        principalTable: "Enquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnquiryExchangeQuotations_ExchangeQuotations_ExchangeQuotationId",
                        column: x => x.ExchangeQuotationId,
                        principalSchema: "swc",
                        principalTable: "ExchangeQuotations",
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
                    EnquiryId = table.Column<Guid>(nullable: false),
                    FinanceQuotationId = table.Column<Guid>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryFinanceQuotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnquiryFinanceQuotations_Enquiries_EnquiryId",
                        column: x => x.EnquiryId,
                        principalSchema: "swc",
                        principalTable: "Enquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnquiryFinanceQuotations_FinanceQuotations_FinanceQuotationId",
                        column: x => x.FinanceQuotationId,
                        principalSchema: "swc",
                        principalTable: "FinanceQuotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnquiryFinanceQuotations_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "swc",
                        principalTable: "Products",
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
                name: "IX_EnquiryExchangeQuotations_EnquiryId",
                schema: "swc",
                table: "EnquiryExchangeQuotations",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryExchangeQuotations_ExchangeQuotationId",
                schema: "swc",
                table: "EnquiryExchangeQuotations",
                column: "ExchangeQuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryFinanceQuotations_EnquiryId",
                schema: "swc",
                table: "EnquiryFinanceQuotations",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryFinanceQuotations_FinanceQuotationId",
                schema: "swc",
                table: "EnquiryFinanceQuotations",
                column: "FinanceQuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryFinanceQuotations_ProductId",
                schema: "swc",
                table: "EnquiryFinanceQuotations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraFittings_ProductId",
                schema: "swc",
                table: "ExtraFittings",
                column: "ProductId");

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
                name: "EnquiryExchangeQuotations",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "EnquiryFinanceQuotations",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "ExtraFittings",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "marketingZones",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Threats",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "ExchangeQuotations",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Enquiries",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "FinanceQuotations",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Statuses",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Type",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "EnquriyType",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "Profiles",
                schema: "swc");

            migrationBuilder.DropTable(
                name: "EnquiryStatuses",
                schema: "swc");
        }
    }
}
