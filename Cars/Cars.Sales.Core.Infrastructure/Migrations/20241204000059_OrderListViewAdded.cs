using Cars.SharedKernel.Extensions;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars.Sales.Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderListViewAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.ExecuteSqlEmbeddedResourceScript<OrderListViewAdded>(MigrationType.Up);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DROP VIEW {SalesDbContext.SchemaName}.OrderListView");
        }
    }
}
