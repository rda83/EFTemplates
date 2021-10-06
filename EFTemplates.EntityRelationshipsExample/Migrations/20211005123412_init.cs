using Microsoft.EntityFrameworkCore.Migrations;

namespace EFTemplates.EntityRelationshipsExample.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountOwners",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOwners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankCellsStorages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Addres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCellsStorages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditProductsGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditProductsGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceEngineers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceEngineers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountOwnerId = table.Column<long>(type: "bigint", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountOwners_AccountOwnerId",
                        column: x => x.AccountOwnerId,
                        principalTable: "AccountOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankDepositBoxes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankCellsStorageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDepositBoxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankDepositBoxes_BankCellsStorages_BankCellsStorageId",
                        column: x => x.BankCellsStorageId,
                        principalTable: "BankCellsStorages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditProducts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditProductsGroupId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditProducts_CreditProductsGroups_CreditProductsGroupId",
                        column: x => x.CreditProductsGroupId,
                        principalTable: "CreditProductsGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ATMMachines",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceEngineerId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATMMachines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ATMMachines_ServiceEngineers_ServiceEngineerId",
                        column: x => x.ServiceEngineerId,
                        principalTable: "ServiceEngineers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountOwnerId",
                table: "Accounts",
                column: "AccountOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ATMMachines_ServiceEngineerId",
                table: "ATMMachines",
                column: "ServiceEngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDepositBoxes_BankCellsStorageId",
                table: "BankDepositBoxes",
                column: "BankCellsStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditProducts_CreditProductsGroupId",
                table: "CreditProducts",
                column: "CreditProductsGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ATMMachines");

            migrationBuilder.DropTable(
                name: "BankDepositBoxes");

            migrationBuilder.DropTable(
                name: "CreditProducts");

            migrationBuilder.DropTable(
                name: "AccountOwners");

            migrationBuilder.DropTable(
                name: "ServiceEngineers");

            migrationBuilder.DropTable(
                name: "BankCellsStorages");

            migrationBuilder.DropTable(
                name: "CreditProductsGroups");
        }
    }
}
