using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iticket.Migrations
{
    /// <inheritdoc />
    public partial class AddTicketIsBooked2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "BasketItems");

            migrationBuilder.AddColumn<bool>(
                name: "isBooked",
                table: "Tickets",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isBooked",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "BasketItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
