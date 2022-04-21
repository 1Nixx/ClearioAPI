using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class ChangeDbStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CleanTeamMemberId",
                table: "CleanTeamMember",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CleaningObjectId",
                table: "CleaningObjects",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CleanTeamMember",
                newName: "CleanTeamMemberId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CleaningObjects",
                newName: "CleaningObjectId");
        }
    }
}
