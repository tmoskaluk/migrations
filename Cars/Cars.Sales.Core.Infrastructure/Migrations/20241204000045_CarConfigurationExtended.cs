using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars.Sales.Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CarConfigurationExtended : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Configuration_Color",
                schema: "sales",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Configuration_GearboxType",
                schema: "sales",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Configuration_Color",
                schema: "sales",
                table: "Offers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Configuration_GearboxType",
                schema: "sales",
                table: "Offers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Configuration_Color",
                schema: "sales",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Configuration_GearboxType",
                schema: "sales",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Configuration_Color",
                schema: "sales",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Configuration_GearboxType",
                schema: "sales",
                table: "Offers");
        }
    }
}
