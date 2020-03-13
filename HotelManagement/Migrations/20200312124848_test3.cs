using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagement.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceGroup = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ServiceStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");

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
    }
}
