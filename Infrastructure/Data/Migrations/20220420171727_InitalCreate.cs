using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "CleaningObjects",
                columns: table => new
                {
                    CleaningObjectId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ObjectName = table.Column<string>(type: "TEXT", nullable: false),
                    ObjectSquare = table.Column<int>(type: "INTEGER", nullable: false),
                    ObjectLocation = table.Column<string>(type: "TEXT", nullable: false),
                    ContactTelephone = table.Column<string>(type: "TEXT", nullable: false),
                    UsualTeamSize = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningObjects", x => x.CleaningObjectId);
                });

            migrationBuilder.CreateTable(
                name: "CleanTeamMember",
                columns: table => new
                {
                    CleanTeamMemberId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    CleanerName = table.Column<string>(type: "TEXT", nullable: false),
                    CleanerId = table.Column<int>(type: "INTEGER", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CleaningComandId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleanTeamMember", x => x.CleanTeamMemberId);
                    table.ForeignKey(
                        name: "FK_CleanTeamMember_CleaningComand_CleaningComandId",
                        column: x => x.CleaningComandId,
                        principalTable: "CleaningComand",
                        principalColumn: "CleaningComandId");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CleaningObjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ComandCleaningComandId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_CleaningComand_ComandCleaningComandId",
                        column: x => x.ComandCleaningComandId,
                        principalTable: "CleaningComand",
                        principalColumn: "CleaningComandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_CleaningObjects_CleaningObjectId",
                        column: x => x.CleaningObjectId,
                        principalTable: "CleaningObjects",
                        principalColumn: "CleaningObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CleanTeamMember_CleaningComandId",
                table: "CleanTeamMember",
                column: "CleaningComandId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CleaningObjectId",
                table: "Orders",
                column: "CleaningObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ComandCleaningComandId",
                table: "Orders",
                column: "ComandCleaningComandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CleanTeamMember");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "CleaningComand");

            migrationBuilder.DropTable(
                name: "CleaningObjects");
        }
    }
}
