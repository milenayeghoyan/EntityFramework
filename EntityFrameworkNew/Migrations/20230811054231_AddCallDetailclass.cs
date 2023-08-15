using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkNew.Migrations
{
    /// <inheritdoc />
    public partial class AddCallDetailclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "callDetails",
                columns: table => new
                {
                    CallID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallerNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecieverNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallDuration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_callDetails", x => x.CallID);
                });

            migrationBuilder.CreateTable(
                name: "cancelledOrders",
                columns: table => new
                {
                    Orderid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Customerld = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cancelledOrders", x => x.Orderid);
                    table.ForeignKey(
                        name: "FK_cancelledOrders_Customers2_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers2",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cancelledOrders_CustomerId",
                table: "cancelledOrders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "callDetails");

            migrationBuilder.DropTable(
                name: "cancelledOrders");
        }
    }
}
