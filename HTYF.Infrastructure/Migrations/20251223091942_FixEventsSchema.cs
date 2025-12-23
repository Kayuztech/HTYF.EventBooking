using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HTYF.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixEventsSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventBookings_Events_EventId",
                table: "EventBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventBookings",
                table: "EventBookings");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "EventsDbSet");

            migrationBuilder.RenameTable(
                name: "EventBookings",
                newName: "EventBookingsDbSet");

            migrationBuilder.RenameIndex(
                name: "IX_EventBookings_EventId",
                table: "EventBookingsDbSet",
                newName: "IX_EventBookingsDbSet_EventId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "EventsDbSet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "EventsDbSet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "BookerName",
                table: "EventBookingsDbSet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "BookerEmail",
                table: "EventBookingsDbSet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventsDbSet",
                table: "EventsDbSet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventBookingsDbSet",
                table: "EventBookingsDbSet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventBookingsDbSet_EventsDbSet_EventId",
                table: "EventBookingsDbSet",
                column: "EventId",
                principalTable: "EventsDbSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventBookingsDbSet_EventsDbSet_EventId",
                table: "EventBookingsDbSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventsDbSet",
                table: "EventsDbSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventBookingsDbSet",
                table: "EventBookingsDbSet");

            migrationBuilder.RenameTable(
                name: "EventsDbSet",
                newName: "Events");

            migrationBuilder.RenameTable(
                name: "EventBookingsDbSet",
                newName: "EventBookings");

            migrationBuilder.RenameIndex(
                name: "IX_EventBookingsDbSet_EventId",
                table: "EventBookings",
                newName: "IX_EventBookings_EventId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Events",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Events",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BookerName",
                table: "EventBookings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BookerEmail",
                table: "EventBookings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventBookings",
                table: "EventBookings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventBookings_Events_EventId",
                table: "EventBookings",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
