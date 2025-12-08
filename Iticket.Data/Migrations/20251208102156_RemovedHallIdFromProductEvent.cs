using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iticket.Migrations
{
    /// <inheritdoc />
    public partial class RemovedHallIdFromProductEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductEvents_Halls_HallId",
                table: "ProductEvents");

            migrationBuilder.DropIndex(
                name: "IX_ProductEvents_HallId",
                table: "ProductEvents");

            migrationBuilder.DropColumn(
                name: "HallId",
                table: "ProductEvents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HallId",
                table: "ProductEvents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductEvents_HallId",
                table: "ProductEvents",
                column: "HallId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEvents_Halls_HallId",
                table: "ProductEvents",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
