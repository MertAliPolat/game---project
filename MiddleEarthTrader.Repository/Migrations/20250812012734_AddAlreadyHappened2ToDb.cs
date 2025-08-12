using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiddleEarthTrader.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddAlreadyHappened2ToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AlreadyHappened",
                table: "MaterialPriceModifiers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlreadyHappened",
                table: "MaterialPriceModifiers");
        }
    }
}
