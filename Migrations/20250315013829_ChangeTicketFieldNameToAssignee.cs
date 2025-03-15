using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace helpdesk.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTicketFieldNameToAssignee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_UserId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tickets",
                newName: "ReporterId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                newName: "IX_Tickets_ReporterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_ReporterId",
                table: "Tickets",
                column: "ReporterId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_ReporterId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "ReporterId",
                table: "Tickets",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ReporterId",
                table: "Tickets",
                newName: "IX_Tickets_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_UserId",
                table: "Tickets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
