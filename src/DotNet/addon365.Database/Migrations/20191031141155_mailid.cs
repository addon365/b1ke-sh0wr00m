using Microsoft.EntityFrameworkCore.Migrations;

namespace addon365.Database.Migrations
{
    public partial class mailid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerEmailId",
                schema: "addon",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNo",
                schema: "addon",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessMailId",
                schema: "addon",
                table: "BusinessContacts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerEmailId",
                schema: "addon",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MobileNo",
                schema: "addon",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BusinessMailId",
                schema: "addon",
                table: "BusinessContacts");
        }
    }
}
