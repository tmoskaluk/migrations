using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars.Customers.Crud.Migrations
{
    /// <inheritdoc />
    public partial class CustomerTypeRenamedAndIdentityNoIndexAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                schema: "customers",
                table: "Customers",
                newName: "CustomerType");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdentityNo",
                schema: "customers",
                table: "Customers",
                column: "IdentityNo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_IdentityNo",
                schema: "customers",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CustomerType",
                schema: "customers",
                table: "Customers",
                newName: "Type");
        }
    }
}
