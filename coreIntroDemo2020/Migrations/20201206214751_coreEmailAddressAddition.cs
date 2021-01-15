using Microsoft.EntityFrameworkCore.Migrations;

namespace coreIntroDemo2020.Migrations
{
    public partial class coreEmailAddressAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Student",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Student");
        }
    }
}
