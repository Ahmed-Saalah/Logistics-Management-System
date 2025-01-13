﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class fixCircularDepend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shipments_PaymentId",
                table: "Shipments");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "Shipments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_PaymentId",
                table: "Shipments",
                column: "PaymentId",
                unique: true,
                filter: "[PaymentId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shipments_PaymentId",
                table: "Shipments");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_PaymentId",
                table: "Shipments",
                column: "PaymentId",
                unique: true);
        }
    }
}
