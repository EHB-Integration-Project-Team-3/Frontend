using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Project.Migrations
{
    public partial class Seed_Event : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Uuid = table.Column<Guid>(nullable: false),
                    StreetName = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Uuid);
                });

           
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Uuid = table.Column<Guid>(nullable: false),
                    EntityVersion = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    OrganiserId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    LocationUuid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Uuid);
                    table.ForeignKey(
                        name: "FK_Events_Location_LocationUuid",
                        column: x => x.LocationUuid,
                        principalTable: "Location",
                        principalColumn: "Uuid",
                        onDelete: ReferentialAction.Restrict);
                });
          
            migrationBuilder.CreateIndex(
                name: "IX_Events_LocationUuid",
                table: "Events",
                column: "LocationUuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
