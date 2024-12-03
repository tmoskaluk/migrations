using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars.Sales.Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sales");

            migrationBuilder.CreateTable(
                name: "Offers",
                schema: "sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false),
                    Configuration_Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Configuration_Engine_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Configuration_Engine_Type = table.Column<int>(type: "int", nullable: true),
                    Configuration_Engine_Capacity = table.Column<int>(type: "int", nullable: true),
                    Configuration_Version = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Configuration_Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Configuration_Engine_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Configuration_Engine_Type = table.Column<int>(type: "int", nullable: true),
                    Configuration_Engine_Capacity = table.Column<int>(type: "int", nullable: true),
                    Configuration_Version = table.Column<int>(type: "int", nullable: true),
                    Customer_CustomerId = table.Column<int>(type: "int", nullable: true),
                    Customer_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OriginalPrice = table.Column<decimal>(type: "money", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderComments",
                schema: "sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderComments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "sales",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderComments_OrderId",
                schema: "sales",
                table: "OrderComments",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "OrderComments",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "sales");
        }
    }
}
