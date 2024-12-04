using Cars.SharedKernel.Extensions;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars.Customers.Crud.Migrations
{
    /// <inheritdoc />
    public partial class SeedDealerData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.ExecuteSqlEmbeddedResourceScript<SeedDealerData>(MigrationType.Up);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM customers.Customers WHERE Id = -1");
        }
    }
}
