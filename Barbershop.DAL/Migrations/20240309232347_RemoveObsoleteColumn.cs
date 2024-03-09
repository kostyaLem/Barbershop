using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barbershop.DAL.Migrations;

/// <inheritdoc />
public partial class RemoveObsoleteColumn : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "UpdatedOn",
            table: "User");

        migrationBuilder.DropColumn(
            name: "UpdatedOn",
            table: "ServiceSkillLevel");

        migrationBuilder.DropColumn(
            name: "UpdatedOn",
            table: "Service");

        migrationBuilder.DropColumn(
            name: "UpdatedOn",
            table: "Product");

        migrationBuilder.DropColumn(
            name: "UpdatedOn",
            table: "Order");

        migrationBuilder.DropColumn(
            name: "UpdatedOn",
            table: "Client");

        migrationBuilder.DropColumn(
            name: "UpdatedOn",
            table: "BarbershopParameterRows");

        migrationBuilder.DropColumn(
            name: "UpdatedOn",
            table: "Barber");

        migrationBuilder.DropColumn(
            name: "UpdatedOn",
            table: "Admin");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<DateTime>(
            name: "UpdatedOn",
            table: "User",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<DateTime>(
            name: "UpdatedOn",
            table: "ServiceSkillLevel",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<DateTime>(
            name: "UpdatedOn",
            table: "Service",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<DateTime>(
            name: "UpdatedOn",
            table: "Product",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<DateTime>(
            name: "UpdatedOn",
            table: "Order",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<DateTime>(
            name: "UpdatedOn",
            table: "Client",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<DateTime>(
            name: "UpdatedOn",
            table: "BarbershopParameterRows",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<DateTime>(
            name: "UpdatedOn",
            table: "Barber",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<DateTime>(
            name: "UpdatedOn",
            table: "Admin",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
    }
}
