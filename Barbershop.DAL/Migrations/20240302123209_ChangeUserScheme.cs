using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Barbershop.DAL.Migrations;

/// <inheritdoc />
public partial class ChangeUserScheme : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Email",
            table: "Client");

        migrationBuilder.DropColumn(
            name: "FirstName",
            table: "Client");

        migrationBuilder.DropColumn(
            name: "LastName",
            table: "Client");

        migrationBuilder.DropColumn(
            name: "PhoneNumber",
            table: "Client");

        migrationBuilder.DropColumn(
            name: "Photo",
            table: "Client");

        migrationBuilder.DropColumn(
            name: "Surname",
            table: "Client");

        migrationBuilder.DropColumn(
            name: "Email",
            table: "Barber");

        migrationBuilder.DropColumn(
            name: "FirstName",
            table: "Barber");

        migrationBuilder.DropColumn(
            name: "LastName",
            table: "Barber");

        migrationBuilder.DropColumn(
            name: "PhoneNumber",
            table: "Barber");

        migrationBuilder.DropColumn(
            name: "Photo",
            table: "Barber");

        migrationBuilder.DropColumn(
            name: "Surname",
            table: "Barber");

        migrationBuilder.DropColumn(
            name: "Email",
            table: "Admin");

        migrationBuilder.DropColumn(
            name: "FirstName",
            table: "Admin");

        migrationBuilder.DropColumn(
            name: "LastName",
            table: "Admin");

        migrationBuilder.DropColumn(
            name: "PhoneNumber",
            table: "Admin");

        migrationBuilder.DropColumn(
            name: "Photo",
            table: "Admin");

        migrationBuilder.DropColumn(
            name: "Surname",
            table: "Admin");

        migrationBuilder.AlterColumn<int>(
            name: "Id",
            table: "Client",
            type: "integer",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "integer")
            .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

        migrationBuilder.AlterColumn<int>(
            name: "Id",
            table: "Barber",
            type: "integer",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "integer")
            .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

        migrationBuilder.AlterColumn<int>(
            name: "Id",
            table: "Admin",
            type: "integer",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "integer")
            .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

        migrationBuilder.CreateTable(
            name: "User",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                LastName = table.Column<string>(type: "text", nullable: true),
                FirstName = table.Column<string>(type: "text", nullable: false),
                Surname = table.Column<string>(type: "text", nullable: true),
                Email = table.Column<string>(type: "text", nullable: true),
                PhoneNumber = table.Column<string>(type: "text", nullable: false),
                Photo = table.Column<byte[]>(type: "bytea", nullable: true),
                UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_User", x => x.Id);
            });

        migrationBuilder.AddForeignKey(
            name: "FK_Admin_User_Id",
            table: "Admin",
            column: "Id",
            principalTable: "User",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Barber_User_Id",
            table: "Barber",
            column: "Id",
            principalTable: "User",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Client_User_Id",
            table: "Client",
            column: "Id",
            principalTable: "User",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Admin_User_Id",
            table: "Admin");

        migrationBuilder.DropForeignKey(
            name: "FK_Barber_User_Id",
            table: "Barber");

        migrationBuilder.DropForeignKey(
            name: "FK_Client_User_Id",
            table: "Client");

        migrationBuilder.DropTable(
            name: "User");

        migrationBuilder.AlterColumn<int>(
            name: "Id",
            table: "Client",
            type: "integer",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "integer")
            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

        migrationBuilder.AddColumn<string>(
            name: "Email",
            table: "Client",
            type: "text",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "FirstName",
            table: "Client",
            type: "text",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "LastName",
            table: "Client",
            type: "text",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "PhoneNumber",
            table: "Client",
            type: "text",
            nullable: true);

        migrationBuilder.AddColumn<byte[]>(
            name: "Photo",
            table: "Client",
            type: "bytea",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Surname",
            table: "Client",
            type: "text",
            nullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "Id",
            table: "Barber",
            type: "integer",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "integer")
            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

        migrationBuilder.AddColumn<string>(
            name: "Email",
            table: "Barber",
            type: "text",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "FirstName",
            table: "Barber",
            type: "text",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "LastName",
            table: "Barber",
            type: "text",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "PhoneNumber",
            table: "Barber",
            type: "text",
            nullable: true);

        migrationBuilder.AddColumn<byte[]>(
            name: "Photo",
            table: "Barber",
            type: "bytea",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Surname",
            table: "Barber",
            type: "text",
            nullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "Id",
            table: "Admin",
            type: "integer",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "integer")
            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

        migrationBuilder.AddColumn<string>(
            name: "Email",
            table: "Admin",
            type: "text",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "FirstName",
            table: "Admin",
            type: "text",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "LastName",
            table: "Admin",
            type: "text",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "PhoneNumber",
            table: "Admin",
            type: "text",
            nullable: true);

        migrationBuilder.AddColumn<byte[]>(
            name: "Photo",
            table: "Admin",
            type: "bytea",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Surname",
            table: "Admin",
            type: "text",
            nullable: true);
    }
}
