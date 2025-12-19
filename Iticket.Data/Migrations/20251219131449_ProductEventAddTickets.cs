using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iticket.Migrations
{
    /// <inheritdoc />
    public partial class ProductEventAddTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductEventId",
                table: "Tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProductEventId",
                table: "Tickets",
                column: "ProductEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ProductEvents_ProductEventId",
                table: "Tickets",
                column: "ProductEventId",
                principalTable: "ProductEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ProductEvents_ProductEventId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ProductEventId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ProductEventId",
                table: "Tickets");
        }
    }
}
