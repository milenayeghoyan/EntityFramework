﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkNew.Migrations
{
    /// <inheritdoc />
    public partial class AddCallDuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CallDuration",
                table: "callDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CallDuration",
                table: "callDetails");
        }
    }
}
