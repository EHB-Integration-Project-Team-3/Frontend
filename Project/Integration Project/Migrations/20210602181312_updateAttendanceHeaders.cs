using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Project.Migrations
{
    public partial class updateAttendanceHeaders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AttendeeId",
                table: "Attendances",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttendeeId",
                table: "Attendances");
        }
    }
}
