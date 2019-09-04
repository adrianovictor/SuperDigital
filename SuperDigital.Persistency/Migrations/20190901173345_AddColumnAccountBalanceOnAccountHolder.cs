using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperDigital.Persistency.Migrations
{
    public partial class AddColumnAccountBalanceOnAccountHolder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AccountBalance",
                schema: "accounts",
                table: "AccountHolder",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountBalance",
                schema: "accounts",
                table: "AccountHolder");
        }
    }
}
