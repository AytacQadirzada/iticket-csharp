using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iticket.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHallsVenuesIdVenueId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Halls_Venues_VenuesId",
                table: "Halls");

            migrationBuilder.RenameColumn(
                name: "VenuesId",
                table: "Halls",
                newName: "VenueId");

            migrationBuilder.RenameIndex(
                name: "IX_Halls_VenuesId",
                table: "Halls",
                newName: "IX_Halls_VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_Venues_VenueId",
                table: "Halls",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Halls_Venues_VenueId",
                table: "Halls");

            migrationBuilder.RenameColumn(
                name: "VenueId",
                table: "Halls",
                newName: "VenuesId");

            migrationBuilder.RenameIndex(
                name: "IX_Halls_VenueId",
                table: "Halls",
                newName: "IX_Halls_VenuesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_Venues_VenuesId",
                table: "Halls",
                column: "VenuesId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
