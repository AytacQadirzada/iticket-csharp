using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iticket.Migrations
{
    /// <inheritdoc />
    public partial class ChangedVenuesIdToHallIdInProductEventV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductEvents_Venues_VenuesId",
                table: "ProductEvents");

            migrationBuilder.DropIndex(
                name: "IX_ProductEvents_VenuesId",
                table: "ProductEvents");

            migrationBuilder.DropColumn(
                name: "VenuesId",
                table: "ProductEvents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VenuesId",
                table: "ProductEvents",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductEvents_VenuesId",
                table: "ProductEvents",
                column: "VenuesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEvents_Venues_VenuesId",
                table: "ProductEvents",
                column: "VenuesId",
                principalTable: "Venues",
                principalColumn: "Id");
        }
    }
}
