using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iticket.Migrations
{
    /// <inheritdoc />
    public partial class ChangedVenuesIdToHallIdInProductEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductEvents_Venues_VenuesId",
                table: "ProductEvents");

            migrationBuilder.AlterColumn<int>(
                name: "VenuesId",
                table: "ProductEvents",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEvents_Venues_VenuesId",
                table: "ProductEvents",
                column: "VenuesId",
                principalTable: "Venues",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductEvents_Halls_HallId",
                table: "ProductEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductEvents_Venues_VenuesId",
                table: "ProductEvents");

            migrationBuilder.DropIndex(
                name: "IX_ProductEvents_HallId",
                table: "ProductEvents");

            migrationBuilder.DropColumn(
                name: "HallId",
                table: "ProductEvents");

            migrationBuilder.AlterColumn<int>(
                name: "VenuesId",
                table: "ProductEvents",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEvents_Venues_VenuesId",
                table: "ProductEvents",
                column: "VenuesId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
