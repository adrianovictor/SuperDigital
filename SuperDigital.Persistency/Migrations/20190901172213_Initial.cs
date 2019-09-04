using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperDigital.Persistency.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "accounts");

            migrationBuilder.CreateTable(
                name: "AccountHolder",
                schema: "accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 128, nullable: false),
                    Document = table.Column<string>(unicode: false, maxLength: 32, nullable: false),
                    Agency = table.Column<string>(unicode: false, maxLength: 16, nullable: false),
                    AccountNumber = table.Column<string>(unicode: false, maxLength: 16, nullable: false),
                    AccountDigit = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    Avatar = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountHolder", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountHolder",
                schema: "accounts");
        }
    }
}
