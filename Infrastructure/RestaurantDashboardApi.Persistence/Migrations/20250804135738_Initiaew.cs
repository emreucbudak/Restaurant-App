using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantDashboardApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initiaew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Desks_DeskId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_DeskId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "DeskId",
                table: "OrderItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeskId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_DeskId",
                table: "OrderItems",
                column: "DeskId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Desks_DeskId",
                table: "OrderItems",
                column: "DeskId",
                principalTable: "Desks",
                principalColumn: "Id");
        }
    }
}
