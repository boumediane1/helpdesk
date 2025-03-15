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
                newName: "AssigneeId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                newName: "IX_Tickets_AssigneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_AssigneeId",
                table: "Tickets",
                column: "AssigneeId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_AssigneeId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "AssigneeId",
                table: "Tickets",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_AssigneeId",
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
