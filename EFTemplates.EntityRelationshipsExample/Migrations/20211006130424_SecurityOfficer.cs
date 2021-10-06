using Microsoft.EntityFrameworkCore.Migrations;

namespace EFTemplates.EntityRelationshipsExample.Migrations
{
    public partial class SecurityOfficer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecurityOfficers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityOfficers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountOwnerSecurityOfficer",
                columns: table => new
                {
                    AccountOwnersId = table.Column<long>(type: "bigint", nullable: false),
                    SecurityOfficersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOwnerSecurityOfficer", x => new { x.AccountOwnersId, x.SecurityOfficersId });
                    table.ForeignKey(
                        name: "FK_AccountOwnerSecurityOfficer_AccountOwners_AccountOwnersId",
                        column: x => x.AccountOwnersId,
                        principalTable: "AccountOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountOwnerSecurityOfficer_SecurityOfficers_SecurityOfficersId",
                        column: x => x.SecurityOfficersId,
                        principalTable: "SecurityOfficers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountOwnerSecurityOfficer_SecurityOfficersId",
                table: "AccountOwnerSecurityOfficer",
                column: "SecurityOfficersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountOwnerSecurityOfficer");

            migrationBuilder.DropTable(
                name: "SecurityOfficers");
        }
    }
}
