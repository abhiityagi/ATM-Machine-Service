using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATMSoftware.API.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionsData",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<long>(type: "bigint", nullable: false),
                    RecipientAccountNumber = table.Column<long>(type: "bigint", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferAmount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionsData", x => x.TransactionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionsData");
        }
    }
}
