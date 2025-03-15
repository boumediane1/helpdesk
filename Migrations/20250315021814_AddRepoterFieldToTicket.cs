using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace helpdesk.Migrations
{
    /// <inheritdoc />
    public partial class AddRepoterFieldToTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ReporterId",
                table: "Tickets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReporterId",
                table: "Tickets",
                column: "ReporterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_ReporterId",
                table: "Tickets",
                column: "ReporterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_ReporterId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ReporterId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ReporterId",
                table: "Tickets");
        }
    }
}
