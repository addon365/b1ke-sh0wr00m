using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace addon365.Chit.EfContext.Migrations
{
    public partial class GroupTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChitGroups_ChitSchemes_ChitSchemeKeyId",
                schema: "addon365",
                table: "ChitGroups");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChitSchemeKeyId",
                schema: "addon365",
                table: "ChitGroups",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ChitGroups_ChitSchemes_ChitSchemeKeyId",
                schema: "addon365",
                table: "ChitGroups",
                column: "ChitSchemeKeyId",
                principalSchema: "addon365",
                principalTable: "ChitSchemes",
                principalColumn: "KeyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChitGroups_ChitSchemes_ChitSchemeKeyId",
                schema: "addon365",
                table: "ChitGroups");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChitSchemeKeyId",
                schema: "addon365",
                table: "ChitGroups",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChitGroups_ChitSchemes_ChitSchemeKeyId",
                schema: "addon365",
                table: "ChitGroups",
                column: "ChitSchemeKeyId",
                principalSchema: "addon365",
                principalTable: "ChitSchemes",
                principalColumn: "KeyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
