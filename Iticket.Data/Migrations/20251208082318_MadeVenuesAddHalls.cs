using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iticket.Migrations
{
    /// <inheritdoc />
    public partial class MadeVenuesAddHalls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VenuesId",
                table: "Halls",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Halls_VenuesId",
                table: "Halls",
                column: "VenuesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_Venues_VenuesId",
                table: "Halls",
                column: "VenuesId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Halls_Venues_VenuesId",
                table: "Halls");

            migrationBuilder.DropIndex(
                name: "IX_Halls_VenuesId",
                table: "Halls");

            migrationBuilder.DropColumn(
                name: "VenuesId",
                table: "Halls");
        }
    }
}
