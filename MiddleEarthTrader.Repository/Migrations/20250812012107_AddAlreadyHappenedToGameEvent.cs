using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiddleEarthTrader.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddAlreadyHappenedToGameEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Users_UserId1",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_UserId1",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Inventories");

            migrationBuilder.AddColumn<bool>(
                name: "AlreadyHappened",
                table: "GameEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlreadyHappened",
                table: "GameEvents");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "Inventories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_UserId1",
                table: "Inventories",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Users_UserId1",
                table: "Inventories",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
