using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagement.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Rooms",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceGroup",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ServiceStatus",
                table: "Rooms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ServiceGroup",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ServiceStatus",
                table: "Rooms");
        }
    }
}
