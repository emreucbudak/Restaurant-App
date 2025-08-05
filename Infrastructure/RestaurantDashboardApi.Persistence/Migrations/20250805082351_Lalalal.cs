using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantDashboardApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Lalalal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Desks_DeskId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeskId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Desks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeskId",
                table: "Orders",
                column: "DeskId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Desks_DeskId",
                table: "Orders",
                column: "DeskId",
                principalTable: "Desks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Desks_DeskId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeskId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Desks");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeskId",
                table: "Orders",
                column: "DeskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Desks_DeskId",
                table: "Orders",
                column: "DeskId",
                principalTable: "Desks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
