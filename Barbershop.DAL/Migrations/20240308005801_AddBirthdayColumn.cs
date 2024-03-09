﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barbershop.DAL.Migrations;

/// <inheritdoc />
public partial class AddBirthdayColumn : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<DateTime>(
            name: "Birthday",
            table: "User",
            type: "timestamp with time zone",
            nullable: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Birthday",
            table: "User");
    }
}
