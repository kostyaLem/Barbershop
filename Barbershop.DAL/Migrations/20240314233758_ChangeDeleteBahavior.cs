using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barbershop.DAL.Migrations;

/// <inheritdoc />
public partial class ChangeDeleteBahavior : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
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

        migrationBuilder.AddForeignKey(
            name: "FK_Admin_User_Id",
            table: "Admin",
            column: "Id",
            principalTable: "User",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Barber_User_Id",
            table: "Barber",
            column: "Id",
            principalTable: "User",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Client_User_Id",
            table: "Client",
            column: "Id",
            principalTable: "User",
            principalColumn: "Id");
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
}
