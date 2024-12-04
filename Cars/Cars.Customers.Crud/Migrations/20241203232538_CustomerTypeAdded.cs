using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars.Customers.Crud.Migrations
{
    /// <inheritdoc />
    public partial class CustomerTypeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "customers",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                schema: "customers",
                table: "Customers");
        }
    }
}
