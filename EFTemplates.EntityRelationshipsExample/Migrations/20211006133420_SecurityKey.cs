using Microsoft.EntityFrameworkCore.Migrations;

namespace EFTemplates.EntityRelationshipsExample.Migrations
{
    public partial class SecurityKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SecurityKeyId",
                table: "AccountOwners",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SecurityKeys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountOwner = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityKeys", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountOwners_SecurityKeyId",
                table: "AccountOwners",
                column: "SecurityKeyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOwners_SecurityKeys_SecurityKeyId",
                table: "AccountOwners",
                column: "SecurityKeyId",
                principalTable: "SecurityKeys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOwners_SecurityKeys_SecurityKeyId",
                table: "AccountOwners");

            migrationBuilder.DropTable(
                name: "SecurityKeys");

            migrationBuilder.DropIndex(
                name: "IX_AccountOwners_SecurityKeyId",
                table: "AccountOwners");

            migrationBuilder.DropColumn(
                name: "SecurityKeyId",
                table: "AccountOwners");
        }
    }
}
