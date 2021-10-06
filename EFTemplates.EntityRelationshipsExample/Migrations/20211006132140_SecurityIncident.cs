using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFTemplates.EntityRelationshipsExample.Migrations
{
    public partial class SecurityIncident : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecurityIncidents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityIncidents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountOwnerSecurityIncident",
                columns: table => new
                {
                    AccountOwnerId = table.Column<long>(type: "bigint", nullable: false),
                    SecurityIncidentId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfIncident = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOwnerSecurityIncident", x => new { x.AccountOwnerId, x.SecurityIncidentId });
                    table.ForeignKey(
                        name: "FK_AccountOwnerSecurityIncident_AccountOwners_AccountOwnerId",
                        column: x => x.AccountOwnerId,
                        principalTable: "AccountOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountOwnerSecurityIncident_SecurityIncidents_SecurityIncidentId",
                        column: x => x.SecurityIncidentId,
                        principalTable: "SecurityIncidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountOwnerSecurityIncident_SecurityIncidentId",
                table: "AccountOwnerSecurityIncident",
                column: "SecurityIncidentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountOwnerSecurityIncident");

            migrationBuilder.DropTable(
                name: "SecurityIncidents");
        }
    }
}
