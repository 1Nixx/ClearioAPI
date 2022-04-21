using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class FixCleanerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "CleanTeamMember",
                newName: "IsStartingWorking");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndWorking",
                table: "CleanTeamMember",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsFinishedWorking",
                table: "CleanTeamMember",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartWorking",
                table: "CleanTeamMember",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndWorking",
                table: "CleanTeamMember");

            migrationBuilder.DropColumn(
                name: "IsFinishedWorking",
                table: "CleanTeamMember");

            migrationBuilder.DropColumn(
                name: "StartWorking",
                table: "CleanTeamMember");

            migrationBuilder.RenameColumn(
                name: "IsStartingWorking",
                table: "CleanTeamMember",
                newName: "IsApproved");
        }
    }
}
