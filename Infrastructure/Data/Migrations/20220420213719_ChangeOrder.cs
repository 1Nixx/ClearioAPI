using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class ChangeOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CleanTeamMember_CleaningComand_CleaningComandId",
                table: "CleanTeamMember");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CleaningComand_ComandCleaningComandId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "CleaningComand");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ComandCleaningComandId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ComandCleaningComandId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "CleaningComandId",
                table: "CleanTeamMember",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_CleanTeamMember_CleaningComandId",
                table: "CleanTeamMember",
                newName: "IX_CleanTeamMember_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CleanTeamMember_Orders_OrderId",
                table: "CleanTeamMember",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CleanTeamMember_Orders_OrderId",
                table: "CleanTeamMember");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "CleanTeamMember",
                newName: "CleaningComandId");

            migrationBuilder.RenameIndex(
                name: "IX_CleanTeamMember_OrderId",
                table: "CleanTeamMember",
                newName: "IX_CleanTeamMember_CleaningComandId");

            migrationBuilder.AddColumn<int>(
                name: "ComandCleaningComandId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CleaningComand",
                columns: table => new
                {
                    CleaningComandId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningComand", x => x.CleaningComandId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ComandCleaningComandId",
                table: "Orders",
                column: "ComandCleaningComandId");

            migrationBuilder.AddForeignKey(
                name: "FK_CleanTeamMember_CleaningComand_CleaningComandId",
                table: "CleanTeamMember",
                column: "CleaningComandId",
                principalTable: "CleaningComand",
                principalColumn: "CleaningComandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CleaningComand_ComandCleaningComandId",
                table: "Orders",
                column: "ComandCleaningComandId",
                principalTable: "CleaningComand",
                principalColumn: "CleaningComandId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
