using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barbershop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddLoginColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Barber",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Admin",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Barber");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Admin");
        }
    }
}
