using Cars.SharedKernel.Extensions;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars.Sales.Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderListViewChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.ExecuteSqlEmbeddedResourceScript<OrderListViewChanged>(MigrationType.Up);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.ExecuteSqlEmbeddedResourceScript<OrderListViewChanged>(MigrationType.Down);
        }
    }
}
